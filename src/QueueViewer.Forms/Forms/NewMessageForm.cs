using Custom;
using System;
using System.Messaging;
using System.Windows.Forms;

namespace QueueViewer.Forms
{
    public partial class NewMessageForm : Form
    {
        private MainScreen _main { get; set; }

        public NewMessageForm(MainScreen main, MessageQueue queue)
        {
            InitializeComponent();

            _main = main;
            Culture.ChangeLanguage(this, _main.Config.Language);
            _main.ChangeColor(this, _main.Theme);
            TB_Value.Initialize(_main.Theme);
            BTN_Send.Text = BTN_Send.Text.Replace("@", queue.QueueName);
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
                TB_Value.ProcessAllLines();
            }
            catch (Exception)
            {
            }
        }

        private void TB_Value_TextChanged(object sender, EventArgs e)
        {
            TB_Value.ProcessAllLines();
        }
    }
}
