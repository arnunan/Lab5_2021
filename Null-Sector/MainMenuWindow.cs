using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using User;

namespace Null_Sector
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        #region Play Button
        private void playButton_Click(object sender, EventArgs e)
        {
            if (UserSettings.File == null)
            {
                CreateNewSaveFile();
            }

            Game game = new Game();
            game.Show();
            Hide();
        }

        public static void CreateNewSaveFile()
        {
            DirectoryInfo dir = new DirectoryInfo(SystemFiles.SaveFilesFolder);
            var saveFiles = dir.GetFiles("save*.save");

            int n = -1;

            if (saveFiles.Length != 0)
                n = saveFiles
                .Max(f => int.Parse(f.Name[4].ToString()));

            byte[] p = new byte[SaveFile.ParametersLengthInBytes];
            p[5] = 100;

            UserSettings.File =
                new SaveFile($"save{n + 1}", p, Map.GenerateNewMap());
        }

        private void playButton_Enter(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/play1.png");
        }
        
        private void playButton_Leave(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/play0.png");
        }
        #endregion

        #region Load Button
        private void loadButton_Click(object sender, EventArgs e)
        {
            var answer = SaveFileLoader.ShowDialog();
            switch (answer)
            {
                case DialogResult.OK:
                    UserSettings.File = new SaveFile(SaveFileLoader.FileName);
                    break;
            }
        }

        private void loadButton_Enter(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/load1.png");
        }

        private void loadButton_Leave(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/load0.png");
        }
        #endregion

        #region Settings Button
        private void settingsButton_Click(object sender, EventArgs e)
        {
            var settings = new SettingsWindow();
            settings.ShowDialog();
        }

        private void settingsButton_Enter(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/settings1.png");
        }

        private void settingsButton_Leave(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/settings0.png");
        }
        #endregion

        #region Exit Button
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void exitButton_Enter(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox) sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/exit1.png");
        }

        public void exitButton_Leave(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/exit0.png");
        }
        #endregion
    }
}
