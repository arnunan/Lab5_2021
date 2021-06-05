using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FivethRoom : Form
    {
        bool isPressedAnyKey = false;
        readonly Image Fone, img, ghost, diam;
        readonly Label replics, answ1, answ2;
        readonly Player player;
        bool fromMenu = false;
        bool flag = true;
        int currentX, currentY, scene;
        readonly PictureBox enemy, diamond;
        public FivethRoom()
        {
            InitializeComponent();
            img = new Bitmap("C:\\Users\\79045\\Pictures\\adv_chara.png");
            Fone = new Bitmap("C:\\Users\\79045\\Pictures\\fone5.png");
            ghost = new Bitmap("C:\\Users\\79045\\Pictures\\ghost.png");
            diam = new Bitmap("C:\\Users\\79045\\Pictures\\qq.png"); 
            player = new Player(new Size(80, 160), 160, 320, img);
            enemy = new PictureBox
            {
                Image = ghost,
                BackColor = Color.Transparent,
                Location = new Point(1300, 150),
                Size = new Size(450, 450)
            };
            diamond = new PictureBox
            {
                Image = diam,
                BackColor = Color.Transparent,
                Location = new Point(1700, 800),
                Size = new Size(100, 100)
            };
            replics = new Label()
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                ForeColor = SystemColors.ControlText,
                Location = new Point(800, 30),
                Size = new Size(1000, 100),
                Font = new Font("Perpetua Titling MT", 18F, FontStyle.Bold, GraphicsUnit.Point),
                Text = "ПРИЗРАК: Ты попал в мои владения! Не подходи близко, а то пожалеешь!"
            };
            answ1 = new Label()
            {
                Text = " Q: 23C",
                Location = new Point(750, 920),
                Size = new Size(250, 50),
                BackColor = Color.White,
                ForeColor = SystemColors.ControlText,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point)
        };
            answ2 = new Label()
            {
                Text = " R: 2312",
                Location = new Point(1050, 920),
                Size = new Size(250, 50),
                BackColor = Color.White,
                ForeColor = SystemColors.ControlText,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point)            
            };
            scene = 1;
            this.Controls.Add(enemy);
            this.Controls.Add(diamond);
            this.Controls.Add(replics);
            this.BackgroundImage = Fone;
            this.StartPosition = FormStartPosition.CenterScreen;

            timer2.Interval = 50;
            timer2.Tick += new EventHandler(UpdMoment);
            timer2.Start();

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;

            this.KeyDown += new KeyEventHandler(Keyboard);
            this.KeyUp += new KeyEventHandler(FreeKey);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void UpdMoment(object sender, EventArgs e)
        {
            if (player.currAnimation == 3)
            {
                if (player.Y > -70)
                    player.Up();
            }
            else if (player.currAnimation == 2)
            {
                if ((player.Y < 470 && player.X > 1300) || (player.X < 1300 && player.Y < 110))
                    player.Down();
            }
            else if (player.currAnimation == 1)
            {
                if ((player.X > 0 && player.Y < 120) || (player.X > 1350))
                    player.Left();
            }
            else if (player.currAnimation == 0)
            {
                if (player.X < 1660)
                {
                    player.Right();
                    
                }
            }
            this.Invalidate();
        }

        private void FreeKey(object sender, KeyEventArgs e)
        {
            isPressedAnyKey = false;
            if (e.KeyCode.ToString() == "W")
                player.currAnimation = 8;
            else if (e.KeyCode.ToString() == "S")
                player.currAnimation = 7;
            else if (e.KeyCode.ToString() == "A")
                player.currAnimation = 6;
            else if (e.KeyCode.ToString() == "D")
                player.currAnimation = 5;
            player.currFrame = 0;
        }

        private void Update(object sender, EventArgs e)
        {
            if (isPressedAnyKey)
            {
                timer1.Interval = 150;
                if (player.currFrame == 11)
                    player.currFrame = 2;
            }
            else
            {
                timer2.Interval = 25;
                if (player.currFrame == 2)
                    player.currFrame = 0;
                Check(ref scene, player, replics, answ1, answ2, flag);
            }
            player.currFrame++;
            Invalidate();
        }

        private void Keyboard(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "W")
                player.currAnimation = 3;
            else if (e.KeyCode.ToString() == "S")
                player.currAnimation = 2;
            else if (e.KeyCode.ToString() == "A")
                player.currAnimation = 1;
            else if (e.KeyCode.ToString() == "D")
                player.currAnimation = 0;
            else if (e.KeyCode.ToString() == "Q")
            {
                replics.Text = "Ты молодец! забирай свой приз! [нажмите F чтобы продолжить]";
                this.Controls.Remove(answ1);
                this.Controls.Remove(answ2);
                scene = 3;
            }
            else if (e.KeyCode.ToString() == "R")
            {
                Forms.isWin = false;
                this.Hide();
                Forms.loseWin.Show();
            }
            else if (e.KeyCode.ToString() == "E")
            {
                this.Hide();
                Forms.roomNumber = 5;
                fromMenu = true;
                currentX = player.X;
                currentY = player.Y;
                Forms.menu.Show();
            }
            else if (e.KeyCode.ToString() == "F" &&
                (player.X < 150))
            {
                var rnd = new Random();
                var a = rnd.Next(4);
                this.Hide();
                if (a == 0)
                    Forms.room1.Show();
                else if (a == 1)
                    Forms.room2.Show();
                else if (a == 2)
                    Forms.room3.Show();
                else
                    Forms.room4.Show();
            }
            else if (e.KeyCode.ToString() == "F" && player.X > 1000 && player.X < 1200 && flag)
            {
                scene = 2;
                flag = false;
            }
            else if (e.KeyCode.ToString() == "F" && scene == 3)
            {
                scene = 4;
                this.Controls.Remove(enemy);
                this.Controls.Remove(replics);
            }
            else if (e.KeyCode.ToString() == "F" && scene == 4 && player.X > 1200 && player.Y > 300)
            {
                this.Controls.Remove(diamond);
                Forms.haveDiamond = true;
            }
            isPressedAnyKey = true;
        }

        private void F5_Activated(object sender, EventArgs e)
        {
            if (fromMenu)
            {
                player.X = currentX;
                player.Y = currentY;
            }
            else
            {
                player.X = 20;
                player.Y = 110;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (isPressedAnyKey)
            {
                if (player.currAnimation != -1 && player.currAnimation <= 4)
                    g.DrawImage(player.SpritesAnimation, player.X, player.Y, new Rectangle(new Point(160 * player.currFrame, 360 * player.currAnimation), new Size(160, 360)), GraphicsUnit.Pixel);
            }
            else
            {
                if (player.currAnimation >= 5)
                    g.DrawImage(player.SpritesAnimation, player.X, player.Y, new Rectangle(new Point(160 * player.currFrame, 360 * (player.currAnimation - 5)), new Size(160, 360)), GraphicsUnit.Pixel);
            }
        }

        private static void Check(ref int scene, Player player, Label text, Label a1, Label a2, bool flag)
        {
            if (player.X > 1200 && flag)
            {
                Forms.isWin = false;
                Forms.room5.Hide();
                Forms.loseWin.Show();
            }
            else
            {
                if (scene == 1 && player.X < 1200 && player.X > 1000)
                {
                    text.Location = new Point(700, 800);
                    text.Size = new Size(1000, 150);
                    text.Text = "ПРИЗРАК: А ты смельчак! Думаю, ты хочешь забрать этот алмаз." +
                         " Ты получишь его, если отгадаешь мою загадку... [нажмите F чтобы продолжить]";
                }
                else if (scene == 2)
                {
                    text.Size = new Size(900, 100);
                    text.Text = "Чему равно десятичное число 572 в 16-ричной СС?" +
                        "[Нажмите соответствующую клавишу Q или R]";
                    Forms.room5.Controls.Add(a1);
                    Forms.room5.Controls.Add(a2);
                }
            }
        }
    }
}
