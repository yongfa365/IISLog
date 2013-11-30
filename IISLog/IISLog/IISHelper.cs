using MsgPack.Serialization;
using Newtonsoft.Json;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;

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

        public static int MaxDegreeOfParallelism
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["MaxDegreeOfParallelism"]);
            }
        }

        public static string SerializerType
        {
            get
            {
                return ConfigurationManager.AppSettings["SerializerType"];
            }
        }

        public static string SerializerFileExt
        {
            get
            {
                return ConfigurationManager.AppSettings["SerializerFileExt"];
            }
        }

        public static void ToFile<T>(this T input, string path)
        {
            var time2 = DateTime.Now;

            if (string.Equals(IISHelper.SerializerType, "MsgPack"))
            {
                using (var fs = File.OpenWrite(path))
                {
                    MessagePackSerializer.Create<T>().Pack(fs, input);
                }
            }
            else if (string.Equals(IISHelper.SerializerType, "ServiceStack.Text.Json"))
            {
                File.WriteAllText(path, input.ToJson());
            }
            else if (string.Equals(IISHelper.SerializerType, "Newtonsoft.Json"))
            {
                var json = JsonConvert.SerializeObject(input, Formatting.None, new JsonSerializerSettings()
                {
                    // ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    // PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                });
                File.WriteAllText(path, json);
            }

            Trace.WriteLine(string.Format("{0} {1} {2} {3} {4}", DateTime.Now.TimeOfDay, IISHelper.SerializerType, "Serialize & SaveToFile:", path, DateTime.Now - time2));
        }

        public static T FromFile<T>(this string path)
        {
            var time2 = DateTime.Now;

            T result = default(T);
            if (string.Equals(IISHelper.SerializerType, "MsgPack"))
            {
                using (var fs = File.OpenRead(path))
                {
                    var serializer = MessagePackSerializer.Create<T>();
                    result = serializer.Unpack(fs);//MessagePack serializer for the type 'System.Collections.Generic.Dictionary`2[System.String,IISLog.LogEntity]' is not constructed yet.
                }
            }
            else if (string.Equals(IISHelper.SerializerType, "ServiceStack.Text.Json"))
            {
                var str = File.ReadAllText(path);
                result = str.FromJson<T>();
            }
            else if (string.Equals(IISHelper.SerializerType, "Newtonsoft.Json"))
            {
                var str = File.ReadAllText(path);
                result = JsonConvert.DeserializeObject<T>(str, new JsonSerializerSettings()
                {
                    //  ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    // PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                });
            }
            Trace.WriteLine(string.Format("{0} {1} {2} {3} {4}", DateTime.Now.TimeOfDay, IISHelper.SerializerType, "Derialize & FromFile:", path, DateTime.Now - time2));
            return result;

        }
    }

}
