
namespace QueueViewer.Forms
{
    partial class FilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.TB_Field = new System.Windows.Forms.TextBox();
            this.L_Field = new System.Windows.Forms.Label();
            this.BTN_FilterOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_Field
            // 
            this.TB_Field.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Field.Location = new System.Drawing.Point(134, 21);
            this.TB_Field.Multiline = true;
            this.TB_Field.Name = "TB_Field";
            this.TB_Field.Size = new System.Drawing.Size(395, 37);
            this.TB_Field.TabIndex = 0;
            // 
            // L_Field
            // 
            this.L_Field.AutoSize = true;
            this.L_Field.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Field.Location = new System.Drawing.Point(21, 25);
            this.L_Field.Name = "L_Field";
            this.L_Field.Size = new System.Drawing.Size(82, 15);
            this.L_Field.TabIndex = 2;
            this.L_Field.Text = "Filter Body by:";
            // 
            // BTN_FilterOK
            // 
            this.BTN_FilterOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BTN_FilterOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_FilterOK.Location = new System.Drawing.Point(569, 21);
            this.BTN_FilterOK.Name = "BTN_FilterOK";
            this.BTN_FilterOK.Size = new System.Drawing.Size(107, 37);
            this.BTN_FilterOK.TabIndex = 4;
            this.BTN_FilterOK.Text = "OK";
            this.BTN_FilterOK.UseVisualStyleBackColor = false;
            this.BTN_FilterOK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 80);
            this.Controls.Add(this.BTN_FilterOK);
            this.Controls.Add(this.L_Field);
            this.Controls.Add(this.TB_Field);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Field;
        private System.Windows.Forms.Label L_Field;
        private System.Windows.Forms.Button BTN_FilterOK;
    }
}