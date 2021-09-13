using QueueViewer.Forms.Entities;
using QueueViewer.Lib.Entities;
using System;
using System.Windows.Forms;

namespace QueueViewer.Forms
{
    public partial class OptionsForm : Form
    {
        private MainScreen _main { get; set; }
        private string _currentLanguage { get; set; }
        private string _currentTheme { get; set; }
        private string _enableSounds { get; set; }

        public OptionsForm(MainScreen main, Config config)
        {
            InitializeComponent();
            _main = main;
            _currentLanguage = config.Language;
            _currentTheme = config.Theme;
            _enableSounds = config.Sounds;

            ChangeLanguage();
            LoadControls();
            ChangeColor();
        }

        private void ChangeColor()
        {
            var theme = Enum.TryParse(_currentTheme, out ThemesEnum result) ? result : ThemesEnum.Light;
            _main.ChangeColor(this, theme);
        }

        private void ChangeLanguage()
        {
            _main.ChangeLanguage(this, _currentLanguage);
            LoadThemes();
            SelectTheme();
        }

        private void LoadControls()
        {
            SelectLanguage();
            SelectTheme();
            SelectSounds();
        }

        private void LoadThemes()
        {
            CBB_Themes.Items?.Clear();
            CBB_Themes.Items.Add(Culture.Words[_currentLanguage][Constants.Light]);
            CBB_Themes.Items.Add(Culture.Words[_currentLanguage][Constants.Dark]);
        }

        private void SelectLanguage()
        {
            switch (_currentLanguage)
            {
                case "en-US":
                    RB_EN.Checked = true;
                    break;
                case "pt-BR":
                    RB_PT.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void SelectTheme()
        {
            CBB_Themes.SelectedIndex = int.TryParse(_currentTheme, out int result) ? result : 0;
        }

        private void SelectSounds()
        {
            CB_Sounds.Checked = bool.TryParse(_enableSounds, out bool result) ? result : true;
        }

        private void RB_EN_CheckedChanged(object sender, System.EventArgs e)
        {
            if (RB_EN.Checked)
            {
                _currentLanguage = "en-US";
                ChangeLanguage();
            }
        }

        private void RB_PT_CheckedChanged(object sender, System.EventArgs e)
        {
            if (RB_PT.Checked)
            {
                _currentLanguage = "pt-BR";
                ChangeLanguage();
            }
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                _main.Config.Language = _currentLanguage;
                _main.Config.Theme = _currentTheme;
                _main.Config.Sounds = _enableSounds;

                _main.ChangeLanguage();
                _main.SetTheme(_currentTheme);
                _main.ChangeColor();
                _main.EnableSounds = CB_Sounds.Checked;
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

        private void CB_Sounds_CheckedChanged(object sender, EventArgs e)
        {
            _enableSounds = CB_Sounds.Checked.ToString();
        }

        private void CBB_Themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentTheme = CBB_Themes.SelectedIndex.ToString();
            ChangeColor();
        }
    }
}
