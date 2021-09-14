namespace QueueViewer.Forms
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.L_Language = new System.Windows.Forms.Label();
            this.RB_EN = new System.Windows.Forms.RadioButton();
            this.RB_PT = new System.Windows.Forms.RadioButton();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.L_Theme = new System.Windows.Forms.Label();
            this.CBB_Themes = new System.Windows.Forms.ComboBox();
            this.L_Sounds = new System.Windows.Forms.Label();
            this.CB_Sounds = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // L_Language
            // 
            this.L_Language.AutoSize = true;
            this.L_Language.Location = new System.Drawing.Point(28, 21);
            this.L_Language.Name = "L_Language";
            this.L_Language.Size = new System.Drawing.Size(62, 15);
            this.L_Language.TabIndex = 0;
            this.L_Language.Text = "Language:";
            // 
            // RB_EN
            // 
            this.RB_EN.BackgroundImage = global::QueueViewer.Forms.Properties.Resources.en_US;
            this.RB_EN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RB_EN.Location = new System.Drawing.Point(152, 15);
            this.RB_EN.Name = "RB_EN";
            this.RB_EN.Size = new System.Drawing.Size(80, 27);
            this.RB_EN.TabIndex = 1;
            this.RB_EN.TabStop = true;
            this.RB_EN.UseVisualStyleBackColor = true;
            this.RB_EN.CheckedChanged += new System.EventHandler(this.RB_EN_CheckedChanged);
            // 
            // RB_PT
            // 
            this.RB_PT.BackgroundImage = global::QueueViewer.Forms.Properties.Resources.pt_BR;
            this.RB_PT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RB_PT.Location = new System.Drawing.Point(152, 48);
            this.RB_PT.Name = "RB_PT";
            this.RB_PT.Size = new System.Drawing.Size(80, 28);
            this.RB_PT.TabIndex = 2;
            this.RB_PT.TabStop = true;
            this.RB_PT.UseVisualStyleBackColor = true;
            this.RB_PT.CheckedChanged += new System.EventHandler(this.RB_PT_CheckedChanged);
            // 
            // BTN_OK
            // 
            this.BTN_OK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_OK.Location = new System.Drawing.Point(87, 208);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(124, 38);
            this.BTN_OK.TabIndex = 3;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // L_Theme
            // 
            this.L_Theme.AutoSize = true;
            this.L_Theme.Location = new System.Drawing.Point(28, 102);
            this.L_Theme.Name = "L_Theme";
            this.L_Theme.Size = new System.Drawing.Size(46, 15);
            this.L_Theme.TabIndex = 4;
            this.L_Theme.Text = "Theme:";
            // 
            // CBB_Themes
            // 
            this.CBB_Themes.FormattingEnabled = true;
            this.CBB_Themes.Location = new System.Drawing.Point(152, 98);
            this.CBB_Themes.Name = "CBB_Themes";
            this.CBB_Themes.Size = new System.Drawing.Size(103, 23);
            this.CBB_Themes.TabIndex = 5;
            this.CBB_Themes.SelectedIndexChanged += new System.EventHandler(this.CBB_Themes_SelectedIndexChanged);
            // 
            // L_Sounds
            // 
            this.L_Sounds.AutoSize = true;
            this.L_Sounds.Location = new System.Drawing.Point(28, 152);
            this.L_Sounds.Name = "L_Sounds";
            this.L_Sounds.Size = new System.Drawing.Size(86, 15);
            this.L_Sounds.TabIndex = 6;
            this.L_Sounds.Text = "Enable sounds:";
            // 
            // CB_Sounds
            // 
            this.CB_Sounds.AutoSize = true;
            this.CB_Sounds.Location = new System.Drawing.Point(152, 152);
            this.CB_Sounds.Name = "CB_Sounds";
            this.CB_Sounds.Size = new System.Drawing.Size(15, 14);
            this.CB_Sounds.TabIndex = 7;
            this.CB_Sounds.UseVisualStyleBackColor = true;
            this.CB_Sounds.CheckedChanged += new System.EventHandler(this.CB_Sounds_CheckedChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 267);
            this.Controls.Add(this.CB_Sounds);
            this.Controls.Add(this.L_Sounds);
            this.Controls.Add(this.CBB_Themes);
            this.Controls.Add(this.L_Theme);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.RB_PT);
            this.Controls.Add(this.RB_EN);
            this.Controls.Add(this.L_Language);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Language;
        private System.Windows.Forms.RadioButton RB_EN;
        private System.Windows.Forms.RadioButton RB_PT;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Label L_Theme;
        private System.Windows.Forms.ComboBox CBB_Themes;
        private System.Windows.Forms.Label L_Sounds;
        private System.Windows.Forms.CheckBox CB_Sounds;
    }
}