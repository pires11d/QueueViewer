using Newtonsoft.Json;
using QueueViewer.Lib.Entities;
using QueueViewer.Lib.Extensions;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace System
{
    public static class StringExtensions
    {
        public static string ToFormatName(this string str)
        {
            return $"FormatName:DIRECT=OS:{str}";
        }

        public static string ToSystemQueueLabel(this string str, string machineId)
        {
            str = str.Replace($"DIRECT=OS:{machineId}", "");
            str = str.Replace(@"\", "");
            str = str.Replace(@"$", "");
            str = str.Replace(@";", ".");
            str = str.ToLower();
            str = str.Capitalize();
            return str;
        }

        public static string ToQueueLabel(this string str, bool removeRoot = false)
        {
            str = str.ToLower();
            str = str.Capitalize();
            str = str.Replace("$", "");
            str = str.Replace(@"\", ".");
            str = removeRoot ? str.Replace(Constants.Outgoing, "") : str;
            str = removeRoot ? str.Replace(Constants.Private, "") : str;
            str = removeRoot ? str.Replace(Constants.Public, "") : str;
            str = removeRoot ? str.Replace(Constants.System, "") : str;
            str = str.StartsWith(".") ? str.Remove(0, 1) : str;
            return str;
        }

        public static string ToQueueName(this string str)
        {
            str = str.ToLower();
            str = str.Replace("private", "");
            str = str.StartsWith(".") ? str.Remove(0, 1) : str;
            str = str.StartsWith("@") ? str : $"@{str}";
            str = str.Replace("@", @"private$\");
            return str;
        }

        public static string ToQueuePath(this string str)
        {
            str = str.ToLower();
            str = str.Replace("private", "");
            str = str.StartsWith(".") ? str.Remove(0, 1) : str;
            str = str.StartsWith("@") ? str : $"@{str}";
            str = str.Replace("@", @".\private$\");
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

        public static string RemoveSpaces(this string str)
        {
            return str.Replace("\t", "").Replace("\n", "").Replace("\r", "");
        }

        public static string UpdateCount(this string str, long count = 0)
        {
            var text = str.Split('(').FirstOrDefault();
            return text += $"({count})";
        }

        public static string Prettify(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var result = str;

            // JSON
            try
            {
                result = PrettifyJSON(result);
            }
            catch (Exception ex)
            {
            }

            // XML
            try
            {
                result = PrettifyXML(result);
            }
            catch (Exception ex)
            {
            }

            return result.Length < 2147483647 ? result : result.RemoveSpaces();
        }

        private static string PrettifyJSON(this string str)
        {
            var result = str;

            using (var stringReader = new StringReader(result))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                result = stringWriter.ToString();
            }

            return result;
        }

        public static string PrettifyXML(this string str)
        {
            var result = str;

            var pieces = result.Split(new[] { "\"<" }, StringSplitOptions.None);
            if (pieces.Count() > 1)
            {
                int start = 0;
                foreach (var piece in pieces)
                {
                    if (start == 0)
                    {
                        start += piece.Length;
                        continue;
                    }

                    var rest = str.Substring(start + 1);
                    //var rest = piece;
                    var end = rest.IndexOf(">\"");
                    if (start > 0 && end > 0)
                    {
                        var xml = str.Substring(start + 1, end + 1);
                        try
                        {
                            XDocument doc = XDocument.Parse(xml.RemoveSpaces());
                            var newXml = Environment.NewLine + doc.ToString() + Environment.NewLine;
                            result = str.Replace(xml, newXml);
                        }
                        catch (Exception)
                        {
                        }
                        start += piece.Length + 2;
                    }
                }
            }

            return result;
        }

        public static string ToSize(this string bytes)
        {
            var bytesCount = long.TryParse(bytes, out long n) ? n : 0;
            return SizeExtension.FormatSize(bytesCount);
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
