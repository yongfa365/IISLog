using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;

namespace IISLog
{
    public partial class FrmFileViewAnalytics : Form
    {

        public FrmFileViewAnalytics()
        {
            InitializeComponent();


            txtLogFolder.Text = ConfigurationManager.AppSettings["Path"];

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            Dictionary<string, int> dictHeader = null;
            var dictItems = new Dictionary<string, LogEntity>(100, StringComparer.OrdinalIgnoreCase);
            var logFile = cbxLogFile.Text;
            if (!File.Exists(logFile))
            {

            }
            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "开始处理"));
            var time2 = DateTime.Now;
            using (var sr = new StreamReader(logFile))
            {
                string line = null;
                string[] cols;
                var urlIndex = 0;
                var timeIndex = 0;
                var statusIndex = 0;

                while ((line = sr.ReadLine()) != null)
                {

                    if (IISHelper.IsHeader(line))
                    {
                        dictHeader = IISHelper.ParseHeader(line);
                        urlIndex = dictHeader["cs-uri-stem"];
                        timeIndex = dictHeader["time-taken"];
                        statusIndex = dictHeader["sc-win32-status"];
                    }
                    else
                    {
                        if (IISHelper.IsBody(line))
                        {
                            cols = line.Split(' ');


                            if (cols[statusIndex] == "0")
                            {
                                var url = cols[urlIndex];
                                //if (txtURL.Text != string.Empty && !string.Equals(txtURL.Text, url, StringComparison.OrdinalIgnoreCase))
                                //{
                                //    continue;
                                //}
                                var time = long.Parse(cols[timeIndex]);
                                if (time < numTimes.Value)
                                {
                                    continue;
                                }
                                if (dictItems.ContainsKey(url))
                                {
                                    dictItems[url].Hits++;
                                    dictItems[url].TimeSum += time;
                                }
                                else
                                {
                                    dictItems.Add(url, new LogEntity { Hits = 1, TimeSum = time });
                                }
                            }

                        }
                    }
                }
            }
            Trace.WriteLine(string.Format("{0} {1} {2}", DateTime.Now.TimeOfDay, "处理完文件", DateTime.Now - time2));


            {
                dictItems = dictItems.GroupBy(p => GetGroupByStr(p.Key))
                    .ToDictionary(p => p.Key, p => new LogEntity { URL = p.Key, Hits = p.Sum(x => x.Value.Hits), TimeSum = p.Sum(x => x.Value.TimeSum) });

            }


            var table = GenTable(dictItems);

            Trace.WriteLine(string.Format("{0} {1}", DateTime.Now.TimeOfDay, "组装完Table"));
            dataGridView1.DataSource = table;
            dataGridView1.AutoResizeColumns();

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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogFolder.Text))
            {
                cbxLogFile.DataSource = Directory.GetFiles(txtLogFolder.Text, "*.log", SearchOption.AllDirectories);
            }
        }
        private Regex re = new Regex("P");
        private string GetGroupByStr(string input)
        {
            if (input.StartsWith("/Theme/", StringComparison.OrdinalIgnoreCase))
            {
                return "访问Theme";
            }
            else if (input == "/")
            {
                return "访问首页";
            }
            else if (input.StartsWith("/Product/City/", StringComparison.OrdinalIgnoreCase))
            {
                return "访问城市列表";
            }
            else if (input.StartsWith("/scripts/", StringComparison.OrdinalIgnoreCase))
            {
                return "访问脚本文件";
            }
            else if (input.StartsWith("/Jsonp/", StringComparison.OrdinalIgnoreCase))
            {
                return "访问Jsonp";
            }
            else if (input.StartsWith("/OP/", StringComparison.OrdinalIgnoreCase))
            {
                return "访问OP";
            }
            else if (input.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase))
            {
                return "访问PDF";
            }
            else if (input.StartsWith("/Detail/", StringComparison.OrdinalIgnoreCase))
            {
                return "访问产品详情页";
            }
            else if (input.StartsWith("/Booking/", StringComparison.OrdinalIgnoreCase))
            {
                return "预订流程";
            }
            else if (input.StartsWith("/Flight/", StringComparison.OrdinalIgnoreCase))
            {
                return "预订流程.Flight";
            }
            else if (input.StartsWith("/Hotel/", StringComparison.OrdinalIgnoreCase))
            {
                return "预订流程.Hotel";
            }
            else if (input.StartsWith("/Price/", StringComparison.OrdinalIgnoreCase))
            {
                return "预订流程.Price";
            }

            else if (input.StartsWith("/City/", StringComparison.OrdinalIgnoreCase))
            {
                return "City查询";
            }
            else if (input.StartsWith("/content/", StringComparison.OrdinalIgnoreCase))
            {
                return "Content查询";
            }
            else
            {
                return "未归类";
            }
        }

    }
}









