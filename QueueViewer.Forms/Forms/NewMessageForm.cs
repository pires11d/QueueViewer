using System;
using System.Messaging;
using System.Windows.Forms;

namespace QueueViewer.Forms
{
    public partial class NewMessageDialog : Form
    {
        private MainScreen _main { get; set; }

        public NewMessageDialog(MainScreen main, MessageQueue queue)
        {
            InitializeComponent();
            _main = main;
            BTN_OK.Text = BTN_OK.Text.Replace("@", queue.QueueName);
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                _main.InsertMessageIntoQueue(_main.Service.CurrentQueue, TB_Value.Text);
                _main.ShowMessages(_main.Service.CurrentQueue);
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

        private void BTN_Prettify_Click(object sender, EventArgs e)
        {
            try
            {
                TB_Value.Text = TB_Value.Text.Prettify();
            }
            catch (Exception)
            {
            }
        }
    }
}
