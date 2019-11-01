using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace PeachFox
{
    public partial class Project : Form
    {
        private string _tileMapFilepath;
        private TileMap _tileMap;

        private TileData _tileData;

        private List<List<Tuple<Button, TileButtonData>>> Squares;

        private Dictionary<int, Dictionary<int, Tile>> _tiles;
        private int XOffset = 0, YOffset = 0;

        public TileData TileData
        {
            get => _tileData;
            set
            {
                _tileData = value;
                if (value != null)
                {
                    if (_tileData.shortpath == null && _tileData.fullpath.Length != 0)
                    {
                        int i = _tileData.fullpath.IndexOf(ProjectPath);
                        if (i != -1)
                        {
                            _tileData.shortpath = _tileData.fullpath.Substring(i + ProjectPath.Length + 1);
                            _tileData.shortpath = _tileData.shortpath.Replace("\\", "/");
                        }
                    }
                }
                UpdateTileButton();
            }
        }

        private void SetUpTileMapEditor()
        {
            EnableTileMap(false);
            HintLabel.Text = "";
        }

        private void GenerateEditor()
        {
            if (_tileMap == null)
                return;
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
                    ResetButton(Squares[i][j].Item1);
                    Squares[i][j].Item2.Clean();

                    int posY = j + YOffset;
                    int posX = i + XOffset;
                    if (_tiles.ContainsKey(posX) == false) continue;
                    if (_tiles[posX].ContainsKey(posY) == false) continue;

                    Tile tile = _tiles[posX][posY];
                    // Background
                    SetImage(Squares[i][j].Item2.Background, tinyImages, images, i, j, tile.Background);
                    // Foreground
                    SetImage(Squares[i][j].Item2.Foreground, tinyImages, images, i, j, tile.Foreground);
                    // Colliable
                    if (tile.Physics.Colliable && checkBox1.Checked)
                        Squares[i][j].Item1.FlatAppearance.BorderColor = Color.Red;
                    else
                        Squares[i][j].Item1.FlatAppearance.BorderColor = Color.LightGray;
                }
            }

            foreach (var image in images)
                image.Value.Dispose();

            Refresh();
        }

        private void SetImage(SortedDictionary<int, Bitmap> SquareImage, Dictionary<string, Dictionary<TileData.Quad, Bitmap>> tinyImages, Dictionary<string, Bitmap> images, int i, int j, LsonLib.LsonDict imageDict)
        {
            foreach (var kvp in imageDict)
            {
                TileGraphic graphics = (TileGraphic)kvp.Value;
                string file = ProjectPath + "\\" + graphics.File;
                if (File.Exists(file))
                {
                    TileData.Quad quad;
                    quad.X = graphics.Quad.X;
                    quad.Y = graphics.Quad.Y;
                    quad.W = graphics.Quad.Width;
                    quad.H = graphics.Quad.Height;
                    if (tinyImages.ContainsKey(file) == false)
                        tinyImages.Add(file, new Dictionary<TileData.Quad, Bitmap>());
                    if (tinyImages[file].ContainsKey(quad) == false)
                        LoadImage(tinyImages, images, i, j, file, quad);
                    SquareImage.Set(kvp.Key.GetInt(), tinyImages[file][quad]);
                }
            }
        }

        private void LoadImage(Dictionary<string, Dictionary<TileData.Quad, Bitmap>> tinyImages, Dictionary<string, Bitmap> images, int i, int j, string file, TileData.Quad quad)
        {
            if (images.ContainsKey(file) == false)
                images.Add(file, new Bitmap(file));
            Bitmap bmp = images[file];
            Bitmap export = new Bitmap(Squares[i][j].Item1.Width, Squares[i][j].Item1.Height, bmp.PixelFormat);
            export.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            Graphics gExport = System.Drawing.Graphics.FromImage(export);
            gExport.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            gExport.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            gExport.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            gExport.DrawImage(bmp, new Rectangle(0, 0, Squares[i][j].Item1.Width, Squares[i][j].Item1.Height), quad.X, quad.Y, quad.W, quad.H, GraphicsUnit.Pixel);
            gExport.Dispose();
            tinyImages[file].Add(quad, export);
        }

        private void SetUpButtons()
        {
            const int squareSize = 50;
            int width = panelEditor.Size.Width / squareSize;
            int height = panelEditor.Size.Height / squareSize;
            Squares = new List<List<Tuple<Button, TileButtonData>>>();
            for (int w = 0; w < width; w++)
            {
                Squares.Add(new List<Tuple<Button, TileButtonData>>(height));
                for (int h = 0; h < height; h++)
                {
                    Squares[w].Add(new Tuple<Button, TileButtonData>(new Button {
                        Location = new Point(3 + squareSize * w, 3 + squareSize * h),
                        Name = w + "." + h,
                        Size = new Size(squareSize, squareSize),
                        TabIndex = 2,
                        UseVisualStyleBackColor = true,
                        Image = null,
                        BackgroundImage = null,
                        BackgroundImageLayout = ImageLayout.Zoom,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        FlatStyle = FlatStyle.Flat,
                    }, new TileButtonData()));
                    Squares[w][h].Item1.Click += new EventHandler(this.TileButtonClick);
                    Squares[w][h].Item1.MouseEnter += new EventHandler(this.ButtonOnEnter);
                    Squares[w][h].Item1.MouseLeave += new EventHandler(this.ButtonOnLeave);
                    Squares[w][h].Item1.Paint += new PaintEventHandler(this.TileButtonPaint);
                    Squares[w][h].Item1.FlatAppearance.BorderSize = 2;
                    Squares[w][h].Item1.FlatAppearance.BorderColor = Color.LightGray;
                    panelEditor.Controls.Add(Squares[w][h].Item1);
                }
            }
        }

        private void ButtonOnEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GetData(button).IsHovered = true;
            labelDetails.Text = "";

            Tuple<int, int> tilePos = GetTileFromButton(button);
            if (_tiles.ContainsKey(tilePos.Item1) == false)
                return;
            if (_tiles[tilePos.Item1].ContainsKey(tilePos.Item2) == false)
                return;
            labelDetails.Text += "Bg:\n";
            foreach (var kvp in _tiles[tilePos.Item1][tilePos.Item2].Background)
            {
                string path = ((TileGraphic)kvp.Value).File;
                labelDetails.Text += $"{(int)kvp.Key}: {path.Substring(path.LastIndexOf('/') + 1)}\n";
            }
            labelDetails.Text += "Fg:\n";
            foreach (var kvp in _tiles[tilePos.Item1][tilePos.Item2].Foreground)
            {
                string path = ((TileGraphic)kvp.Value).File;
                labelDetails.Text += $"{(int)kvp.Key}: {path.Substring(path.LastIndexOf('/') + 1)}\n";
            }
        }

        private void ButtonOnLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GetData(button).IsHovered = false;
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
            TileButtonData data = GetData(button);

            Tuple<int, int> tilePos = GetTileFromButton(button);
            if (_tiles.ContainsKey(tilePos.Item1) == false)
                _tiles.Add(tilePos.Item1, new Dictionary<int, Tile>());
            if (_tiles[tilePos.Item1].ContainsKey(tilePos.Item2) == false)
                _tiles[tilePos.Item1].Add(tilePos.Item2, new Tile());

            _tiles[tilePos.Item1][tilePos.Item2].Physics.Colliable = checkBoxColliable.Checked;
            if (checkBoxColliable.Checked && checkBox1.Checked)
                button.FlatAppearance.BorderColor = Color.Red;
            else
                button.FlatAppearance.BorderColor = Color.LightGray;

            TileGraphic tileGraphic = new TileGraphic();
            tileGraphic.File = _tileData.shortpath;
            tileGraphic.Quad.X = _tileData.quad.X;
            tileGraphic.Quad.Y = _tileData.quad.Y;
            tileGraphic.Quad.Width = _tileData.quad.W;
            tileGraphic.Quad.Height = _tileData.quad.H;
            if (_tileData.anim != null)
                tileGraphic.Animation = new Animation(_tileData.anim.X, _tileData.anim.Y, _tileData.anim.Num);

            if (checkBoxGround.Checked)
            {
                data.Foreground.Set((int)layerNum.Value, _tileData.image);
                _tiles[tilePos.Item1][tilePos.Item2].Foreground.Set((int)layerNum.Value, tileGraphic);
            }
            else
            {
                data.Background.Set((int)layerNum.Value, _tileData.image);
                _tiles[tilePos.Item1][tilePos.Item2].Background.Set((int)layerNum.Value, tileGraphic);
            }

            button.Refresh();
        }
        private Tuple<int, int> GetTileFromButton(Button button)
        {
            for (int i = 0; i < Squares.Count; i++)
                for (int j = 0; j < Squares[i].Count; j++)
                    if (Squares[i][j].Item1.Name == button.Name)
                        return new Tuple<int, int>(i + XOffset, j + YOffset);
            return null;
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            EnableTileMap(false);
            openFileDialog1.InitialDirectory = ProjectPath + "\\assets";
            openFileDialog1.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            tilemapPath.Text = openFileDialog1.FileName;
            if (ValidateFile(tilemapPath.Text, HintLabel))
            {
                _tileMapFilepath = tilemapPath.Text;
                try
                {
                    _tileMap = new TileMap(_tileMapFilepath);
                }
                catch (Exception ex) { HintLabel.Text = "EXCEP: " + ex.Message; return; }
                EnableTileMap(true);
                SetupTileMap();
                GenerateEditor();
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
                }
                catch (Exception ex) { HintLabel.Text = "EXCEP: " + ex.Message; return; }
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
            if (checkBox1.Checked)
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
                            Squares[i][j].Item1.FlatAppearance.BorderColor = Color.Red;
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
                            Squares[i][j].Item1.FlatAppearance.BorderColor = Color.LightGray;
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
            YOffset--;
            PaintTiles();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            XOffset++;
            PaintTiles();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            XOffset--;
            PaintTiles();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            YOffset++;
            PaintTiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tileMap.Map = _tiles;

            saveFileDialog1.InitialDirectory = ProjectPath + "\\assets";
            saveFileDialog1.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();

            File.WriteAllText(saveFileDialog1.FileName, _tileMap.String());
            tilemapPath.Text = saveFileDialog1.FileName;
        }

        private TileButtonData GetData(Button button)
        {
            for (int i = 0; i < Squares.Count; i++)
                for (int j = 0; j < Squares[i].Count; j++)
                    if (Squares[i][j].Item1.Name == button.Name)
                        return Squares[i][j].Item2;
            return null;
        }

        private void checkBoxDraw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDraw.CheckState == CheckState.Indeterminate)
                checkBoxDraw.Text = "Show All";
            else if (checkBoxDraw.CheckState == CheckState.Checked)
                checkBoxDraw.Text = "Show Foreground";
            else if (checkBoxDraw.CheckState == CheckState.Unchecked)
                checkBoxDraw.Text = "Show Background";
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XOffset = 0;
            YOffset = 0;
            PaintTiles();
        }

        private Pen TilePen_Red = new Pen(Color.Red) { Width = 2};
        private Pen TilePen_LightGrey = new Pen(Color.FromArgb(150, Color.LightGray));

        private void TileButtonPaint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            TileButtonData data = GetData(button);
            if (data == null) 
                return;

            Graphics g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            
            CheckState state = checkBoxDraw.CheckState;
            if (state == CheckState.Unchecked || state == CheckState.Indeterminate)
            {
                foreach (var bg in data.Background)
                    g.DrawImage(bg.Value, 0, 0);
            }
            if (state == CheckState.Checked || state == CheckState.Indeterminate)
            {
                foreach (var fg in data.Foreground)
                    g.DrawImage(fg.Value, new Rectangle(5, 5, 40, 40), 0, 0, 50, 50, GraphicsUnit.Pixel);
            }
            if (button.FlatAppearance.BorderColor == Color.Red)
            {
                g.DrawLine(TilePen_Red, 0, 0, 50, 50);
                g.DrawLine(TilePen_Red, 0, 50, 50, 0);
            }

            if (data.IsHovered)
            {
                g.FillRectangle(TilePen_LightGrey.Brush, 0, 0, 50, 50);
            }
        }

        private void DisposeTileMapEditor(object sender, EventArgs e)
        {
            TilePen_Red.Dispose();
            TilePen_LightGrey.Dispose();
        }
    }
}
