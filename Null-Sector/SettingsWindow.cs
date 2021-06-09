using System;
using System.Drawing;
using System.Windows.Forms;
using User;

namespace Null_Sector
{
    public partial class SettingsWindow : Form
    {
        public const int VolumePerMark = 4;
        public const int PixelsPerMark = 12;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        #region Quieter Music
        private void musicQuieter_Click(object sender, EventArgs e)
        {
            UserSettings.MusicVolume--;
            if (UserSettings.MusicVolume != 0)
                ChangeSliderPosition(GetCountOfPixelsForVolumeChange(UserSettings.MusicVolume, false));
        }

        private void musicQuieter_Enter(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/minus1.png");
        }

        private void musicQuieter_Leave(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/minus0.png");
        }
        #endregion

        #region Louder Music
        private void musicLouder_Click(object sender, EventArgs e)
        {
            UserSettings.MusicVolume++;
            if (UserSettings.MusicVolume != 100)
                ChangeSliderPosition(GetCountOfPixelsForVolumeChange(UserSettings.MusicVolume, true));
        }

        private void musicLouder_Enter(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/plus1.png");
        }

        private void musicLouder_Leave(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/plus0.png");
        }
        #endregion

        #region Back Button
        private void backButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void backButton_Enter(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox) sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/back1.png");
        }

        private void backButton_Leave(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox) sender;
            button.Image = Image.FromFile(SystemFiles.PropertiesFolder + "Sprites/menu/back0.png");
        }
        #endregion

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            int volume = UserSettings.MusicVolume / VolumePerMark; // get integer part of division
            int extraPart = UserSettings.MusicVolume - volume * VolumePerMark; // get the "extra" part of volume

            int addPixels = 0;
            switch (extraPart)
            {
                case 0:
                    addPixels = 0;
                    break;
                case 1:
                    addPixels = 2;
                    break;
                case 2:
                case 3:
                    addPixels = 4;
                    break;
            }

            ChangeSliderPosition(volume * PixelsPerMark + addPixels);
        }

        private void ChangeSliderPosition(int dx) => Slider.Location = new Point(Slider.Location.X + dx, Slider.Location.Y);

        private int GetCountOfPixelsForVolumeChange(int volume, bool isGreater)
        {
            int extraPart = (isGreater ? 1 : -1) * (volume - (volume / VolumePerMark + (isGreater ? 0 : 1)) * VolumePerMark) % 4;
            return (isGreater ? 1 : -1) * (extraPart == 1 || extraPart == 0 ? 2 : 4);
        }
    }
}
