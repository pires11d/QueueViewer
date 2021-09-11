using System;
using System.Messaging;
using System.Windows.Forms;

namespace QueueViewer.Forms
{
    public partial class NewMessageDialog : Form
    {
        public MainScreen Main { get; set; }
        public NewMessageDialog(MainScreen main, MessageQueue queue)
        {
            InitializeComponent();
            Main = main;
            BTN_OK.Text = BTN_OK.Text.Replace("@", queue.QueueName);
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Main.InsertMessageIntoQueue(Main.Service.CurrentQueue, TB_Value.Text);
                Main.ShowMessages(Main.Service.CurrentQueue);
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
