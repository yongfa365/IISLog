﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISLog
{
    class IISHelper
    {
        public static Dictionary<string, int> ParseHeader(string line)
        {
            var dict = new Dictionary<string, int>();
            var header = line.Substring(9).Split(' ');
            for (int i = 0; i < header.Length; i++)
            {
                dict.Add(header[i], i);
            }
            return dict;
        }

        public static bool IsBody(string line)
        {
            if (line.StartsWith("#") || line == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsHeader(string line)
        {
            return line.StartsWith("#Fields:");
        }

    }

}