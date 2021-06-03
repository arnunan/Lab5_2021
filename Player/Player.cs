using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public class Player : PictureBox
    {
        public Point Destination;
        public bool IsMoving;
        public static string Turn = "player2";
        public int Hp;
        public int CellsToPass;
        public List<Point> Path;
        public Point CurrentLocation;
        public bool IsAttacking;
        int speed;
        public Player(Point initialPosition, int hp)
        {
            Location = initialPosition;
            BackColor = Color.Transparent;
            Size = new Size(Cell.SideLength, Cell.SideLength);
            Destination = initialPosition;
            IsMoving = false;
            Hp = hp;
            CellsToPass = 0;
            Path = new List<Point>();
            CurrentLocation = Location;
            IsAttacking = false;
            speed = 10;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void MovePlayer(PlayerPoints points)
        {
            if (points.IsPossibleToMove(CellsToPass) && Path.Count != 0)
            {
                var localDest = Path[0];
                    if (Location.X != localDest.X)
                    {
                        if (Location.X < localDest.X)
                            Location = new Point(Location.X + speed, Location.Y);

                        if (Location.X > localDest.X)
                            Location = new Point(Location.X - speed, Location.Y);
                    }
                    else if (Location.Y != localDest.Y)
                    {
                        if (Location.Y < localDest.Y)
                            Location = new Point(Location.X, Location.Y + speed);

                        if (Location.Y > localDest.Y)
                            Location = new Point(Location.X, Location.Y - speed);
                    }

                if (Location.X == localDest.X && Location.Y == localDest.Y)
                    Path.RemoveAt(0);
                IsMoving = true;
                if (Location.X == Destination.X && Location.Y == Destination.Y)
                {
                    IsMoving = false;
                    CurrentLocation.X = Destination.X;
                    CurrentLocation.Y = Destination.Y;
                }
            }
        }

        public Point FindPosition(Field field)
        {
            if (Draw.ObstPosition.Contains(field.FindCell(MousePosition, Location)))
                return Location;
            if (!IsMoving)
                return field.FindCell(MousePosition, Location);
            return Location;
        }

        public List<Point> FindPath(Point start, Point end, Field field)
        {
            var track = new Dictionary<Point, Point>();
            track[start] = new Point(-1000, -1000);
            var queue = new Queue<Point>();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                for (var dy = -Cell.SideLength; dy <= Cell.SideLength; dy+= Cell.SideLength)
                    for (var dx = -Cell.SideLength; dx <= Cell.SideLength; dx+= Cell.SideLength)
                    {
                        if (Math.Abs(dx) == Math.Abs(dy))
                            continue;
                        var newPoint = new Point { X = point.X + dx, Y = point.Y + dy };
                        if (newPoint.X > field.Location.X + Cell.SideLength * 9 || newPoint.X < field.Location.X ||
                            newPoint.Y > field.Location.Y + Cell.SideLength * 9 || newPoint.Y < field.Location.Y ||
                            Draw.ObstPosition.Contains(newPoint))
                            continue;
                        if (track.ContainsKey(newPoint))
                            continue;
                        track[newPoint] = point;
                        queue.Enqueue(newPoint);
                    }
                if (track.ContainsKey(end)) break;
            }
            var pathItem = end;
            var result = new List<Point>();
            while (pathItem != new Point(-1000, -1000))
            {
                result.Add(pathItem);
                if (!track.ContainsKey(pathItem))
                    return FindPath(start, end, field);
                pathItem = track[pathItem];
            }
            result.Reverse();
            return result;
        }
    }
}
