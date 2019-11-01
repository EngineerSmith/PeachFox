using System;
using System.Windows.Forms;
using System.IO;

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
            this.Disposed += new EventHandler(DisposeForm);

            // TileMap tab
            SetUpTileMapEditor();

            // Character Tab
            SetUpCharacterGraphics();
        }

        private void DisposeForm(object sender, EventArgs e)
        {
            DisposeTileMapEditor(sender, e);
            DisposeCharacterGraphics(sender, e);
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
        
        private bool ValidateFile(String path, Label hint = null)
        {
            try
            {
                if (File.Exists(path))
                {
                    if (hint != null)
                        hint.Text = "";
                    return true;
                }
                else
                {
                    if (hint != null)
                        hint.Text = "File does not exist";
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (hint != null)
                    hint.Text = "EXCEP: " + ex.Message;
                return false;
            }
        }
    }
}
