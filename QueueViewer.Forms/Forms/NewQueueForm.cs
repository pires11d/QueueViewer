using System;
using System.Windows.Forms;

namespace QueueViewer.Forms
{
    public partial class NewQueueDialog : Form
    {
        private MainScreen _main { get; set; }

        public NewQueueDialog(MainScreen main)
        {
            InitializeComponent();
            _main = main;
            AcceptButton = BTN_OK;
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
