using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public class Obstacles
    {
        Image obstacle;
        public Obstacles(string src)
        {
            obstacle = Image.FromFile(src);
        }

        public void DrawObstacle(Point location, Graphics graphics)
        {
            graphics.DrawImage(obstacle, new Rectangle(location, new Size(Cell.SideLength, Cell.SideLength)));
        }
    }
}
