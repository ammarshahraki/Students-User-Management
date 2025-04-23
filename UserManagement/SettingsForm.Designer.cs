namespace UserManagement
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wwwRootTextBox = new System.Windows.Forms.TextBox();
            this.mysqlFilePathTextBox = new System.Windows.Forms.TextBox();
            this.mysqlUserTextBox = new System.Windows.Forms.TextBox();
            this.mysqlPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.studentsGroupTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.wwwRootBrowsButton = new System.Windows.Forms.Button();
            this.mysqlFileBrowsButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.defualtPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WWW Root";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "MySQL File Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "MySQL User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "MySQL Password";
            // 
            // wwwRootTextBox
            // 
            this.wwwRootTextBox.Location = new System.Drawing.Point(150, 12);
            this.wwwRootTextBox.Name = "wwwRootTextBox";
            this.wwwRootTextBox.Size = new System.Drawing.Size(145, 20);
            this.wwwRootTextBox.TabIndex = 4;
            // 
            // mysqlFilePathTextBox
            // 
            this.mysqlFilePathTextBox.Location = new System.Drawing.Point(150, 38);
            this.mysqlFilePathTextBox.Name = "mysqlFilePathTextBox";
            this.mysqlFilePathTextBox.Size = new System.Drawing.Size(145, 20);
            this.mysqlFilePathTextBox.TabIndex = 5;
            // 
            // mysqlUserTextBox
            // 
            this.mysqlUserTextBox.Location = new System.Drawing.Point(150, 64);
            this.mysqlUserTextBox.Name = "mysqlUserTextBox";
            this.mysqlUserTextBox.Size = new System.Drawing.Size(145, 20);
            this.mysqlUserTextBox.TabIndex = 6;
            // 
            // mysqlPasswordTextBox
            // 
            this.mysqlPasswordTextBox.Location = new System.Drawing.Point(150, 90);
            this.mysqlPasswordTextBox.Name = "mysqlPasswordTextBox";
            this.mysqlPasswordTextBox.Size = new System.Drawing.Size(145, 20);
            this.mysqlPasswordTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Students Group Name";
            // 
            // studentsGroupTextBox
            // 
            this.studentsGroupTextBox.Location = new System.Drawing.Point(150, 116);
            this.studentsGroupTextBox.Name = "studentsGroupTextBox";
            this.studentsGroupTextBox.Size = new System.Drawing.Size(145, 20);
            this.studentsGroupTextBox.TabIndex = 9;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(220, 177);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(301, 177);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // wwwRootBrowsButton
            // 
            this.wwwRootBrowsButton.Location = new System.Drawing.Point(301, 10);
            this.wwwRootBrowsButton.Name = "wwwRootBrowsButton";
            this.wwwRootBrowsButton.Size = new System.Drawing.Size(75, 23);
            this.wwwRootBrowsButton.TabIndex = 12;
            this.wwwRootBrowsButton.Text = "Brows";
            this.wwwRootBrowsButton.UseVisualStyleBackColor = true;
            this.wwwRootBrowsButton.Click += new System.EventHandler(this.wwwRootBrowsButton_Click);
            // 
            // mysqlFileBrowsButton
            // 
            this.mysqlFileBrowsButton.Location = new System.Drawing.Point(301, 36);
            this.mysqlFileBrowsButton.Name = "mysqlFileBrowsButton";
            this.mysqlFileBrowsButton.Size = new System.Drawing.Size(75, 23);
            this.mysqlFileBrowsButton.TabIndex = 13;
            this.mysqlFileBrowsButton.Text = "Brows";
            this.mysqlFileBrowsButton.UseVisualStyleBackColor = true;
            this.mysqlFileBrowsButton.Click += new System.EventHandler(this.mysqlFileBrowsButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Defualt Students Password";
            // 
            // defualtPasswordTextBox
            // 
            this.defualtPasswordTextBox.Location = new System.Drawing.Point(150, 142);
            this.defualtPasswordTextBox.Name = "defualtPasswordTextBox";
            this.defualtPasswordTextBox.Size = new System.Drawing.Size(145, 20);
            this.defualtPasswordTextBox.TabIndex = 15;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(388, 212);
            this.ControlBox = false;
            this.Controls.Add(this.defualtPasswordTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mysqlFileBrowsButton);
            this.Controls.Add(this.wwwRootBrowsButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.studentsGroupTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mysqlPasswordTextBox);
            this.Controls.Add(this.mysqlUserTextBox);
            this.Controls.Add(this.mysqlFilePathTextBox);
            this.Controls.Add(this.wwwRootTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox wwwRootTextBox;
        private System.Windows.Forms.TextBox mysqlFilePathTextBox;
        private System.Windows.Forms.TextBox mysqlUserTextBox;
        private System.Windows.Forms.TextBox mysqlPasswordTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox studentsGroupTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button wwwRootBrowsButton;
        private System.Windows.Forms.Button mysqlFileBrowsButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox defualtPasswordTextBox;
    }
}