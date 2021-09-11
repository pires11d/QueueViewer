using System.Collections.Generic;

namespace QueueViewer.Forms
{
    public static class Culture
    {
        public static string[] Languages =
        {
            "pt-BR",
            "en-US"
        };

        /// <summary>
        /// { "Control.Name" : "Control.Text" }
        /// </summary>
        public static Dictionary<string, string> MainScreenPT = new Dictionary<string, string>()
        {
            {"T_Body","Corpinho" },
            {"T_Extension","Extensão" }
        };

        /// <summary>
        /// { "Control.Name" : "Control.Text" }
        /// </summary>
        public static Dictionary<string, string> MainScreenUS = new Dictionary<string, string>()
        {
            {"T_Body","Body" },
            {"T_Extension","Extension" }
        };

        /// <summary>
        /// { "language" : { "Control.Name" : "Control.Text" } }
        /// </summary>
        public static Dictionary<string, Dictionary<string, string>> MainScreen = new Dictionary<string, Dictionary<string, string>>()
        {
            {"pt-BR", MainScreenPT },
            {"en-US", MainScreenUS },
        };

    }
}
