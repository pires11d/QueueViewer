using System;
using System.Messaging;
using System.Windows.Forms;

namespace QueueInator.Forms
{
    public partial class NewMessageDialog : Form
    {
        public MainScreen Main { get; set; }
        public NewMessageDialog(MainScreen main, MessageQueue queue)
        {
            InitializeComponent();
            Main = main;
            BTN_OK.Text = BTN_OK.Text.Replace("@", queue.QueueName.ToQueuePath());
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Main.InsertMessage(TB_Value.Text);
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
