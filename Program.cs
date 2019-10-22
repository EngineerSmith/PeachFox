using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachFox
{
    static class Program
    {
        private static OpenProject _OpenProject = null;
        private static Project _ProjectForm = null;
        private static TileEditor _TileEditor = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _OpenProject = new OpenProject();
            Application.Run(_OpenProject);
        }

        public static void OpenProjectForm(String projectPath)
        {
            _ProjectForm = new Project(projectPath);
            _ProjectForm.Show();
            _TileEditor = new TileEditor();
            HideTileEditor();
        }

        private static bool _shown;
        public static void ToggleShowTileEditor()
        {
            if(_shown)
                _TileEditor.Hide();
            else
                _TileEditor.Show();
            _shown = !_shown;
        }

        public static void HideTileEditor()
        {
            _TileEditor.Hide();
            _shown = false;
        }

        public static void ShowOpenProjectForm()
        {
            _OpenProject.Show();
        }

        public static void CloseProjectForm()
        {
            if (_ProjectForm != null)
                _ProjectForm.Close();
            if (_TileEditor != null)
                _TileEditor.Close();
        }

        public static ref Project GetProjectForm()
        {
            return ref _ProjectForm;
        }
    }
}
