using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PeachFox
{
    public partial class TileEditor : Form
    {
        private float zoomFactor = 1;
        private bool zoomSet = false;
        private float translateX = 0;
        private float translateY = 0;
        private bool translateSet = false;
        private bool translate = false;
        private float translateStartX;
        private float translateStartY;
        private float currentImageX = 0;
        private float currentImageY = 0;

        Image bmp;
        private int XQuad, YQuad, WQuad, HQuad;
        private int AnimNum, AnimX, AnimY;

        private int cellSize = 16;
        private int numOfCellsX = 200;
        private int numOfCellsY = 200;

        float ratio;
        float translateRatio;

        public TileEditor()
        {
            InitializeComponent();
            this.Disposed += new EventHandler(FormDisposed);
            pictureBox.Paint += new PaintEventHandler(PictureBox_Paint);
            pictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);

            pictureBox.BorderStyle = BorderStyle.FixedSingle;

            if (checkBox1.Parent == groupBox4)
            {
                groupBox4.Parent.Controls.Add(checkBox1);
                checkBox1.Location = new Point(
                    checkBox1.Left + groupBox4.Left,
                    checkBox1.Top + groupBox4.Top);
                checkBox1.BringToFront();
            }
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Program.GetProjectForm().ProjectPath + "/assets";
            openFileDialog.Filter = "(*.png)|*.png|(*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            if (!File.Exists(openFileDialog.FileName))
                return;

            imagePath.Text = openFileDialog.FileName;
            if (bmp != null)
                bmp.Dispose();
            bmp = new Bitmap(openFileDialog.FileName);

            if (bmp.Width > bmp.Height)
            {
                ratio = (float)pictureBox.Width / (float)bmp.Width;
                translateRatio = (float)bmp.Width / (float)pictureBox.Width;
            }
            else
            {
                ratio = (float)pictureBox.Height / (float)bmp.Height;
                translateRatio = (float)bmp.Height / (float)pictureBox.Height;
            }
            if (cellSize != 0)
            {
                numOfCellsX = bmp.Width / cellSize + 1;
                numOfCellsY = bmp.Height / cellSize + 1;
            }
            else
            {
                numOfCellsX = 0; 
                numOfCellsY = 0;
            }
            
            quadW.Maximum = pictureBox.Width;
            quadH.Maximum = pictureBox.Height;
            Quad_Update(sender, e);

            Reset(sender, e);
        }

        private void Reset(object sender, EventArgs e)
        {
            zoomFactor = 1;
            zoomBox.Text = zoomFactor.ToString();
            translateX = 0;
            translateY = 0;
            translateSet = true;
            translate = false;
            currentImageX = 0;
            currentImageY = 0;

            ReDraw();
        }

        private void SetCellSize(object sender, EventArgs e)
        {
            if (radioButton0.Checked)
                cellSize = 0;
            else if (radioButton16.Checked)
                cellSize = 16;
            else if (radioButton20.Checked)
                cellSize = 20;
            else if (radioButton32.Checked)
                cellSize = 32;
            else
                cellSize = (int)numericUpDown4.Value;

            numericUpDown4.Value = cellSize;

            if (bmp != null)
            {
                if (cellSize != 0)
                {
                    numOfCellsX = (bmp.Width / cellSize) + 2;
                    numOfCellsY = (bmp.Height / cellSize) + 2;
                } 
                else
                {
                    numOfCellsX = 0; 
                    numOfCellsY = 0;
                }
            }

            quadW.Value = cellSize;
            quadH.Value = cellSize;

            ReDraw();
        }

        private void ReDraw()
        {
            zoomSet = true;
            pictureBox.Refresh();
            zoomSet = false;
        }

        private void FormDisposed(object sender, EventArgs e)
        {
            if (bmp != null)
                bmp.Dispose();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(translateSet == true)
            {
                translate = true;
                translateStartX = e.X;
                translateStartY = e.Y;
            }
        }

        private void PictureBox_MouseUp(Object sender, MouseEventArgs e)
        {
            if (translate == true)
            {
                translateX = currentImageX + ((e.X - translateStartX) * (translateRatio / zoomFactor));
                translateY = currentImageY + ((e.Y - translateStartY) * (translateRatio / zoomFactor));
            }
            pictureBox.Refresh();
            translate = false;
            currentImageX = translateX;
            currentImageY = translateY;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (bmp == null) return;
            if (translateSet == false && zoomSet == false) return;

            Graphics g = e.Graphics;

            g.ScaleTransform(ratio * zoomFactor, ratio * zoomFactor);

            g.TranslateTransform(translateX, translateY);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (bmp != null)
                g.DrawImage(bmp, 0, 0);

            Pen p = new Pen(Color.FromArgb(150, Color.DarkGray));
            for (int y = 0; y < numOfCellsY + 1; y++)
                g.DrawLine(p, 0, y * cellSize, numOfCellsX * cellSize, y * cellSize);
            for (int x = 0; x < numOfCellsX + 1; x++)
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCellsY * cellSize);
            p.Dispose();

            p = new Pen(Color.FromArgb(175, Color.Red));
            g.DrawRectangle(p, XQuad, YQuad, WQuad, HQuad);

            for(int i = 1; checkBox1.Checked && i < AnimNum; i++)
                g.DrawRectangle(p, XQuad + (AnimX * i * WQuad), YQuad + (AnimY * i * HQuad), WQuad, HQuad);

            p.Dispose();
        }

        
        private void Quad_Update(object sender, EventArgs e)
        {
            if (checkBoxCellQuad.Checked)
            {
                quadX.Maximum = numOfCellsX - 1;
                quadY.Maximum = numOfCellsY - 1;
                XQuad = (int)quadX.Value * cellSize;
                YQuad = (int)quadY.Value * cellSize;
            }
            else
            {
                quadX.Maximum = pictureBox.Width;
                quadY.Maximum = pictureBox.Height;
                XQuad = (int)quadX.Value;
                YQuad = (int)quadY.Value;
            }

            WQuad = (int)quadW.Value;
            HQuad = (int)quadH.Value;
            ReDraw();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown4.Value == cellSize)
                return;
            radioButton0.Checked = false;
            radioButton16.Checked = false;
            radioButton20.Checked = false;
            radioButton32.Checked = false;
            SetCellSize(sender, e);
        }

        private void Animation_Update(object sender, EventArgs e)
        {
            AnimNum = (int)numericUpDown3.Value;
            AnimX = (int)numericUpDown2.Value;
            AnimY = (int)numericUpDown1.Value;
            ReDraw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = checkBox1.Checked;
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            pictureBox.Cursor = Cursors.Hand;

            translateSet = true;
            zoomSet = false;
        }

        private void buttonZoom_Click(object sender, EventArgs e)
        {
            zoomFactor = (int)zoomBox.Value;

            zoomSet = true;
            pictureBox.Refresh();
            pictureBox.Cursor = Cursors.Arrow;

            buttonMove_Click(sender, e);
        }

        private void Export(object sender, EventArgs e)
        {
            Bitmap export = new Bitmap(50, 50, bmp.PixelFormat);

            try
            {
                export.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

                Graphics gExport = Graphics.FromImage(export);
                gExport.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                gExport.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gExport.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                gExport.DrawImage(bmp, new Rectangle(0, 0, 50, 50), XQuad, YQuad, WQuad, HQuad, GraphicsUnit.Pixel);

                gExport.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                export.Dispose();
                return;
            }

            TileData tile = new TileData();
            tile.fullpath = imagePath.Text;
            tile.image = export;
            tile.quad.X = XQuad;
            tile.quad.Y = YQuad;
            tile.quad.W = WQuad;
            tile.quad.H = HQuad;
            if (checkBox1.Checked)
            {
                tile.anim = new TileData.Anim();
                tile.anim.X = AnimX;
                tile.anim.Y = AnimY;
                tile.anim.Num = AnimNum;
            }

            Program.GetProjectForm().TileData = tile;
            Program.ToggleShowTileEditor();
        }
    }
}
