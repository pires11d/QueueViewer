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
            {"All","Tudo" },
            {"Light","Claro" },
            {"Dark","Escuro" },
            {"OptionsForm","Opções" },
            {"L_Language","Idioma:" },
            {"L_Theme","Tema:" },
            {"L_Sounds","Habilitar Sons:" },
            {"NewQueueForm","Nova Fila" },
            {"BTN_Create","Criar Fila" },
            {"NewMessageForm","Nova Mensagem" },
            {"BTN_Send","Enviar para @" },
            {"BTN_Prettify","Formatar" },
            {"L_NewBody","Corpo da mensagem:" },
            {"T_Body","Corpinho" },
            {"T_Extension","Extensão" },
            {"TSMI_Insert","Inserir Mensagem" },
            {"TSMI_Create","Criar Fila" },
            {"TSMI_Delete","Deletar Fila" },
            {"TSMI_Purge","Limpar Fila" },
            {"TSMI_Reprocess","Reprocessar" },
            {"TSMI_Expand","Expandir" },
            {"TSMI_Collapse","Encolher" },
            {"fileToolStripMenuItem","Arquivo" },
            {"openToolStripMenuItem","Abrir" },
            {"saveToolStripMenuItem","Salvar" },
            {"saveAsToolStripMenuItem","Salvar Como" },
            {"exitToolStripMenuItem","Sair" },
            {"optionsToolStripMenuItem","Opções" },
            {"CB_Refresh","Atualizar a cada" },
            {"L_Unit","segundos" },
            {"LB_MaxMessages","Mostrar" },
            {"columnHeader1","Id" },
            {"columnHeader2","Tamanho" },
            {"columnHeader3","Data de criação" },
            {"columnHeader4","Fila de origem" },
            {"columnHeader5","Conteúdo do corpinho" },
        };

        /// <summary>
        /// { "Control.Name" : "Control.Text" }
        /// </summary>
        public static Dictionary<string, string> WordsEN = new Dictionary<string, string>()
        {
            {"All","All" },
            {"Light","Light" },
            {"Dark","Dark" },
            {"OptionsForm","Options" },
            {"L_Language","Language:" },
            {"L_Theme","Color Theme:" },
            {"L_Sounds","Enable Sounds:" },
            {"NewQueueForm","New Queue" },
            {"BTN_Create","Create Queue" },
            {"NewMessageForm","New Message" },
            {"BTN_Send","Send to @" },
            {"BTN_Prettify","Beautify" },
            {"L_NewBody","Message body:" },
            {"T_Body","Body" },
            {"T_Extension","Extension" },
            {"TSMI_Insert","Insert New Message" },
            {"TSMI_Create","Create Queue" },
            {"TSMI_Delete","Delete Queue" },
            {"TSMI_Purge","Purge" },
            {"TSMI_Reprocess","Reprocess" },
            {"TSMI_Expand","Expand" },
            {"TSMI_Collapse","Collapse" },
            {"fileToolStripMenuItem","File" },
            {"openToolStripMenuItem","Open" },
            {"saveToolStripMenuItem","Save" },
            {"saveAsToolStripMenuItem","Save As" },
            {"exitToolStripMenuItem","Exit" },
            {"optionsToolStripMenuItem","Options" },
            {"CB_Refresh","Refresh every" },
            {"L_Unit","seconds" },
            {"LB_MaxMessages","Show" },
            {"columnHeader1","Id" },
            {"columnHeader2","Size" },
            {"columnHeader3","Creation Time" },
            {"columnHeader4","Response Queue" },
            {"columnHeader5","Body Content" },
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
