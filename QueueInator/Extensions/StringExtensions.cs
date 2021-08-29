using Newtonsoft.Json;

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
            if (string.IsNullOrEmpty(json))
                return "";
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}
