using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            {"Outgoing","Filas de saída" },
            {"Private","Filas privativas" },
            {"Public","Filas públicas" },
            {"System","Filas do sistema" },
            {"ConfirmationDialog","Confirmação" },
            {"Question","Você tem certeza que deseja " },
            {"ActionDelete","deletar esta fila?" },
            {"All","Tudo" },
            {"Light","Claro" },
            {"Dark","Escuro" },

            {"OptionsForm","Opções" },
            {"L_Language","Idioma:" },
            {"L_Theme","Tema:" },
            {"L_Sounds","Habilitar Sons:" },
            {"L_Outgoing","Habilitar filas de saída:" },

            {"NewQueueForm","Nova Fila" },
            {"BTN_Create","Criar Fila" },
            {"NewMessageForm","Nova Mensagem" },
            {"BTN_Send","Enviar para @" },
            {"BTN_Prettify","Formatar" },
            {"L_NewBody","Corpo da mensagem:" },

            {"T_Body","Corpinho" },
            {"T_Extension","Extensão" },
            {"FilterForm","Filtro de Mensagens" },
            {"L_Field","Filtrar corpo:" },
            {"TSMI_Insert","Inserir Mensagem" },
            {"TSMI_Create","Criar Fila" },
            {"TSMI_Delete","Deletar Fila" },
            {"TSMI_Purge","Desmanchar Fila" },
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
            {"columnHeader1"," Id  " },
            {"columnHeader2"," Tamanho  " },
            {"columnHeader3"," Data de criação  " },
            {"columnHeader4"," Fila de origem  " },
            {"columnHeader5"," Conteúdo do corpo  " },
            {"L_Updated","Atualizado em:" },
        };

        /// <summary>
        /// { "Control.Name" : "Control.Text" }
        /// </summary>
        public static Dictionary<string, string> WordsEN = new Dictionary<string, string>()
        {
            {"Outgoing","Outgoing Queues" },
            {"Private","Private Queues" },
            {"Public","Public Queues" },
            {"System","System Queues" },
            {"ConfirmationDialog","Confirmation" },
            {"Question","Are you sure you want to " },
            {"ActionDelete","delete this queue?" },
            {"All","All" },
            {"Light","Light" },
            {"Dark","Dark" },

            {"OptionsForm","Options" },
            {"L_Language","Language:" },
            {"L_Theme","Color Theme:" },
            {"L_Sounds","Enable Sounds:" },
            {"L_Outgoing","Enable Outgoing queues:" },

            {"NewQueueForm","New Queue" },
            {"BTN_Create","Create Queue" },
            {"NewMessageForm","New Message" },
            {"BTN_Send","Send to @" },
            {"BTN_Prettify","Beautify" },
            {"L_NewBody","Message body:" },

            {"T_Body","Body" },
            {"T_Extension","Extension" },
            {"FilterForm","Message Filter" },
            {"L_Field","Filter body:" },
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
            {"columnHeader1"," Id  " },
            {"columnHeader2"," Size  " },
            {"columnHeader3"," Creation Time  " },
            {"columnHeader4"," Response Queue  " },
            {"columnHeader5"," Body Content  " },
            {"L_Updated","Last update:" },
        };

        /// <summary>
        /// { "language" : { "Control.Name" : "Control.Text" } }
        /// </summary>
        public static Dictionary<string, Dictionary<string, string>> Words = new Dictionary<string, Dictionary<string, string>>()
        {
            {"pt-BR", WordsPT },
            {"en-US", WordsEN },
        };

        public static void ChangeLanguage(Control control, string languageName)
        {
            if (!Culture.Languages.Contains(languageName))
                return;

            if (control == null)
                return;

            if (Culture.Words[languageName].TryGetValue(control.Name, out string result))
            {
                control.Text = result;
            }

            foreach (Control c in control.Controls)
            {
                ChangeLanguage(c, languageName);
            }
        }
    }
}
