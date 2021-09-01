using Newtonsoft.Json;
using QueueViewer.Extensions;
using System.IO;

namespace System
{
    public static class StringExtensions
    {
        public static string ToQueueLabel(this string arg)
        {
            arg = arg.ToLower();
            arg = arg.Replace(@"private$\", "");
            arg = arg.Replace(@"system$\", "");
            arg = arg.Replace(@"\", ".");
            return arg;
        }

        public static string ToQueueName(this string arg)
        {
            arg = arg.ToLower();
            arg = arg.Replace(@"private", "");
            arg = arg.StartsWith(".") ? arg.Remove(0, 1) : arg;
            arg = arg.StartsWith("@") ? arg : $"@{arg}";
            arg = arg.Replace(@"@", @"private$\");
            return arg;
        }

        public static string ToQueuePath(this string arg)
        {
            arg = arg.ToLower();
            arg = arg.Replace(@"private", "");
            arg = arg.StartsWith(".") ? arg.Remove(0,1) : arg;
            arg = arg.StartsWith("@") ? arg : $"@{arg}";
            arg = arg.Replace(@"@", @".\private$\");
            return arg;
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
