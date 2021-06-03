using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace GameProject
{
    public class PlayerPoints : Label
    {
        public int count = 10;
        public int temporalCount = 10;
        public PlayerPoints(Point location, Size size)
        {
            Location = location;
            Text = "Количество очков: " + count.ToString();
            Font = new Font("Bahnschrift", 18);
            Size = size;
            BackColor = Color.Transparent;
            ForeColor = Color.Orange;
        }

        public bool IsPossibleToMove(int cellCount)
        {
            if (cellCount <= temporalCount)
                return true;
            return false;
        }

        public void UpdatePoints(int cellsToPass)
        {
            if (IsPossibleToMove(cellsToPass))
            {
                temporalCount = count;
                if (count - cellsToPass >= 0)
                    count-=cellsToPass;
                Text = "Количество очков: " + count.ToString();
                Invalidate();
            }
        }

        public void UpdatePoints()
        {
            count = 10;
            temporalCount = 10;
            Text = "Количество очков: " + count.ToString();
        }
    }
}
