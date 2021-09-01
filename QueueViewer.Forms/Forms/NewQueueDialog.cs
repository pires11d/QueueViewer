using System;
using System.Windows.Forms;

namespace QueueViewer.Forms
{
    public partial class NewQueueDialog : Form
    {
        public MainScreen Main { get; set; }

        public NewQueueDialog(MainScreen main)
        {
            InitializeComponent();
            Main = main;
            AcceptButton = BTN_OK;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Main.CreateQueue(TB_Value.Text);
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
