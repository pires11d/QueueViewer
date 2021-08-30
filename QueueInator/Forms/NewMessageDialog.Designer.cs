
namespace QueueInator.Forms
{
    partial class NewMessageDialog
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
            this.BTN_OK = new System.Windows.Forms.Button();
            this.TB_Value = new System.Windows.Forms.TextBox();
            this.BTN_Prettify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_OK
            // 
            this.BTN_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_OK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_OK.Location = new System.Drawing.Point(217, 401);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(374, 33);
            this.BTN_OK.TabIndex = 3;
            this.BTN_OK.Text = "Send to @";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // TB_Value
            // 
            this.TB_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Value.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Value.Location = new System.Drawing.Point(12, 12);
            this.TB_Value.Multiline = true;
            this.TB_Value.Name = "TB_Value";
            this.TB_Value.Size = new System.Drawing.Size(776, 371);
            this.TB_Value.TabIndex = 2;
            // 
            // BTN_Prettify
            // 
            this.BTN_Prettify.Location = new System.Drawing.Point(12, 401);
            this.BTN_Prettify.Name = "BTN_Prettify";
            this.BTN_Prettify.Size = new System.Drawing.Size(88, 33);
            this.BTN_Prettify.TabIndex = 4;
            this.BTN_Prettify.Text = "Prettify";
            this.BTN_Prettify.UseVisualStyleBackColor = true;
            this.BTN_Prettify.Click += new System.EventHandler(this.BTN_Prettify_Click);
            // 
            // NewMessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_Prettify);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.TB_Value);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewMessageDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewMessageDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.TextBox TB_Value;
        private System.Windows.Forms.Button BTN_Prettify;
    }
}