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

            Trace.Listeners.Add(new ConsoleTraceListener());
            textBox1.Text = ConfigurationManager.AppSettings["Path"];
            textBox1.Focus();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            Dictionary<string, int> dictHeader = null;
            var dictItems = new Dictionary<string, LogEntity>(100, StringComparer.OrdinalIgnoreCase);
            var logFile = comboBox1.Text;
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
                                var time = long.Parse(cols[timeIndex]);
                                if (time < numericUpDown1.Value)
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
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                comboBox1.DataSource = Directory.GetFiles(textBox1.Text, "*.log", SearchOption.AllDirectories);
            }
        }

    }
}









