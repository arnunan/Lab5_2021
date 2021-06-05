﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class StartRoom : Form
    {

        bool isPressedAnyKey = false;
        readonly Image img;
        readonly Image fone;
        readonly Player player;
        bool isFirstActicated = true;
        bool fromMenu = false;
        int currentX;
        int currentY;

        public StartRoom()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            img = new Bitmap("C:\\Users\\79045\\Pictures\\adv_chara.png");
            fone = new Bitmap("C:\\Users\\79045\\Pictures\\fone.png");
            player = new Player(new Size(80, 160), 160, 320, img);
            this.BackgroundImage = fone;
            

            timer2.Interval = 50;
            timer2.Tick += new EventHandler(UpdMoment);
            timer2.Start();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
                if (player.Y > -75)
                    player.Up();
            }
            else if (player.currAnimation == 2)
            {
                if (player.Y < 470)
                    player.Down();
            }
            else if (player.currAnimation == 1)
            {
                if (player.X > 0)
                    player.Left();
            }
            else if (player.currAnimation == 0)
            {
                if (player.X < 1660)
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

        protected override void OnFormClosing(FormClosingEventArgs eventArgs)
        {
            var result = MessageBox.Show("Действительно закрыть?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                eventArgs.Cancel = true;
        }

        private void Keyboard(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.ToString() == "W")
                player.currAnimation = 3;
            else if(e.KeyCode.ToString() == "S")
                player.currAnimation = 2;
            else if (e.KeyCode.ToString() == "A")
                player.currAnimation = 1;
            else if (e.KeyCode.ToString() == "D")
                player.currAnimation = 0;
            else if (e.KeyCode.ToString() == "E")
            {
                this.Hide();
                Forms.roomNumber = 1;
                fromMenu = true;
                currentX = player.X;
                currentY = player.Y;
                Forms.menu.Show();
            }
            else if (e.KeyCode.ToString() == "F" &&
                ((player.X < 150 && player.Y < 300) || 
                 (player.X > 1510 && player.Y < 250)))
            {
                var rnd = new Random();
                var a = rnd.Next(4);
                this.Hide();
                if (a == 0)
                    Forms.room2.Show();
                else if (a == 1)
                    Forms.room3.Show();
                else if (a == 2)
                    Forms.room4.Show();
                else
                    Forms.room5.Show();
            }
            isPressedAnyKey = true;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            if (isPressedAnyKey)
            {
                if (player.currAnimation != -1 && player.currAnimation <= 4)
                    gr.DrawImage(player.SpritesAnimation, player.X, player.Y, new Rectangle(new Point(160 * player.currFrame, 360 * player.currAnimation), new Size(160, 360)), GraphicsUnit.Pixel);
            }
            else
            {
                if (player.currAnimation >= 5)
                    gr.DrawImage(player.SpritesAnimation, player.X, player.Y, new Rectangle(new Point(160 * player.currFrame, 360 * (player.currAnimation - 5)), new Size(160, 360)), GraphicsUnit.Pixel);
            }
        }

        private void StartRoom_Activated(object sender, EventArgs e)
        {
            if(isFirstActicated)
            {
                player.X = 880;
                player.Y = 220;
                isFirstActicated = false;
            }
            else
            {
                if (fromMenu)
                {
                    player.X = currentX;
                    player.Y = currentY;
                }
                else
                {
                    var rnd = new Random();
                    var a = rnd.Next(2);
                    if (a == 0)
                    {
                        player.X = 50;
                        player.Y = 100;
                    }
                    else if (a == 1)
                    {
                        player.X = 1610;
                        player.Y = -30;
                    }
                }
            }

        }
    }
}
