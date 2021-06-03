using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public class Field
    {
        int size;
        public HashSet<Point> cList;
        SolidBrush SolidBrush;
        public Point Location { get; }

        public Field(Point location)
        {
            size = 10;
            Location = location;
            cList = new HashSet<Point>();
            SolidBrush = new SolidBrush(Color.Gray);
        }

        public void DrawField(Graphics graphics)
        {
            var rnd = new Random();
            var x = Location.X;
            var y = Location.Y;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    
                    Cell.DrawCell(Cell.SideLength, new Point(x, y), graphics, Color.Black);
                    graphics.FillRectangle(SolidBrush, new Rectangle(new Point(x, y), new Size(Cell.SideLength, Cell.SideLength)));
                    cList.Add(new Point(x,y));
                    x += Cell.SideLength;
                }
                y += Cell.SideLength;
                x = Location.X;
            }
        }

        public Point FindCell(Point mousePosition, Point playerPosition)
        {
            foreach (var cell in cList)
                if (cell.X <= mousePosition.X && cell.X + Cell.SideLength >= mousePosition.X
                    && cell.Y <= mousePosition.Y - 10 && cell.Y + Cell.SideLength >= mousePosition.Y - 10)
                    return cell;
            return playerPosition;
        }
    }
}
