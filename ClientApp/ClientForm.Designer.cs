namespace ClientApp
{
    partial class ClientForm
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
            this.sendBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.dataBox = new System.Windows.Forms.RichTextBox();
            this.signBox = new System.Windows.Forms.TextBox();
            this.signButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sendBox
            // 
            this.sendBox.Enabled = false;
            this.sendBox.Location = new System.Drawing.Point(13, 282);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(518, 20);
            this.sendBox.TabIndex = 0;
            this.sendBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendBox_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(537, 280);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // dataBox
            // 
            this.dataBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataBox.Location = new System.Drawing.Point(12, 42);
            this.dataBox.Name = "dataBox";
            this.dataBox.ReadOnly = true;
            this.dataBox.Size = new System.Drawing.Size(600, 232);
            this.dataBox.TabIndex = 2;
            this.dataBox.Text = "";
            this.dataBox.TextChanged += new System.EventHandler(this.dataBox_TextChanged);
            // 
            // signBox
            // 
            this.signBox.Location = new System.Drawing.Point(13, 15);
            this.signBox.Name = "signBox";
            this.signBox.Size = new System.Drawing.Size(144, 20);
            this.signBox.TabIndex = 3;
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(163, 13);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(75, 23);
            this.signButton.TabIndex = 4;
            this.signButton.Text = "Sign in";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(244, 18);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(16, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "...";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 324);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.signButton);
            this.Controls.Add(this.signBox);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.sendBox);
            this.Name = "ClientForm";
            this.Text = "LocalChat - Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.RichTextBox dataBox;
        private System.Windows.Forms.TextBox signBox;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Label statusLabel;
    }
}

