using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public class Cell
    {
        static Size size;
        public static int SideLength { get; }
        static Cell()
        {
            size = Screen.PrimaryScreen.WorkingArea.Size;
            SideLength = ((int)(size.Width * 0.00521)) * 10;
        }

        public static void DrawCell(int sideLength, Point location, Graphics graphics, Color color)
        {
            graphics.DrawRectangle(new Pen(color, 2), new Rectangle(location, new Size(sideLength, sideLength)));
        }
    }
}
