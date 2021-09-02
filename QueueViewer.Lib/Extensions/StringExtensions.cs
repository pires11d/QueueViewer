using Newtonsoft.Json;
using QueueViewer.Extensions;
using System.IO;
using System.Linq;

namespace System
{
    public static class StringExtensions
    {
        public static string ToQueueLabel(this string str)
        {
            str = str.ToLower();
            str = str.Replace(@"private$\", "");
            str = str.Replace(@"system$\", "");
            str = str.Replace(@"\", ".");
            return str;
        }

        public static string ToQueueName(this string str)
        {
            str = str.ToLower();
            str = str.Replace(@"private", "");
            str = str.StartsWith(".") ? str.Remove(0, 1) : str;
            str = str.StartsWith("@") ? str : $"@{str}";
            str = str.Replace(@"@", @"private$\");
            return str;
        }

        public static string ToQueuePath(this string str)
        {
            str = str.ToLower();
            str = str.Replace(@"private", "");
            str = str.StartsWith(".") ? str.Remove(0,1) : str;
            str = str.StartsWith("@") ? str : $"@{str}";
            str = str.Replace(@"@", @".\private$\");
            return str;
        }

        public static string Capitalize(this string str)
        {
            if (str.Length == 0)
                return "";
            else if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();
            else
                return char.ToUpper(str[0]).ToString() + str.Substring(1);
        }

        public static string UpdateCount(this string str, int count = 0)
        {
            var text = str.Split('(').FirstOrDefault();
            return text += $"({count})";
        }

        public static string Prettify(this string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                    return "";
                using (var stringReader = new StringReader(json))
                using (var stringWriter = new StringWriter())
                {
                    var jsonReader = new JsonTextReader(stringReader);
                    var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                    jsonWriter.WriteToken(jsonReader);
                    return stringWriter.ToString();
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string ToSize(this string bytes)
        {
            var bytesCount = long.TryParse(bytes, out long n) ? n : 0;
            return FileSizeExtension.FormatSize(bytesCount);
        }

        public static string BytesToString(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
