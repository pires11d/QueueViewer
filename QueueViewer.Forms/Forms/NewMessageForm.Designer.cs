
namespace QueueViewer.Forms
{
    partial class NewMessageForm
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
            Custom.SyntaxSettings syntaxSettings1 = new Custom.SyntaxSettings();
            this.BTN_Send = new System.Windows.Forms.Button();
            this.BTN_Prettify = new System.Windows.Forms.Button();
            this.L_NewBody = new System.Windows.Forms.Label();
            this.TB_Value = new Custom.SyntaxRichTextBox();
            this.SuspendLayout();
            // 
            // BTN_Send
            // 
            this.BTN_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Send.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Send.Location = new System.Drawing.Point(215, 359);
            this.BTN_Send.Name = "BTN_Send";
            this.BTN_Send.Size = new System.Drawing.Size(343, 33);
            this.BTN_Send.TabIndex = 3;
            this.BTN_Send.Text = "Send to @";
            this.BTN_Send.UseVisualStyleBackColor = true;
            this.BTN_Send.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_Prettify
            // 
            this.BTN_Prettify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Prettify.Location = new System.Drawing.Point(15, 359);
            this.BTN_Prettify.Name = "BTN_Prettify";
            this.BTN_Prettify.Size = new System.Drawing.Size(88, 33);
            this.BTN_Prettify.TabIndex = 4;
            this.BTN_Prettify.Text = "Prettify";
            this.BTN_Prettify.UseVisualStyleBackColor = true;
            this.BTN_Prettify.Click += new System.EventHandler(this.BTN_Prettify_Click);
            // 
            // L_NewBody
            // 
            this.L_NewBody.AutoSize = true;
            this.L_NewBody.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_NewBody.Location = new System.Drawing.Point(12, 15);
            this.L_NewBody.Name = "L_NewBody";
            this.L_NewBody.Size = new System.Drawing.Size(86, 15);
            this.L_NewBody.TabIndex = 5;
            this.L_NewBody.Text = "Message Body:";
            // 
            // TB_Value
            // 
            this.TB_Value.AcceptsTab = true;
            this.TB_Value.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Value.Json = null;
            this.TB_Value.Location = new System.Drawing.Point(15, 43);
            this.TB_Value.Name = "TB_Value";
            syntaxSettings1.Comment = "";
            syntaxSettings1.CommentColor = System.Drawing.Color.Green;
            syntaxSettings1.EnableComments = true;
            syntaxSettings1.EnableIntegers = true;
            syntaxSettings1.EnableStrings = true;
            syntaxSettings1.IntegerColor = System.Drawing.Color.Red;
            syntaxSettings1.KeywordColor = System.Drawing.Color.Empty;
            syntaxSettings1.StringColor = System.Drawing.Color.Gray;
            syntaxSettings1.SymbolColor = System.Drawing.Color.Empty;
            this.TB_Value.Settings = syntaxSettings1;
            this.TB_Value.ShowSelectionMargin = true;
            this.TB_Value.Size = new System.Drawing.Size(738, 296);
            this.TB_Value.TabIndex = 6;
            this.TB_Value.Text = "";
            this.TB_Value.TextChanged += new System.EventHandler(this.TB_Value_TextChanged);
            // 
            // NewMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 421);
            this.Controls.Add(this.TB_Value);
            this.Controls.Add(this.L_NewBody);
            this.Controls.Add(this.BTN_Prettify);
            this.Controls.Add(this.BTN_Send);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewMessageForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Send;
        private System.Windows.Forms.Button BTN_Prettify;
        private System.Windows.Forms.Label L_NewBody;
        private Custom.SyntaxRichTextBox TB_Value;
    }
}