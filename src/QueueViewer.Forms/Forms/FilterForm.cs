using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QueueViewer.Forms
{
    public partial class FilterForm : Form
    {
        MainScreen _main { get; set; }

        public FilterForm(MainScreen main)
        {
            InitializeComponent();

            AcceptButton = BTN_FilterOK;
            _main = main;
            Culture.ChangeLanguage(this, _main.Config.Language);
            _main.ChangeColor(this, _main.Theme);
            TB_Field.Text = main.Filter;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                _main.Filter = TB_Field.Text;
                _main.UpdateMessages();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                Close();
            }
        }
    }
}
