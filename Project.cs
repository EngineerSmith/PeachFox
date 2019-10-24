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
using System.Text.RegularExpressions;

namespace PeachFox
{
    public partial class Project : Form
    {
        private string _projectPath;
        public string ProjectPath { get => _projectPath; }
        private string _tileMapFilepath;
        private TileMap _tileMap;

        private TileData _tileData;

        private List<List<Button>> Squares;
        private Dictionary<int, Dictionary<int, Tile>> _tiles;
        private int XOffset = 0, YOffset = 0;

        public TileData TileData
        {
            get => _tileData;
            set
            {
                if (_tileData != null)
                    _tileData.Dispose();
                _tileData = value;
                if(_tileData.shortpath == null && _tileData.fullpath.Length != 0)
                {
                    int i = _tileData.fullpath.IndexOf(_projectPath);
                    if (i != -1)
                    {
                        _tileData.shortpath = _tileData.fullpath.Substring(i + _projectPath.Length + 1);
                        _tileData.shortpath = _tileData.shortpath.Replace("\\", "/");
                    }
                }
                UpdateTileButton();
            }
        }        

        public Project(String projectPath)
        {
            _projectPath = projectPath;

            InitializeComponent();
            this.Disposed += new EventHandler(FormDisposed);

            // TileMap tab
            EnableTileMap(false);
            HintLabel.Text = "";
        }

        private void FormDisposed(object sender, EventArgs e)
        {
            if (_tileData != null)
                _tileData.Dispose();
        }
        private void SetUpEditor()
        {
            SetUpButtons();
            _tiles = _tileMap.Map;
            PaintTiles();
        }

        private void PaintTiles()
        {
            Dictionary<string, Dictionary<TileData.Quad, Bitmap>> tinyImages = new Dictionary<string, Dictionary<TileData.Quad, Bitmap>>();
            Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>();
            for (int i = 0; i < Squares.Count; i++)
            {
                for (int j = 0; j < Squares[i].Count; j++)
                {
                    ResetButton(Squares[i][j]);
                    int posY = j + YOffset;
                    int posX = i + XOffset;
                    if (_tiles.ContainsKey(posX) == false) continue;
                    if (_tiles[posX].ContainsKey(posY) == false) continue;

                    Tile tile = _tiles[posX][posY];
                    // Background
                    string file = _projectPath + "\\" + tile.Background.File;
                    if (File.Exists(file))
                    {
                        TileData.Quad quad;
                        quad.X = tile.Background.Quad.X;
                        quad.Y = tile.Background.Quad.Y;
                        quad.W = tile.Background.Quad.Width;
                        quad.H = tile.Background.Quad.Height;
                        if (tinyImages.ContainsKey(file) == false)
                            tinyImages.Add(file, new Dictionary<TileData.Quad, Bitmap>());
                        if (tinyImages[file].ContainsKey(quad) == false)
                        {
                            //Load image
                            if (images.ContainsKey(file) == false)
                                images.Add(file, new Bitmap(file));
                            Bitmap bmp = images[file];
                            Bitmap export = new Bitmap(Squares[i][j].Width, Squares[i][j].Height, bmp.PixelFormat);
                            export.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

                            Graphics gExport = System.Drawing.Graphics.FromImage(export);
                            gExport.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                            gExport.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                            gExport.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                            gExport.DrawImage(bmp, new Rectangle(0, 0, Squares[i][j].Width, Squares[i][j].Height), quad.X, quad.Y, quad.W, quad.H, GraphicsUnit.Pixel);
                            gExport.Dispose();
                            tinyImages[file].Add(quad, export);
                        }
                        Squares[i][j].BackgroundImage = tinyImages[file][quad];
                    }
                    // Foreground
                    file = _projectPath + "\\" + tile.Foreground.File;
                    if (File.Exists(file))
                    {
                        TileData.Quad quad;
                        quad.X = tile.Foreground.Quad.X;
                        quad.Y = tile.Foreground.Quad.Y;
                        quad.W = tile.Foreground.Quad.Width;
                        quad.H = tile.Foreground.Quad.Height;
                        if (tinyImages.ContainsKey(file) == false)
                            tinyImages.Add(file, new Dictionary<TileData.Quad, Bitmap>());
                        if (tinyImages[file].ContainsKey(quad) == false)
                        {
                            //Load image
                            if (images.ContainsKey(file) == false)
                                images.Add(file, new Bitmap(file));
                            Bitmap bmp = images[file];
                            Bitmap export = new Bitmap(Squares[i][j].Width, Squares[i][j].Height, bmp.PixelFormat);
                            export.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

                            Graphics gExport = System.Drawing.Graphics.FromImage(export);
                            gExport.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                            gExport.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                            gExport.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                            gExport.DrawImage(bmp, new Rectangle(10, 10, Squares[i][j].Width - 20, Squares[i][j].Height - 20), quad.X, quad.Y, quad.W, quad.H, GraphicsUnit.Pixel);
                            gExport.Dispose();
                            tinyImages[file].Add(quad, export);
                        }
                        Squares[i][j].Image = tinyImages[file][quad];

                        if (tile.Physics.Colliable && checkBox1.Checked)
                            Squares[i][j].FlatAppearance.BorderColor = Color.Red;
                        else
                            Squares[i][j].FlatAppearance.BorderColor = Color.LightGray;
                    }
                }
            }

            foreach (var image in images)
                image.Value.Dispose();

            Refresh();
        }        
        private void SetUpButtons()
        {
            const int squareSize = 50;
            int width = panelEditor.Size.Width / squareSize;
            int height = panelEditor.Size.Height / squareSize;
            Squares = new List<List<Button>>();
            for (int w = 0; w < width; w++)
            {
                Squares.Add(new List<Button>(height));
                for (int h = 0; h < height; h++)
                {
                    Squares[w].Add(new Button());
                    panelEditor.Controls.Add(Squares[w][h]);
                    Squares[w][h].Location = new System.Drawing.Point(3 + squareSize * w, 3 + squareSize * h);
                    Squares[w][h].Name = w + "." + h;
                    Squares[w][h].Size = new System.Drawing.Size(squareSize, squareSize);
                    Squares[w][h].TabIndex = 2;
                    Squares[w][h].UseVisualStyleBackColor = true;
                    Squares[w][h].Click += new EventHandler(this.TileButtonClick);
                    Squares[w][h].Paint += new PaintEventHandler(this.TileButtonPaint);
                    Squares[w][h].BackgroundImage = null;
                    Squares[w][h].BackgroundImageLayout = ImageLayout.Zoom;
                    Squares[w][h].ImageAlign = ContentAlignment.MiddleCenter;
                    Squares[w][h].FlatStyle = FlatStyle.Flat;
                    Squares[w][h].FlatAppearance.BorderSize = 2;
                    Squares[w][h].FlatAppearance.BorderColor = Color.LightGray;
                }
            }

        }
        private void ResetButton(Button button)
        {
            button.BackgroundImage = null;
            button.Image = null;
            button.FlatAppearance.BorderColor = Color.LightGray;
        }
        
        private void TileButtonClick(object sender, EventArgs e)
        {
            if (_tileData == null) 
                return;
            Button button = (Button)sender;

            Tuple<int, int> tilePos = GetTileFromButton(button);
            if (_tiles.ContainsKey(tilePos.Item1) == false)
                _tiles.Add(tilePos.Item1, new Dictionary<int, Tile>());
            if (_tiles[tilePos.Item1].ContainsKey(tilePos.Item2) == false)
                _tiles[tilePos.Item1].Add(tilePos.Item2, new Tile());

            _tiles[tilePos.Item1][tilePos.Item2].Physics.Colliable = checkBoxColliable.Checked;
            if(checkBoxColliable.Checked && checkBox1.Checked)
                button.FlatAppearance.BorderColor = Color.Red;
            else
                button.FlatAppearance.BorderColor = Color.LightGray;

            if (checkBoxGround.Checked)
            {
                Bitmap bmp = new Bitmap(_tileData.fullpath);
                Bitmap export = new Bitmap(button.Width, button.Height, bmp.PixelFormat);
                export.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

                Graphics gExport = System.Drawing.Graphics.FromImage(export);
                gExport.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                gExport.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gExport.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                gExport.DrawImage(bmp, new Rectangle(10, 10, button.Width - 20, button.Height - 20), _tileData.quad.X, _tileData.quad.Y, _tileData.quad.W, _tileData.quad.H, GraphicsUnit.Pixel);
                gExport.Dispose();
                bmp.Dispose();

                button.Image = export;
                _tiles[tilePos.Item1][tilePos.Item2].Foreground.File = _tileData.shortpath;
                _tiles[tilePos.Item1][tilePos.Item2].Foreground.Quad.X = _tileData.quad.X;
                _tiles[tilePos.Item1][tilePos.Item2].Foreground.Quad.Y = _tileData.quad.Y;
                _tiles[tilePos.Item1][tilePos.Item2].Foreground.Quad.Width = _tileData.quad.W;
                _tiles[tilePos.Item1][tilePos.Item2].Foreground.Quad.Height = _tileData.quad.H;
            }
            else
            {
                button.BackgroundImage = _tileData.image;
                _tiles[tilePos.Item1][tilePos.Item2].Background.File = _tileData.shortpath;
                _tiles[tilePos.Item1][tilePos.Item2].Background.Quad.X = _tileData.quad.X;
                _tiles[tilePos.Item1][tilePos.Item2].Background.Quad.Y = _tileData.quad.Y;
                _tiles[tilePos.Item1][tilePos.Item2].Background.Quad.Width = _tileData.quad.W;
                _tiles[tilePos.Item1][tilePos.Item2].Background.Quad.Height = _tileData.quad.H;
            }

            button.Refresh();
        }
        private Tuple<int, int> GetTileFromButton(Button button)
        {
            for (int i = 0; i < Squares.Count; i++)
                for (int j = 0; j < Squares[i].Count; j++)
                    if (Squares[i][j].Name == button.Name)
                        return new Tuple<int, int>(i + XOffset, j + YOffset);
            return null; 
        }

        private void Project_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ShowOpenProjectForm();
            Program.HideTileEditor();
        }
        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ShowOpenProjectForm();
            this.Hide();
        }
        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            EnableTileMap(false);
            openFileDialog1.InitialDirectory = _projectPath + "\\assets";
            openFileDialog1.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            tilemapPath.Text = openFileDialog1.FileName;
            if (ValidateFile(tilemapPath.Text, HintLabel))
            {
                _tileMapFilepath = tilemapPath.Text;
                try
                {
                    _tileMap = new TileMap(_tileMapFilepath);
                } catch (Exception ex) { HintLabel.Text = "EXCEP: " + ex.Message; return; }
                EnableTileMap(true);
                SetupTileMap();
                SetUpEditor();
            }
        }
        private bool ValidateFile(String path, Label hint)
        {
            try
            {
                if (File.Exists(path))
                {
                    hint.Text = "";
                    return true;
                }
                else
                {
                    hint.Text = "File does not exist";
                    return false;
                }
            }
            catch (Exception ex)
            {
                hint.Text = "EXCEP: " + ex.Message;
                return false;
            }
        }
        private void EnableTileMap(bool enable)
        {
            if (enable)
            {
                tabEditor.Show();
            }
            else
            {
                tabEditor.Hide();
            }
            groupBox1.Enabled = enable;
            groupBox2.Enabled = enable;
        }
        private void tilemapPath_TextChanged(object sender, EventArgs e)
        {
            EnableTileMap(false);
            if (ValidateFile(tilemapPath.Text, HintLabel))
            {
                _tileMapFilepath = tilemapPath.Text;
                try
                {
                    _tileMap = new TileMap(_tileMapFilepath);
                } catch (Exception ex) { HintLabel.Text = "EXCEP: " + ex.Message; return; }
                EnableTileMap(true);
                SetupTileMap();
            }
        }
        private void SetupTileMap()
        {
            SetGraphicsData(_tileMap.GraphicsData);
            textBox1.Text = _tileMap.ActiveMap;
        }
        private void SetGraphicsData(GraphicsData data)
        {
            numericUpDownWidth.Value = data.Width;
            numericUpDownHeight.Value = data.Height;
            numericUpDownScale.Value = data.Scale;
        }
        private void SaveGraphicsData(object sender, EventArgs e)
        {
            _tileMap.GraphicsData = new GraphicsData(
                (int)numericUpDownWidth.Value, 
                (int)numericUpDownHeight.Value, 
                (int)numericUpDownScale.Value
            );
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _tileMap.RenameMap(_tileMap.ActiveMap, textBox1.Text);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void Project_Resize(object sender, EventArgs e)
        {
            SetUpEditor();
        }
        private void Texture_Click(object sender, EventArgs e)
        {
            Program.ToggleShowTileEditor();
        }
        private void UpdateTileButton()
        {
            Texture.BackgroundImage = _tileData.image;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                for (int i = 0; i < Squares.Count; i++)
                {
                    int posX = i + XOffset;
                    if (_tiles.ContainsKey(posX) == false) 
                        continue;
                    for (int j = 0; j < Squares[i].Count; j++)
                    {
                        int posY = j + YOffset;
                        if (_tiles[posX].ContainsKey(posY) == false) 
                            continue;
                        if (_tiles[posX][posY].Physics.Colliable)
                            Squares[i][j].FlatAppearance.BorderColor = Color.Red;
                    }
                }
            else
                for (int i = 0; i < Squares.Count; i++)
                {
                    int posX = i + XOffset;
                    if (_tiles.ContainsKey(posX) == false) 
                        continue;
                    for (int j = 0; j < Squares[i].Count; j++)
                    {
                        int posY = j + YOffset;
                        if (_tiles[posX].ContainsKey(posY) == false) 
                            continue;
                        if (_tiles[posX][posY].Physics.Colliable)
                            Squares[i][j].FlatAppearance.BorderColor = Color.LightGray;
                    }
                }
            this.Refresh();
        }

        private void checkBoxGround_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGround.Checked)
                checkBoxGround.Text = "Foreground";
            else
                checkBoxGround.Text = "Background";
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            YOffset++;
            PaintTiles();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            XOffset--;
            PaintTiles();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            XOffset++;
            PaintTiles();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            YOffset--;
            PaintTiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tileMap.Map = _tiles;

            saveFileDialog1.InitialDirectory = _projectPath + "\\assets";
            saveFileDialog1.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();

            File.WriteAllText(saveFileDialog1.FileName, _tileMap.String());
            tilemapPath.Text = saveFileDialog1.FileName;
        }

        private void TileButtonPaint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            if (button.ForeColor != Color.Red) return;
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.FromArgb(150, Color.Red));
            g.FillRectangle(p.Brush, new Rectangle(0,0,button.Width,button.Height));

            p.Dispose();
        }
    }
}
