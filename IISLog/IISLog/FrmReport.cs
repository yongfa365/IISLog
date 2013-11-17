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

namespace IISLog
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();

            txtLogFolder.Text = ConfigurationManager.AppSettings["Path"];
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
            if (!string.IsNullOrEmpty(txtLogFolder.Text))
            {
                var lst = new List<string> { "" };
                lst.AddRange(Directory.GetFiles(txtLogFolder.Text, "*.log", SearchOption.AllDirectories));
                cbxLogFile.DataSource = lst;
            }
        }

        private void btnGroupByFileMinutes_Click(object sender, EventArgs e)
        {
            var time2 = DateTime.Now;
            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "开始处理"));
            var logFile = cbxLogFile.Text;
            if (logFile == "")
            {
                Parallel.ForEach((cbxLogFile.DataSource as List<string>), p =>
                {
                    AnalyticsLogFile(p);
                });
            }
            else
            {
                AnalyticsLogFile(logFile);
            }

            Trace.WriteLine(string.Format("{0} {1} {2}", DateTime.Now.TimeOfDay, "处理完成", DateTime.Now - time2));

        }

        private void AnalyticsLogFile(string logFile)
        {
            if (string.IsNullOrEmpty(logFile))
            {
                return;
            }
            Trace.WriteLine(string.Format("{0} {1} {2}", DateTime.Now.TimeOfDay, "开始处理", logFile));

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

                                var keyDateTime = line.Substring(0, 16);//cols[index.Date]+" "+cols[index.Time].Substring(0,5);

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
            Trace.WriteLine(string.Format("{0} {1} {2} {3}", DateTime.Now.TimeOfDay, "处理完文件", logFile, DateTime.Now - time2));
            foreach (var item in dictFiles.Keys)
            {
                foreach (var item2 in dictFiles[item].Values)
                {
                    item2.TimeAvg = Convert.ToInt32(item2.TimeSum / item2.Hits);
                }
            }
            File.WriteAllText(logFile + ".json.txt", dictFiles.ToJson());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "开始整理报表数据源"));
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

            var list = new List<Dictionary<string, Dictionary<string, LogEntity>>>();
            listFile.ForEach(p =>
            {
                if (string.IsNullOrEmpty(p))
                {
                    return;
                }
                var str = File.ReadAllText(p + ".json.txt");
                var dict = str.FromJson<Dictionary<string, Dictionary<string, LogEntity>>>();

                if (txtURL.Text != "")
                {
                    dict = new Dictionary<string, Dictionary<string, LogEntity>> { { txtURL.Text, dict[txtURL.Text] } };
                }
                list.Add(dict);


            });

            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "收集完数据"));
            var resultByM1 = list.Select(p => p.Select(x => x.Value.Select(y => new ReportEntity
            {
                URL = x.Key,
                DateTime = DateTime.Parse(y.Key),
                DateTimeStr=y.Key,
                TimeSum = y.Value.TimeSum,
                TimeAvg = y.Value.TimeAvg
            }))).SelectMany(p => p).SelectMany(p => p).OrderBy(p => p.URL).ThenBy(p => p.DateTime).ToList();

           // var resultByM10=resultByM1.GroupBy(p=>p.URL+ p.DateTimeStr.Substring(15)).

            Trace.WriteLine(string.Format("{0} {1} Count:{2}", DateTime.Now.TimeOfDay, "整理报表数据源完成", resultByM1.Count));


        }
    }
}
