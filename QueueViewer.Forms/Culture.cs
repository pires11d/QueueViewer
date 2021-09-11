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
        public static Dictionary<string, string> WordsPT = new Dictionary<string, string>()
        {
            {"Light","Claro" },
            {"Dark","Escuro" },
            {"T_Body","Corpinho" },
            {"T_Extension","Extensão" },
            {"L_Language","Idioma:" },
            {"L_Theme","Tema:" },
            {"L_Sounds","Habilitar Sons:" },
        };

        /// <summary>
        /// { "Control.Name" : "Control.Text" }
        /// </summary>
        public static Dictionary<string, string> WordsEN = new Dictionary<string, string>()
        {
            {"Light","Light" },
            {"Dark","Dark" },
            {"T_Body","Body" },
            {"T_Extension","Extension" },
            {"L_Language","Language:" },
            {"L_Theme","Color Theme:" },
            {"L_Sounds","Enable Sounds:" },
        };

        /// <summary>
        /// { "language" : { "Control.Name" : "Control.Text" } }
        /// </summary>
        public static Dictionary<string, Dictionary<string, string>> Words = new Dictionary<string, Dictionary<string, string>>()
        {
            {"pt-BR", WordsPT },
            {"en-US", WordsEN },
        };

    }
}
