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

        private void Project_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ShowOpenProjectForm();
            Program.HideTileEditor();
        }

        private void Project_Resize(object sender, EventArgs e)
        {
            SetUpEditor();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ShowOpenProjectForm();
            this.Hide();
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
    }
}
