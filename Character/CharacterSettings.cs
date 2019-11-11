using System;
using System.Collections.Generic;
using System.IO;

namespace PeachFox
{
    public partial class Project
    {
        string CharacterFn = "Character:New";
        string CharacterFnImport = "src/Character";

        private struct CharacterSettings
        {
            public string Name;
            public int Scale;
            public string GraphicFile;
            public string DefaultGraphic;
        }

        private CharacterSettings _characterSettings;

        public void ExportCharacter(string path)
        {
            string template = $"require \"{CharacterFnImport}\"\r\n" +
                              $"local character = {CharacterFn}({_characterSettings.Name}, {_characterSettings.Scale}, require(\"{_characterSettings.GraphicFile}\"))\r\n" +
                              $"character.action = \"{_characterSettings.DefaultGraphic}\"\r\n" +
                              $"return character";

            File.WriteAllText(path, template);
            textBoxCharacterSettingsFile.Text = path;
        }

        public void ValidateCharacterSettings()
        {
            _characterSettings.Name = textBoxCharacterName.Text.Trim();
            _characterSettings.Scale = (int)numericUpDownCharacterScale.Value;
            _characterSettings.GraphicFile = textBoxCharacterGraphicFile.Text.Trim();
            _characterSettings.DefaultGraphic = textBoxCharacterDefaultGraphic.Text.Trim();
        }

    }
}
