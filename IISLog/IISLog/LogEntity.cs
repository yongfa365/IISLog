using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISLog
{
    public class LogEntity
    {

        public string URL { get; set; }

        public int Hits { get; set; }

        public long TimeSum { get; set; }

        public int TimeAvg { get; set; }

    }

    public class ReportEntity
    {

        public string URL { get; set; }

        public DateTime DateTime { get; set; }

        public string DateTimeStr { get; set; }

        public long TimeSum { get; set; }

        public int TimeAvg { get; set; }

    }

    public class LogColumnIndex
    {
        public int Date { get; set; }
        public int Time { get; set; }
        public int URL { get; set; }
        public int TimeTaken { get; set; }
        public int ScStatus { get; set; }
        public int ScWin32Status { get; set; }
    }
}
