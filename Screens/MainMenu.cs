using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace GameProject
{
    class MainMenu : Form
    {
        Button playButton;
        Button setttingsButton;
        Button exitButton;
        Settings settings;
        MainScreen.GameForm game;
        Label title;
        public MainMenu()
        {
            DoubleBuffered = true;
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\mmBack.png");
            BackgroundImageLayout = ImageLayout.Center;

            playButton = new CustomButton(new Point(Size.Width / 2 - Convert.ToInt32((Size.Width * 0.15) / 2), Size.Height
                - Convert.ToInt32(Size.Height * 0.6)), "Играть", 25, new Size(259, 58));
            setttingsButton = new CustomButton(new Point(Size.Width / 2 - Convert.ToInt32((Size.Width * 0.15) / 2), Size.Height
                - Convert.ToInt32(Size.Height * 0.5)), "Настройки", 25, new Size(259, 58));
            exitButton = new CustomButton(new Point(Size.Width / 2 - Convert.ToInt32((Size.Width * 0.15) / 2), Size.Height
                - Convert.ToInt32(Size.Height * 0.4)), "Выход", 25, new Size(259, 58));
            title = new CustomLabel(new Point(Size.Width / 2 - Convert.ToInt32(Size.Width * 0.78125) / 2
                , Size.Height - Convert.ToInt32(Size.Height * 0.9259)), new Size(Convert.ToInt32(Size.Width * 0.78125), Convert.ToInt32(Size.Height * 0.2)),
                new Font("Bahnschrift", Convert.ToInt32(Size.Height * 0.18 * 0.65)), "Robot Fights");

            settings = new Settings("main menu", game, "Настройки");
            game = new MainScreen.GameForm();

            settings.PlayMusic("..\\..\\Resources\\Music\\musicMenu.wav", Settings.MusicEnabled);
            playButton.Click += (sender, args) =>
            {
                game.Show();
                settings.PlayMusic("..\\..\\Resources\\Music\\musicGame.wav", Settings.MusicEnabled);
            };

            setttingsButton.Click += (sender, args) =>
            {
                settings.Show();
            };

            exitButton.Click += (sender, args) =>
            {
                Application.Exit();
            };

            Controls.Add(title);
            Controls.Add(playButton);
            Controls.Add(setttingsButton);
            Controls.Add(exitButton);
        }
    }
}
