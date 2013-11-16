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
}
