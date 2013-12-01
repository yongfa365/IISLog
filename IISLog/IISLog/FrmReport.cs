using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;


namespace IISLog
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();


            cbxGroupByType.SelectedIndex = 1;

            cbxURL.Items.AddRange(IISHelper.AllReportUrl);
            cbxURL.SelectedIndex = 0;

            cbxLogFolder.Items.AddRange(IISHelper.AllLogPath);
            cbxLogFolder.SelectedIndex = 0;

        }
        private static DataTable GenTable(Dictionary<string, LogEntity> dictItems)
        {
            var table = new DataTable();
            table.Columns.Add("URL");
            table.Columns.Add("Hits", typeof(int));
            table.Columns.Add("TimeSum", typeof(long));
            table.Columns.Add("TimeAvg", typeof(int));
            foreach (var item in dictItems)
            {
                table.Rows.Add(item.Key, item.Value.Hits, item.Value.TimeSum, item.Value.TimeSum / item.Value.Hits);
            }
            return table;
        }

        private void cbxLogFile_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxLogFolder.Text))
            {
                if (!Directory.Exists(cbxLogFolder.Text))
                {
                    return;
                }
                var lst = new List<string> { "" };
                var fs = Directory.GetFiles(cbxLogFolder.Text, "*.log", SearchOption.AllDirectories);
                if (fs.Length > 0)
                {
                    lst.AddRange(fs);
                }
                cbxLogFile.DataSource = lst;
            }
        }

        private void btnGroupByFileMinutes_Click(object sender, EventArgs e)
        {
            var time2 = DateTime.Now;
            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "Root Start"));

            var datetimelength = 0;
            switch (cbxGroupByType.Text)
            {
                case "1Minute":
                    datetimelength = 16;
                    break;
                case "10Minute":
                    datetimelength = 15;
                    break;
                case "1Hour":
                    datetimelength = 13;
                    break;
            }

            var files = cbxLogFile.DataSource as List<string>;
            if (files == null)
            {
                MessageBox.Show("Folder do not exist Log File");
                return;
            }

            if (cbxLogFile.Text != "")
            {
                AnalyticsLogFile(cbxLogFile.Text, datetimelength);
            }
            else
            {
                Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = IISHelper.MaxDegreeOfParallelism }, p =>
                {
                    AnalyticsLogFile(p, datetimelength);
                });
            }


            Trace.WriteLine(string.Format("{0} {1} {2}", DateTime.Now.TimeOfDay, "Root End", DateTime.Now - time2));
            Trace.Flush();
        }

        private void AnalyticsLogFile(string logFile, int datetimelength)
        {
            if (string.IsNullOrEmpty(logFile))
            {
                return;
            }
            Trace.WriteLine(string.Format("{0} {1} {2}", DateTime.Now.TimeOfDay, "Start Analytics:", logFile));

            Dictionary<string, int> dictHeader = null;
            var dictFiles = new Dictionary<string, Dictionary<string, LogEntity>>(100, StringComparer.OrdinalIgnoreCase);
            var time2 = DateTime.Now;
            var index = new LogColumnIndex();


            using (var sr = new StreamReader(logFile))
            {
                string line = null;
                string[] cols;


                while ((line = sr.ReadLine()) != null)
                {

                    if (IISHelper.IsHeader(line))
                    {
                        dictHeader = IISHelper.ParseHeader(line);
                        index.URL = dictHeader["cs-uri-stem"];
                        index.TimeTaken = dictHeader["time-taken"];
                        index.ScWin32Status = dictHeader["sc-win32-status"];
                    }
                    else
                    {
                        if (IISHelper.IsBody(line))
                        {
                            cols = line.Split(' ');



                            if (cols[index.ScWin32Status] == "0")
                            {
                                var url = cols[index.URL];
                                var time = long.Parse(cols[index.TimeTaken]);
                                if (time < numTimes.Value)
                                {
                                    continue;
                                }

                                var keyDateTime = line.Substring(0, datetimelength);//cols[index.Date]+" "+cols[index.Time].Substring(0,5);

                                if (!dictFiles.ContainsKey(url))
                                {
                                    var dict = new Dictionary<string, LogEntity>(StringComparer.OrdinalIgnoreCase);
                                    dictFiles.Add(url, dict);
                                }

                                if (dictFiles[url].ContainsKey(keyDateTime))
                                {
                                    dictFiles[url][keyDateTime].Hits++;
                                    dictFiles[url][keyDateTime].TimeSum += time;
                                }
                                else
                                {
                                    dictFiles[url].Add(keyDateTime, new LogEntity { Hits = 1, TimeSum = time });
                                }
                            }
                        }
                    }
                }
            }
            Trace.WriteLine(string.Format("{0} {1} {2} {3}", DateTime.Now.TimeOfDay, "End Analytics:", logFile, DateTime.Now - time2));

            foreach (var item in dictFiles.Keys)
            {
                foreach (var item2 in dictFiles[item].Values)
                {
                    var aaa = item2.TimeSum / item2.Hits;
                    if (aaa > int.MaxValue)
                    {
                        aaa = int.MaxValue;
                    }
                    item2.TimeAvg = Convert.ToInt32(aaa);
                }
            }

            dictFiles.ToFile(logFile + IISHelper.SerializerFileExt);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbxLogFile.DataSource ==null)
            {
                MessageBox.Show("Folder do not exist Log File");
                return;
            }

            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "Get Report Data Start"));


            var listFile = new List<string>();
            //取数据
            if (cbxLogFile.Text == "")
            {
                listFile.AddRange(cbxLogFile.DataSource as List<string>);
            }
            else
            {
                listFile.Add(cbxLogFile.Text);
            }

            var url = cbxURL.Text;

            var list = new ConcurrentBag<Dictionary<string, Dictionary<string, LogEntity>>>();
            Parallel.ForEach(listFile, new ParallelOptions { MaxDegreeOfParallelism = IISHelper.MaxDegreeOfParallelism }, p =>
            {
                if (string.IsNullOrEmpty(p))
                {
                    return;
                }
                var statTime = DateTime.Now;
                var fileName = p + IISHelper.SerializerFileExt;
                var dict2 = fileName.FromFile<Dictionary<string, Dictionary<string, LogEntity>>>();

                var dict = new Dictionary<string, Dictionary<string, LogEntity>>(dict2, StringComparer.OrdinalIgnoreCase);

                if (url != "")
                {

                    if (dict.ContainsKey(url))
                    {
                        dict = new Dictionary<string, Dictionary<string, LogEntity>> { { url, dict[url] } };
                        list.Add(dict);
                    }

                }
                else
                {
                    list.Add(dict);
                }
                Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "Insert End" + p + (DateTime.Now - statTime)));


            });

            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "Combine Data Start"));
            var result = list.Select(p => p.Select(x => x.Value.Select(y => new ReportEntity
            {
                URL = x.Key,
                DateTime = DateTime.Parse(y.Key.PadRight(16, '0')).AddHours(8),
                DateTimeStr = y.Key,
                TimeSum = y.Value.TimeSum,
                TimeAvg = y.Value.TimeAvg
            }))).SelectMany(p => p).SelectMany(p => p).OrderBy(p => p.URL).ThenBy(p => p.DateTime).ToList();



            Trace.WriteLine(string.Format("{0} {1} Count:{2}", DateTime.Now.TimeOfDay, "Combine Data End", result.Count));

            var sb = new StringBuilder();

            //.AddMonths(-1)不然顯示有問題
            if (rdoAvg.Checked)
            {
                result.ForEach(p =>
                {
                    sb.AppendFormat(",[Date.UTC({0}),{1}]\r\n", p.DateTime.AddMonths(-1).ToString("yyyy,MM,dd,HH,mm"), p.TimeAvg);
                });
            }
            else
            {
                result.ForEach(p =>
                {
                    sb.AppendFormat(",[Date.UTC({0}),{1}]\r\n", p.DateTime.AddMonths(-1).ToString("yyyy,MM,dd,HH,mm"), p.TimeSum);
                });
            }

            var strResult = File.ReadAllText("Template\\1.html").Replace("{Data}", sb.ToString().Substring(1));
            File.WriteAllText(string.Format("Result.{0}.{1}.html", DateTime.Now.Ticks, url.Replace("/", ".")), strResult);
            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "To Html OK"));
        }
    }
}
