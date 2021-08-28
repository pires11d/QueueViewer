namespace System
{
    public static class StringExtensions
    {
        public static string ToQueueName(this string arg)
        {
            arg = arg.Replace(@"private$\", "").Replace(@"\", ".");
            return arg;
        }

        public static string ToQueuePath(this string arg)
        {
            arg = arg.StartsWith("@") ? arg : $"@{arg}";
            arg = arg.Replace(@".",@"\").Replace(@"@", @".\private$\");
            return arg;
        }
    }
}
