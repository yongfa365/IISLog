using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IISLog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Trace.Listeners.Add(new ConsoleTraceListener());
            var logFileName = string.Format("IISLog.{0}.txt", DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss"));
            Trace.Listeners.Add(new TextWriterTraceListener(logFileName));
            Trace.AutoFlush = true;

            Application.Run(new Form1());
        }
    }
}
