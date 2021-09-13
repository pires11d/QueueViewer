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
            _main.ChangeLanguage(this, _main.Config.Language);
            _main.ChangeColor(this, _main.Theme);
            AcceptButton = BTN_Create;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                var queueFullName = _main.CreateNewQueue(TB_Value.Text);
                _main.CurrentNode.Nodes.Add(queueFullName, TB_Value.Text);
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
