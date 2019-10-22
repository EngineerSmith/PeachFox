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
    public partial class OpenProject : Form
    {
        private String _ProjectPath = "";
        public OpenProject()
        {
            InitializeComponent();
            HintLabel.Text = "";
            OpenProjectButton.Enabled = false;
        }

        private void ProjectPathField_TextChanged(object sender, EventArgs e)
        {
            ValidatePath(ProjectPathField.Text);
        }
        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.ShowDialog();
            ValidatePath(FolderBrowserDialog.SelectedPath);
        }
        private void ValidatePath(String path)
        {
            try
            {
                path = Path.GetFullPath(path);
                if (Directory.Exists(path))
                {
                    ProjectPathField.Text = path;
                    _ProjectPath = path;
                    HintLabel.Text = "";
                    OpenProjectButton.Enabled = true;
                }
                else
                {
                    HintLabel.Text = "Invalid Path";
                    OpenProjectButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                HintLabel.Text = "EXCEP: " + ex.Message;
                OpenProjectButton.Enabled = false;
                return;
            }
        }

        private void OpenProjectButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.OpenProjectForm(_ProjectPath);
        }

        private void OpenProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CloseProjectForm();
        }
    }
}
