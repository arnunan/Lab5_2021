using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public class Bullet : PictureBox
    {
        public Image BulletImage;
        public bool IsMoving;
        public Point Destination;
        int speed = 10;
        public Bullet()
        {
            IsMoving = false;
            Visible = false;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void MoveBullet(Point initPosition, Point dest, Player player2, Field field)
        {
            if(IsMoving == true && !player2.IsMoving)
            {
                if (initPosition.X != dest.X && initPosition.Y == dest.Y)
                {
                    if (initPosition.X <= dest.X)
                        Location = new Point(Location.X + speed, Location.Y);
                    else
                        Location = new Point(Location.X - speed, Location.Y);
                    Visible = true;
                }

                if (initPosition.Y != dest.Y && initPosition.X == dest.X)
                {
                    if (initPosition.Y <= dest.Y)
                        Location = new Point(Location.X, Location.Y + speed);
                    else
                        Location = new Point(Location.X, Location.Y - speed);
                    Visible = true;
                }

                if (Location.X < field.Location.X || Location.X > field.Location.X + Cell.SideLength * 10 || 
                    Location.Y < field.Location.Y || Location.Y > field.Location.Y + Cell.SideLength * 10 ||
                    Draw.ObstPosition.Contains(Location))
                {
                    IsMoving = false;
                    Visible = false;
                    Location = new Point(initPosition.X, initPosition.Y);
                }
            }
        }

        public bool HasReachedEnemy(Point enemyPos, Point initPosition)
        {
            if (Location.X == enemyPos.X && Location.Y == enemyPos.Y)
            {
                IsMoving = false;
                Visible = false;
                Location = new Point(initPosition.X, initPosition.Y);
                return true;
            }
            return false;
        }
    }
}
