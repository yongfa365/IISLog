using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace IISLog
{
   public static class IISHelper
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


        public static string ToJson<T>(this T item)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(item);
        }

        public static T FromJson<T>(this string str)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(str);

        }
    }

}
