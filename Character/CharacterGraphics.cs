using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using LsonLib;

namespace PeachFox
{
    public partial class Project : Form
    {
        private struct AnimationImage
        {
            public bool IsAnimated;
            public int Width, Height;
        }
        public enum AnimationCell
        {
            Name = 0, File, IsAnimated, Width, Height, Time
        }
        private Image _graphicBoxImage;
        private AnimationImage _graphicBoxAnimation;

        string AnimationFn = "Animation:New";
        string AnimationFnImport = "src/graphics/Animation";
        string ImageFn = "Image:New";
        string ImageFnImport = "src/graphics/Image";
        string GraphicsTableName = "graphics";

        private void SetUpCharacterGraphics()
        {
            characterGraphicBox.Paint += CharacterGraphicBoxPaint;
            _graphicBoxAnimation.IsAnimated = false;
        }

        private void DisposeCharacterGraphics(object sender, EventArgs e)
        {
            if( _graphicBoxImage != null)
                _graphicBoxImage.Dispose();
        }

        private void ExportTemplate(string path)
        {
            string template = $"import \"{AnimationFnImport}\"\r\n" +
                              $"import \"{ImageFnImport}\"\r\n" +
                              $"local TABLE {GraphicsTableName}\r\n" +
                              $"return {GraphicsTableName}";

            Dictionary<string, string> dictionary = new Dictionary<string, string> 
                                        { { GraphicsTableName, ConvertTableToString(dataGridView) } };
            string export = Template.FillTemplate(template, dictionary);

            File.WriteAllText(path, export);
            textBoxCharacterGraphicsFile.Text = path;
        }

        private string ConvertTableToString(DataGridView grid)
        {
            Dictionary<string, LsonValue> graphics = new Dictionary<string, LsonValue>();
            graphics.Add(GraphicsTableName, new LsonDict());

            LsonDict g = (LsonDict)graphics[GraphicsTableName];

            foreach(DataGridViewRow row in grid.Rows)
            {
                string state = GetString(row.Cells[(int)AnimationCell.Name]);
                if (state == null) continue;
                string path = GetString(row.Cells[(int)AnimationCell.File]);
                if (path == null) continue;

                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[(int)AnimationCell.IsAnimated];
                bool IsAnimated = cell.Value == cell.TrueValue;

                int width = row.Cells[(int)AnimationCell.Width].Value != null ? GetIntFromString(row.Cells[(int)AnimationCell.Width].Value.ToString()) : -1;
                int height = row.Cells[(int)AnimationCell.Height].Value != null ? GetIntFromString(row.Cells[(int)AnimationCell.Height].Value.ToString()) : -1;
                float time = row.Cells[(int)AnimationCell.Time].Value != null ? GetFloatFromString(row.Cells[(int)AnimationCell.Time].Value.ToString()) : -1;
                if (width == -1 || height == -1 || time == -1)
                    IsAnimated = false;

                //TODO Added variables for functions so they could be changed via the form 
                if (IsAnimated)
                    g[state] = new LsonFunc($"{AnimationFn}(\"{path}\", {width}, {height}, {time})");
                else
                    g[state] = new LsonFunc($"{ImageFn}(\"{path}\")");
            }
            return LsonVars.ToString(graphics).Substring(2);
        }
        private static string GetString(DataGridViewCell cell)
        {
            try
            {
                return cell.Value.ToString().Trim();
            }
            catch
            {
                return null;
            }
        }

        private void UpdateRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            // Table Update
            var row = dataGridView.Rows[e.RowIndex];
            CheckRowValidation(row);
            CheckAnimation(row);

            GraphicValidation(row);
        }

        private void GraphicValidation(DataGridViewRow row)
        {
            if (row.Cells[(int)AnimationCell.File].Value != null)
            {
                string path = ProjectPath + "/" + row.Cells[1].Value.ToString();
                if (ValidateFile(path))
                {
                    _graphicBoxImage = Bitmap.FromFile(path);
                    if (row.Cells[(int)AnimationCell.Width].Value == null)
                        row.Cells[(int)AnimationCell.Width].Value = _graphicBoxImage.Width;
                    if (row.Cells[(int)AnimationCell.Height].Value == null)
                        row.Cells[(int)AnimationCell.Height].Value = _graphicBoxImage.Height;

                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[2];
                    _graphicBoxAnimation.IsAnimated = cell.Value == cell.TrueValue;
                    _graphicBoxAnimation.Width = row.Cells[(int)AnimationCell.Width].Value != null ? GetIntFromString(row.Cells[(int)AnimationCell.Width].Value.ToString()) : -1;
                    _graphicBoxAnimation.Height = row.Cells[(int)AnimationCell.Height].Value != null ? GetIntFromString(row.Cells[(int)AnimationCell.Height].Value.ToString()) : -1;
                    if (_graphicBoxAnimation.Width == -1 || _graphicBoxAnimation.Height == -1)
                        _graphicBoxAnimation.IsAnimated = false;
                }
                else
                {
                    characterGraphicBox.Image = null;
                    _graphicBoxAnimation.IsAnimated = false;
                    if (row.Cells[(int)AnimationCell.File].Style.BackColor == Color.White)
                        row.Cells[(int)AnimationCell.File].Style.BackColor = Color.FromArgb(255, 129, 122);
                }
                characterGraphicBox.Refresh();
            }
        }

        private int GetIntFromString(string str)
        {
            if (str == null || str.Length < 0)
                return -1;
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return -1;
            }
        }

        private float GetFloatFromString(string str)
        {
            if (str == null || str.Length < 0)
                return -1;
            try
            {
                return float.Parse(str);
            }
            catch
            {
                return -1;
            }
        }

        private void CharacterGraphicBoxPaint(object sender, PaintEventArgs e)
        {
            if (_graphicBoxImage == null) 
                return;
            Graphics g = e.Graphics;

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Size imageSize = _graphicBoxImage.Size, targetSize = characterGraphicBox.Size;
            float scale = Math.Min((float)targetSize.Width / imageSize.Width,
                                   (float)targetSize.Height / imageSize.Height);
            Rectangle rect = new Rectangle
            {
                Width = (int)(scale * imageSize.Width),
                Height = (int)(scale * imageSize.Height),
                X = (int)((targetSize.Width - (scale * imageSize.Width)) / 2.0f),
                Y = (int)((targetSize.Height - (scale * imageSize.Height)) / 2.0f)
            };
            g.DrawImage(_graphicBoxImage, rect);

            if (_graphicBoxAnimation.IsAnimated == false)
                return;

            Pen p = new Pen(Color.FromArgb(150, Color.Red)) {
                Width = 2
            };
            
            Rectangle animRect = new Rectangle
            {
                X = rect.X,
                Y = rect.Y,
                Width = (int)(_graphicBoxAnimation.Width * scale),
                Height = (int)(_graphicBoxAnimation.Height * scale)
            };

            for (int width = rect.Width, i = 0; width > 0; width -= animRect.Width, i++)
            {
                animRect.X = rect.X + animRect.Width * i;
                g.DrawRectangle(p, animRect);
            }

            p.Dispose();
        }

        private void CheckRowValidation(DataGridViewRow row)
        {
            bool enable = row.Cells[(int)AnimationCell.Name].Value != null && row.Cells[(int)AnimationCell.Name].Value.ToString().Trim().Length > 0;
            if (enable)
                row.Cells[(int)AnimationCell.Name].Value = row.Cells[(int)AnimationCell.Name].Value.ToString().Trim();
            row.Cells[(int)AnimationCell.Name].Style.BackColor = enable ? Color.White : Color.FromArgb(255, 129, 122);

            for (int i = 1; i < 3; i++)
            {
                row.Cells[i].ReadOnly = !enable;
                row.Cells[i].Style.BackColor = !enable ? Color.Gray : Color.White;
            }

            if (row.Cells[(int)AnimationCell.File].Value != null)
                if (row.Cells[(int)AnimationCell.File].Value.ToString().Trim().Length > 0)
                    row.Cells[(int)AnimationCell.File].Value = row.Cells[(int)AnimationCell.File].Value.ToString().Trim();
                else if(row.Cells[(int)AnimationCell.File].Style.BackColor == Color.White)
                    row.Cells[(int)AnimationCell.File].Style.BackColor = Color.FromArgb(255, 129, 122);
        }

        private void CheckAnimation(DataGridViewRow row)
        {
            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[(int)AnimationCell.IsAnimated];
            bool enable = cell.Value == cell.TrueValue;
            for (int i = 3; i < 6; i++)
            {
                row.Cells[i].ReadOnly = !enable;
                row.Cells[i].Style.BackColor = !enable ? Color.Gray : Color.White;
            }
        }

        private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            UpdateRow(sender, e);
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = characterGraphicBox.BackColor;
            colorDialog.ShowDialog();
            characterGraphicBox.BackColor = colorDialog.Color;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var row = dataGridView.Rows[e.RowIndex];
            GraphicValidation(row);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = ProjectPath + "\\assets";
            saveFileDialog1.Filter = "(*.lua)|*.lua|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();

            ExportTemplate(saveFileDialog1.FileName);
        }
    }
}
