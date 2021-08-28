using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueViewer
{
    public partial class Dialog : Form
    {
        public MainScreen Main { get; set; }
        public string Value { get; set; }

        public Dialog(MainScreen main)
        {
            InitializeComponent();
            Main = main;
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
