using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_invaders_project
{
    public partial class HardLevel : Form
    {
        bool goLeft, goRight;
        int playerSpeed = 12;
        int enemySpeed = 5;
        int score = 0;
        int enemyBulletTimer = 300;
        int x = 1;
        PictureBox[] invadersArray;

        bool shooting;
        bool isGameOver;

        public HardLevel(int x)
        {
            InitializeComponent();
            this.x = x;
            gameSetup();
        }

        private void mainGameTimerHard(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if (goLeft)
            {
                player.Left -= playerSpeed;
            }
            if (goRight)
            {
                player.Left += playerSpeed;
            }

            enemyBulletTimer -= 10;

            if (enemyBulletTimer < 1)
            {
                enemyBulletTimer = 300;
                makeBullet("invadersBullet");
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "invaders")
                {
                    x.Left += enemySpeed;
                    x.BringToFront();
                    if (x.Left > 730)
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        gameOver("Ты не успел сдать работу и завалил сессию. Здравствуй небо в облаках...");
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                score += 1;
                                shooting = false;
                            }
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20;

                    if (x.Top < 15)
                    {
                        this.Controls.Remove(x);
                        shooting = false;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "invadersBullet")
                {
                    x.Top += 20;

                    if (x.Top > 630)
                    {
                        this.Controls.Remove(x);
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(x);
                        gameOver(" Ты нахватался долгов и в скором времени будешь отчислен!");
                    }
                }
            }

            if (score >= 8)
            {
                enemySpeed = 12;
            }

            if (score == invadersArray.Length)
            {
                gameOver("Победа!! Ты смог сдать сессию в игре, значит сдашь и в жизни!!)");
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        public void makeInvaders()
        {
            invadersArray = new PictureBox[x];
            
            int left = 0;

            for (int i = 0; i < invadersArray.Length; i++)
            {
                invadersArray[i] = new PictureBox();
                invadersArray[i].Size = new Size(60, 50);
                invadersArray[i].Image = Properties.Resources.free_printable_labels_005;
                invadersArray[i].Top = 5;
                invadersArray[i].Tag = "invaders";
                invadersArray[i].Left = left;
                invadersArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(invadersArray[i]);
                left = left - 80;
            }

        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = true;
                makeBullet("bullet");
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                removeAll();
                gameSetup();
            }
        }

        private void gameSetup()
        {
            txtScore.Text = "Score: 0";
            score = 0;
            isGameOver = false;

            enemyBulletTimer = 300;
            enemySpeed = 5;
            shooting = false;

            makeInvaders();
            gameTimer.Start();
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();

            txtScore.Text = "Score: " + score + " " + message;
        }

        private void removeAll()
        {
            foreach (PictureBox i in invadersArray)
            {
                this.Controls.Remove(i);
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "bullet" || (string)x.Tag == "invadersBullet")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }

      
        private void makeBullet(string bulletTag)
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.c_users_anhar_ali_appdata_local_microsoft_windows_2;
            bullet.Size = new Size(5, 20);
            bullet.Tag = bulletTag;
            bullet.Left = player.Left + player.Width / 2;

            if ((string)bullet.Tag == "bullet")
            {
                bullet.Top = player.Top - 40;
            }
            else if ((string)bullet.Tag == "invadersBullet")
            {
                bullet.Top = -20;
            }
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
    }
}
