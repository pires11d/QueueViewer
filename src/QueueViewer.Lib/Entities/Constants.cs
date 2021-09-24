namespace QueueViewer.Lib.Entities
{
    public static class Constants
    {
        public const string Outgoing = "Outgoing";
        public const string Private = "Private";
        public const string Public = "Public";
        public const string System = "System";

        public const string Light = "Light";
        public const string Dark = "Dark";
        public const string All = "All";
        public static string[] QueueTypes = new string[] { Constants.Outgoing, Constants.Private, Constants.Public, Constants.System };
    }
}
