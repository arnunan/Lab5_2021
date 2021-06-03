using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public static class Draw
    {
        public static HashSet<Point> ObstPosition = new HashSet<Point>();
        public static void DrawGame(Field field, Graphics graphics, Player player2)
        {
            field.DrawField(graphics);
            var obstacles = new Obstacles("..\\..\\Resources\\Images\\obstacle0.png");
            var rnd = new Random();
            foreach (var c in field.cList)
            {
                if (ObstPosition.Count <= 20 && rnd.Next(4) == 3 && !ObstPosition.Contains(c) && c != field.Location && c != player2.Location
                    && c.X != field.Location.X && c.Y != field.Location.Y)
                    ObstPosition.Add(c);
                else if (ObstPosition.Count == 20)
                    break;
            }
            foreach (var o in ObstPosition)
                obstacles.DrawObstacle(o, graphics);
        }


        public static void DrawHearts(Player player, Point position, Graphics g, int maxHp)
        {
            for (int i = 0; i < player.Hp; i++)
            {
                g.DrawImage(Image.FromFile("..\\..\\Resources\\Images\\heart.png"), position);
                position.X += 50;
            }

            for (int i = 0; i < maxHp - player.Hp; i++)
            {
                g.DrawImage(Image.FromFile("..\\..\\Resources\\Images\\border.png"), position);
                position.X += 50;
            }
            
        }
    }
}
