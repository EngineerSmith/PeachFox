﻿namespace PeachFox
{
    partial class TileEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imagePath = new System.Windows.Forms.TextBox();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.zoomBox = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.cellsizeGroupBox = new System.Windows.Forms.GroupBox();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.radioButton32 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.checkBoxCellQuad = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quadH = new System.Windows.Forms.NumericUpDown();
            this.quadW = new System.Windows.Forms.NumericUpDown();
            this.quadY = new System.Windows.Forms.NumericUpDown();
            this.quadX = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Zoom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBox)).BeginInit();
            this.cellsizeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quadH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quadW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quadY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quadX)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imagePath);
            this.groupBox1.Controls.Add(this.OpenFolderButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Image";
            // 
            // imagePath
            // 
            this.imagePath.Enabled = false;
            this.imagePath.Location = new System.Drawing.Point(6, 19);
            this.imagePath.Name = "imagePath";
            this.imagePath.Size = new System.Drawing.Size(142, 20);
            this.imagePath.TabIndex = 4;
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Location = new System.Drawing.Point(154, 19);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(25, 20);
            this.OpenFolderButton.TabIndex = 5;
            this.OpenFolderButton.Text = "...";
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(766, 344);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // zoomBox
            // 
            this.zoomBox.Location = new System.Drawing.Point(6, 39);
            this.zoomBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.zoomBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomBox.Name = "zoomBox";
            this.zoomBox.Size = new System.Drawing.Size(38, 20);
            this.zoomBox.TabIndex = 5;
            this.zoomBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomBox.ValueChanged += new System.EventHandler(this.buttonZoom_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Reset);
            // 
            // cellsizeGroupBox
            // 
            this.cellsizeGroupBox.Controls.Add(this.numericUpDown4);
            this.cellsizeGroupBox.Controls.Add(this.radioButton0);
            this.cellsizeGroupBox.Controls.Add(this.radioButton32);
            this.cellsizeGroupBox.Controls.Add(this.radioButton20);
            this.cellsizeGroupBox.Controls.Add(this.radioButton16);
            this.cellsizeGroupBox.Location = new System.Drawing.Point(492, 3);
            this.cellsizeGroupBox.Name = "cellsizeGroupBox";
            this.cellsizeGroupBox.Size = new System.Drawing.Size(83, 64);
            this.cellsizeGroupBox.TabIndex = 7;
            this.cellsizeGroupBox.TabStop = false;
            this.cellsizeGroupBox.Text = "CellSize";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(19, 41);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown4.TabIndex = 8;
            this.numericUpDown4.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // radioButton0
            // 
            this.radioButton0.AutoSize = true;
            this.radioButton0.Location = new System.Drawing.Point(4, 11);
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.Size = new System.Drawing.Size(31, 17);
            this.radioButton0.TabIndex = 3;
            this.radioButton0.Text = "0";
            this.radioButton0.UseVisualStyleBackColor = true;
            this.radioButton0.CheckedChanged += new System.EventHandler(this.SetCellSize);
            // 
            // radioButton32
            // 
            this.radioButton32.AutoSize = true;
            this.radioButton32.Location = new System.Drawing.Point(41, 26);
            this.radioButton32.Name = "radioButton32";
            this.radioButton32.Size = new System.Drawing.Size(37, 17);
            this.radioButton32.TabIndex = 2;
            this.radioButton32.Text = "32";
            this.radioButton32.UseVisualStyleBackColor = true;
            this.radioButton32.CheckedChanged += new System.EventHandler(this.SetCellSize);
            // 
            // radioButton20
            // 
            this.radioButton20.AutoSize = true;
            this.radioButton20.Location = new System.Drawing.Point(4, 26);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Size = new System.Drawing.Size(37, 17);
            this.radioButton20.TabIndex = 1;
            this.radioButton20.Text = "20";
            this.radioButton20.UseVisualStyleBackColor = true;
            this.radioButton20.CheckedChanged += new System.EventHandler(this.SetCellSize);
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Checked = true;
            this.radioButton16.Location = new System.Drawing.Point(41, 11);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(37, 17);
            this.radioButton16.TabIndex = 0;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "16";
            this.radioButton16.UseVisualStyleBackColor = true;
            this.radioButton16.CheckedChanged += new System.EventHandler(this.SetCellSize);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonExport);
            this.groupBox2.Controls.Add(this.checkBoxCellQuad);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.quadH);
            this.groupBox2.Controls.Add(this.quadW);
            this.groupBox2.Controls.Add(this.quadY);
            this.groupBox2.Controls.Add(this.quadX);
            this.groupBox2.Location = new System.Drawing.Point(278, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 64);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quad";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(149, 36);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(57, 23);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.Export);
            // 
            // checkBoxCellQuad
            // 
            this.checkBoxCellQuad.AutoSize = true;
            this.checkBoxCellQuad.Checked = true;
            this.checkBoxCellQuad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCellQuad.Enabled = false;
            this.checkBoxCellQuad.Location = new System.Drawing.Point(149, 18);
            this.checkBoxCellQuad.Name = "checkBoxCellQuad";
            this.checkBoxCellQuad.Size = new System.Drawing.Size(43, 17);
            this.checkBoxCellQuad.TabIndex = 6;
            this.checkBoxCellQuad.Text = "Cell";
            this.checkBoxCellQuad.UseVisualStyleBackColor = true;
            this.checkBoxCellQuad.CheckedChanged += new System.EventHandler(this.Quad_Update);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "W, H";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X, Y";
            // 
            // quadH
            // 
            this.quadH.Location = new System.Drawing.Point(64, 41);
            this.quadH.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.quadH.Name = "quadH";
            this.quadH.Size = new System.Drawing.Size(52, 20);
            this.quadH.TabIndex = 3;
            this.quadH.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.quadH.ValueChanged += new System.EventHandler(this.Quad_Update);
            // 
            // quadW
            // 
            this.quadW.Location = new System.Drawing.Point(6, 41);
            this.quadW.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.quadW.Name = "quadW";
            this.quadW.Size = new System.Drawing.Size(52, 20);
            this.quadW.TabIndex = 2;
            this.quadW.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.quadW.ValueChanged += new System.EventHandler(this.Quad_Update);
            // 
            // quadY
            // 
            this.quadY.Location = new System.Drawing.Point(64, 15);
            this.quadY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.quadY.Name = "quadY";
            this.quadY.Size = new System.Drawing.Size(52, 20);
            this.quadY.TabIndex = 1;
            this.quadY.ValueChanged += new System.EventHandler(this.Quad_Update);
            // 
            // quadX
            // 
            this.quadX.Location = new System.Drawing.Point(6, 15);
            this.quadX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.quadX.Name = "quadX";
            this.quadX.Size = new System.Drawing.Size(52, 20);
            this.quadX.TabIndex = 0;
            this.quadX.ValueChanged += new System.EventHandler(this.Quad_Update);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Zoom);
            this.groupBox3.Controls.Add(this.zoomBox);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(197, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(78, 64);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Camera";
            // 
            // Zoom
            // 
            this.Zoom.AutoSize = true;
            this.Zoom.Location = new System.Drawing.Point(44, 43);
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(34, 13);
            this.Zoom.TabIndex = 7;
            this.Zoom.Text = "Zoom";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cellsizeGroupBox);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 70);
            this.panel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.numericUpDown5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.numericUpDown3);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.numericUpDown2);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(579, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 64);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Num";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(55, 40);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.Animation_Update);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(7, 18);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown3.TabIndex = 8;
            this.numericUpDown3.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.Animation_Update);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Distance";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(7, 40);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.Animation_Update);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Animated";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 344);
            this.panel2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Dur";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 3;
            this.numericUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown5.Location = new System.Drawing.Point(85, 18);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown5.TabIndex = 11;
            this.numericUpDown5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.Animation_Update);
            // 
            // TileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 414);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TileEditor";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Tile Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBox)).EndInit();
            this.cellsizeGroupBox.ResumeLayout(false);
            this.cellsizeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quadH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quadW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quadY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quadX)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox imagePath;
        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown zoomBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox cellsizeGroupBox;
        private System.Windows.Forms.RadioButton radioButton0;
        private System.Windows.Forms.RadioButton radioButton32;
        private System.Windows.Forms.RadioButton radioButton20;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown quadH;
        private System.Windows.Forms.NumericUpDown quadW;
        private System.Windows.Forms.NumericUpDown quadY;
        private System.Windows.Forms.NumericUpDown quadX;
        private System.Windows.Forms.CheckBox checkBoxCellQuad;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Zoom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
    }
}