using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    class Player
    {
        public Image SpritesAnimation;
        public int X, Y;
        public Size Scale;
        public int currFrame = 2;
        public int currAnimation = 5;
        //public Image part;
        public int speed;
        public Player(Size scale, int x, int y, Image spriteAnimation)
        {
            this.Scale = scale;
            this.X = x;
            this.Y = y;
            this.SpritesAnimation = spriteAnimation;
            speed = 30;
        }

        public void Left()
        {
            X -= speed;
            //playerPic.Location = new Point(playerPic.Location.X - 1, playerPic.Location.Y);
        }

        public void Right()
        {
            X += speed;
            //playerPic.Location = new Point(playerPic.Location.X + 1, playerPic.Location.Y);
        }

        public void Up()
        {
            Y -= speed;
            //playerPic.Location = new Point(playerPic.Location.X , playerPic.Location.Y-1);
        }

        public void Down()
        {
            Y += speed;
            //playerPic.Location = new Point(playerPic.Location.X, playerPic.Location.Y+1);
        }
    }
}
