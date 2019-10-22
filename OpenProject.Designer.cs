namespace PeachFox
{
    partial class OpenProject
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
            this.label_DETAIL1 = new System.Windows.Forms.Label();
            this.ProjectPathField = new System.Windows.Forms.TextBox();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.OpenProjectButton = new System.Windows.Forms.Button();
            this.HintLabel = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label_DETAIL1
            // 
            this.label_DETAIL1.AutoSize = true;
            this.label_DETAIL1.Location = new System.Drawing.Point(9, 9);
            this.label_DETAIL1.Name = "label_DETAIL1";
            this.label_DETAIL1.Size = new System.Drawing.Size(65, 13);
            this.label_DETAIL1.TabIndex = 0;
            this.label_DETAIL1.Text = "Project Path";
            // 
            // ProjectPathField
            // 
            this.ProjectPathField.Location = new System.Drawing.Point(12, 25);
            this.ProjectPathField.Name = "ProjectPathField";
            this.ProjectPathField.Size = new System.Drawing.Size(178, 20);
            this.ProjectPathField.TabIndex = 1;
            this.ProjectPathField.TextChanged += new System.EventHandler(this.ProjectPathField_TextChanged);
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Location = new System.Drawing.Point(196, 25);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(25, 20);
            this.OpenFolderButton.TabIndex = 2;
            this.OpenFolderButton.Text = "...";
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // OpenProjectButton
            // 
            this.OpenProjectButton.Location = new System.Drawing.Point(124, 51);
            this.OpenProjectButton.Name = "OpenProjectButton";
            this.OpenProjectButton.Size = new System.Drawing.Size(98, 23);
            this.OpenProjectButton.TabIndex = 3;
            this.OpenProjectButton.Text = "Open Project";
            this.OpenProjectButton.UseVisualStyleBackColor = true;
            this.OpenProjectButton.Click += new System.EventHandler(this.OpenProjectButton_Click);
            // 
            // HintLabel
            // 
            this.HintLabel.AutoSize = true;
            this.HintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HintLabel.ForeColor = System.Drawing.Color.Maroon;
            this.HintLabel.Location = new System.Drawing.Point(9, 79);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(73, 13);
            this.HintLabel.TabIndex = 4;
            this.HintLabel.Text = "HINT TEXT";
            // 
            // OpenProject
            // 
            this.AcceptButton = this.OpenProjectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(234, 121);
            this.Controls.Add(this.HintLabel);
            this.Controls.Add(this.OpenProjectButton);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.ProjectPathField);
            this.Controls.Add(this.label_DETAIL1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 160);
            this.MinimumSize = new System.Drawing.Size(250, 160);
            this.Name = "OpenProject";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Project";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpenProject_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_DETAIL1;
        private System.Windows.Forms.TextBox ProjectPathField;
        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.Button OpenProjectButton;
        private System.Windows.Forms.Label HintLabel;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    }
}

