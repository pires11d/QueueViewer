using System;
using System.Windows.Forms;

namespace QueueViewer.Forms
{
    public partial class NewQueueForm : Form
    {
        private MainScreen _main { get; set; }

        public NewQueueForm(MainScreen main)
        {
            InitializeComponent();
            _main = main;
            Culture.ChangeLanguage(this, _main.Config.Language);
            _main.ChangeColor(this, _main.Theme);
            AcceptButton = BTN_Create;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                var queueFullName = _main.CreateNewQueue(TB_Value.Text);
                var newNode = _main.AddNodeByFullName(_main.CurrentNode,queueFullName);
                _main.ExpandUntilNode(newNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }
    }
}
