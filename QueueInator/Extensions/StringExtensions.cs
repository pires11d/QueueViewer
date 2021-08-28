namespace System
{
    public static class StringExtensions
    {
        public static string ToQueueName(this string arg)
        {
            arg = arg.ToLower();
            arg = arg.Replace(@"private$\", "");
            arg = arg.Replace(@"system$\", "");
            arg = arg.Replace(@"\", ".");
            return arg;
        }

        public static string ToQueuePath(this string arg)
        {
            arg = arg.ToLower();
            arg = arg.StartsWith("@") ? arg : $"@{arg}";
            arg = arg.Replace(@".",@"\").Replace(@"@", @".\private$\");
            return arg;
        }
    }
}
