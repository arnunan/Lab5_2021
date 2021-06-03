using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace GameProject
{
    public class Settings : Form
    {
        public Button BackButton;
        Label setPicture;
        public PictureBox MusicPicture;
        Label musicLabel;
        public static bool MusicEnabled;
        SoundPlayer music;
        Button exitButton;
        Button reloadButton;
        public Settings(string from, MainScreen.GameForm main, string title)
        {
            DoubleBuffered = true;
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\mmBack.png");
            BackgroundImageLayout = ImageLayout.Center;
            MusicEnabled = false;
            music = new SoundPlayer();
            MusicPicture = new PictureBox()
            {
                Location = new Point(Size.Width / 2 - Convert.ToInt32(Size.Width * 0.1), Size.Height
                - Convert.ToInt32(Size.Height * 0.65)),
                Image = Image.FromFile("..\\..\\Resources\\Images\\Checked_02.png"),
                Size = new Size(Convert.ToInt32(Size.Width * 0.031), Convert.ToInt32(Size.Width * 0.031)),
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            musicLabel = new CustomLabel(new Point(Size.Width / 2 - Convert.ToInt32(Size.Width * 0.065), Size.Height
                - Convert.ToInt32(Size.Height * 0.65)), new Size(Convert.ToInt32(Size.Width * 0.5), Convert.ToInt32(Size.Height * 0.057)),
                new Font("Bahnschrift", Convert.ToInt32(Size.Height * 0.03)), "Включить музыку");

            setPicture = new CustomLabel(new Point(Size.Width / 2 - Convert.ToInt32(Size.Width * 0.78125) / 2
                , Size.Height - Convert.ToInt32(Size.Height * 0.9259)), new Size(Size.Width, Convert.ToInt32(Size.Height * 0.2)),
                new Font("Bahnschrift", 50), title);

            BackButton = new CustomButton(new Point(Size.Width / 2 - Convert.ToInt32((Size.Width * 0.15) / 2), Size.Height
                - Convert.ToInt32(Size.Height * 0.55)), "Назад", 25, new Size(259, 58));

            reloadButton = new CustomButton(new Point(Size.Width / 2 - Convert.ToInt32((Size.Width * 0.15) / 2), Size.Height
                - Convert.ToInt32(Size.Height * 0.45)), "Начать игру заново", 14, new Size(259, 58));

            exitButton = new CustomButton(new Point(Size.Width / 2 - Convert.ToInt32((Size.Width * 0.15) / 2), Size.Height
                - Convert.ToInt32(Size.Height * 0.35)), "Выйти из игры", 17, new Size(259, 58));

            exitButton.Click += (sender, args) =>
            {
                Application.Exit();
            };

            reloadButton.Click += (sender, args) =>
            {
                Draw.ObstPosition = new HashSet<Point>();
                new MainScreen.GameForm().Show();
                main.Close();
                Close();
            };

            BackButton.Click += (sender, args) =>
            {
                Hide();
            };

            MusicPicture.Click += (sender, args) =>
            {
                if (MusicEnabled)
                {
                    MusicEnabled = false;
                    MusicPicture.Image = Image.FromFile("..\\..\\Resources\\Images\\Checked_02.png");
                }

                else
                {
                    MusicEnabled = true;
                    MusicPicture.Image = Image.FromFile("..\\..\\Resources\\Images\\Checked_01.png");
                }

                if(from == "main menu")
                    PlayMusic("..\\..\\Resources\\Music\\musicMenu.wav", MusicEnabled);
                else
                    PlayMusic("..\\..\\Resources\\Music\\musicGame.wav", MusicEnabled);
            };
            if (from == "game")
            {
                Controls.Add(exitButton);
                Controls.Add(reloadButton);
                Controls.Add(MusicPicture);
                Controls.Add(BackButton);
                Controls.Add(musicLabel);
            }
            else if (from == "main menu")
            {
                Controls.Add(MusicPicture);
                Controls.Add(BackButton);
                Controls.Add(musicLabel);
            }
            else if (from == "win")
            {
                Controls.Add(exitButton);
                Controls.Add(reloadButton);
            }

            else if (from == "how to play")
            {
                setPicture.Location = new Point(0, 0);
                BackButton.Location = new Point(Size.Width / 2 - Convert.ToInt32((Size.Width * 0.15) / 2), Size.Height
                - Convert.ToInt32(Size.Height * 0.35));
                Controls.Add(BackButton);
                Controls.Add(new PictureBox()
                {
                    Image = Image.FromFile("..\\..\\Resources\\Images\\Обучение1.png"),
                    Size = new Size(Convert.ToInt32(Size.Width / 2), Convert.ToInt32(Size.Height / 2)),
                    Location = new Point(Size.Width - Convert.ToInt32(Width / 1.8), Convert.ToInt32(Size.Height / 2) - Height / 2),

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent
                });

                Controls.Add(new CustomLabel(new Point(0, Convert.ToInt32(Size.Height / 2) - Height / 3),
                    new Size(Convert.ToInt32(Size.Width / 1.5), Convert.ToInt32(Size.Height / 1.5)), new Font("Bahnschrift", Convert.ToInt32(Size.Width * 0.0098)),
                    @"- На прохождение одной клетки тратится одно очко хода.
Для передвижения нажмите левой кнопкой мыши 
на любую клетку.

- Оранжевый робот может атаковать, если стоит на 
соседней с серым роботом клетке 
(кроме диагональных клеток).
Стоимость атаки - 3 очка.
Для атаки нужно нажать на изображение
противника.

- Серый робот может сделать выстрел в любом
направлении (кроме диагонали).
Пуля не проходит сквозь препятствия и игрока.
Стоимость атаки - 2 очка.
Для атаки нажмите на любую клетку правой
кнопкой мыши.

- Игра заканчивается, когда у одного из роботов
не остается здоровья."));
            }
            Controls.Add(setPicture);
        }

        public void PlayMusic(string path, bool isEnabled)
        {
            music.SoundLocation = path;
            if (isEnabled)
            {
                music.PlayLooping();
            }
            else
                music.Stop();
        }
    }
}

