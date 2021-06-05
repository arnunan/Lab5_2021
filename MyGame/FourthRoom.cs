using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    public partial class FourthRoom : Form
    {
        bool isPressedAnyKey = false;
        readonly Image img, diam, Fone, Fone2;
        readonly Player player;
        readonly PictureBox diamond;
        bool fromMenu = false;
        int currentX;
        int currentY;

        public FourthRoom()
        {
            InitializeComponent();
            img = new Bitmap("C:\\Users\\79045\\Pictures\\adv_chara.png");
            Fone = new Bitmap("C:\\Users\\79045\\Pictures\\fone41.png");
            Fone2 = new Bitmap("C:\\Users\\79045\\Pictures\\fone42.png");
            diam = new Bitmap("C:\\Users\\79045\\Pictures\\qq.png");
            player = new Player(new Size(80, 160), 160, 320, img);
            this.BackgroundImage = Fone;
            this.StartPosition = FormStartPosition.CenterScreen;
            diamond = new PictureBox
            {
                Image = diam,
                BackColor = Color.Transparent,
                Location = new Point(1340, 295),
                Size = new Size(100, 100)
            };
            this.Controls.Add(diamond);
            diamond.Visible = false;

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
                if (player.Y < 470)
                    player.Down();
            }
            else if (player.currAnimation == 1)
            {
                if (player.X > 300)
                    player.Left();
            }
            else if (player.currAnimation == 0)
            {
                if (player.X < 1360)
                    player.Right();
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
            else if (e.KeyCode.ToString() == "E")
            {
                this.Hide();
                Forms.roomNumber = 4;
                fromMenu = true;
                currentX = player.X;
                currentY = player.Y;
                Forms.menu.Show();
            }
            else if (e.KeyCode.ToString() == "F" &&
                player.X > 750 && player.X < 850 && player.Y > 420)
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
                    Forms.room5.Show();
            }
            else if(e.KeyCode.ToString() == "F" && Forms.haveDiamond == true &&
                player.X > 1100 && player.Y < 200)
            {
                diamond.Visible = true;
                this.BackgroundImage = Fone2;
            }
            else if (e.KeyCode.ToString() == "F" && player.Y < 110 && 
                player.X < 850 && player.X > 750 && this.BackgroundImage == Fone2)
            {
                Forms.isWin = true;
                this.Hide();
                Forms.WinRoom.Show();
            }
            isPressedAnyKey = true;
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

        private void FourthRoom_Activated(object sender, EventArgs e)
        {
            if (fromMenu)
            {
                player.X = currentX;
                player.Y = currentY;
            }
            else
            {
                player.X = 800;
                player.Y = 450;
            }
        }
    }
}
