using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;

namespace GameProject
{
    public static class MainScreen
    {
        public class GameForm : Form
        {
            Field field;
            Player player1;
            Player player2;
            PlayerPoints points;
            Button refreshPointsButton;
            Label cellLabel;
            Bullet bullet;
            Button setButton;
            Graphics g;
            Settings settings;
            Label player1Hp;
            Label player2Hp;
            Label turn;
            Button howToPlay;
            public GameForm()
            {
                DoubleBuffered = true;
                Size = Screen.PrimaryScreen.WorkingArea.Size;
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
                BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\preview.png");
                BackgroundImageLayout = ImageLayout.Center;
                field = new Field(new Point(Size.Width / 2 - Cell.SideLength * 5, Size.Height / 2 - Cell.SideLength * 5));
                player1 = new Player(field.Location, 5);
                player2 = new Player(new Point(field.Location.X + Cell.SideLength * 9, field.Location.Y + Cell.SideLength * 9), 4);
                points = new PlayerPoints(new Point(field.Location.X + Cell.SideLength * 10 + Cell.SideLength / 2, Convert.ToInt32(Size.Height * 0.3)), 
                    new Size(Convert.ToInt32(Size.Width * 0.23), Convert.ToInt32(Size.Height * 0.0468)));
                settings = new Settings("game", this, "Пауза");
                g = CreateGraphics();

                bullet = new Bullet()
                {
                    Size = new Size(Convert.ToInt32(Size.Width * 0.055), Convert.ToInt32(Size.Width * 0.055)),
                    BackColor = Color.Transparent
                };

                player1Hp = new CustomLabel(new Point(0, field.Location.Y), new Size(Convert.ToInt32(Size.Width * 0.4), 
                    Convert.ToInt32(Size.Height * 0.03)),
                    new Font("Bahnschrift", 14), "Здоровье оранжевого робота");

                player2Hp = new CustomLabel(new Point(field.Location.X + Cell.SideLength * 10 + Cell.SideLength / 2,
                    field.Location.Y), new Size(Convert.ToInt32(Size.Width * 0.3), Convert.ToInt32(Size.Height * 0.03)), new Font("Bahnschrift", 14),
                    "Здоровье серого робота");

                turn = new CustomLabel(new Point(0, Convert.ToInt32(Size.Height * 0.4)), new Size(Convert.ToInt32(Size.Width * 0.3), 
                    Convert.ToInt32(Size.Height * 0.05)),
                    new Font("Bahnschrift", 20), "Ход серого робота");

                refreshPointsButton = new CustomButton(new Point(field.Location.X + Cell.SideLength * 10 + Cell.SideLength / 2,
                    Convert.ToInt32(Size.Height * 0.4)), "Завершить ход", 14, new Size(259, 58));

                setButton = new Button()
                {
                    Size = new Size(95,95),
                    Location = new Point(0, Size.Height - Convert.ToInt32(Size.Height * 0.113)),
                    BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\CellBig_01.png"),
                    Image = Image.FromFile("..\\..\\Resources\\Images\\07.png"),
                    BackColor = Color.Black
                };
                setButton.FlatAppearance.BorderSize = 0;
                setButton.FlatStyle = FlatStyle.Flat;

                howToPlay = new Button()
                {
                    Size = new Size(95, 95),
                    Location = new Point(Size.Width - 110, Size.Height - Convert.ToInt32(Size.Height * 0.113)),
                    BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\CellBig_01.png"),
                    BackColor = Color.Black,
                    Text = "?",
                    Font = new Font("Bahnschrift", 40)
                };
                howToPlay.FlatAppearance.BorderSize = 0;
                howToPlay.FlatStyle = FlatStyle.Flat;

                
                cellLabel = new Label()
                {
                    Font = new Font("Bahnschrift", Convert.ToInt32(Size.Height * 0.02)),
                    Size = new Size(Convert.ToInt32(Size.Width * 0.05), Convert.ToInt32(Size.Height * 0.031)),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black
                };

                Paint += (sender, args) =>
                {
                    Graphics g = args.Graphics;
                    Draw.DrawGame(field, g, player2);
                    
                    if (Player.Turn == "player1")
                    {
                        UpdateCell(player1, field, field.FindCell(MousePosition, player1.Location), cellLabel, g, points);
                        turn.Text = "Ход оранжевого робота";
                    }
                        
                    else
                    {
                        UpdateCell(player2, field, field.FindCell(MousePosition, player2.Location), cellLabel, g, points);
                        turn.Text = "Ход серого робота";
                    }
                    Draw.DrawHearts(player1, new Point(0, field.Location.Y + Cell.SideLength / 2), g, 5);
                    Draw.DrawHearts(player2, new Point(field.Location.X + Cell.SideLength * 10 + Cell.SideLength / 2,
                        field.Location.Y + Cell.SideLength / 2), g,4);
                };
                
                Movement();
                PlayAnimation();
                ButtonFunctions();

                Controls.Add(refreshPointsButton);
                Controls.Add(player1);
                Controls.Add(player2);
                Controls.Add(bullet);
                Controls.Add(points);
                Controls.Add(cellLabel);
                Controls.Add(setButton);
                Controls.Add(player1Hp);
                Controls.Add(player2Hp);
                Controls.Add(turn);
                Controls.Add(howToPlay);
                

                Timer checkWinTimer = new Timer();
                checkWinTimer.Interval = 20;
                checkWinTimer.Tick += (sender, args) =>
                {
                    if (player1.Hp == 0)
                    {
                        checkWinTimer.Stop();
                        var winScreen = new Settings("win", this, "Серый робот победил!");
                        winScreen.Show();
                    }

                    if (player2.Hp == 0)
                    {
                        checkWinTimer.Stop();
                        var winScreen = new Settings("win", this, "Оранжевый робот победил!");
                        winScreen.Show();
                    }
                };
                checkWinTimer.Start();
            }

            public void Movement()
            {
                Timer moveTimer = new Timer();
                moveTimer.Interval = 30;
                moveTimer.Tick += (sender, args) =>
                {
                    if (Player.Turn == "player1")
                        player1.MovePlayer(points); 
                    else
                    {
                        player2.MovePlayer(points);
                        AttackOfPlayer2(player2.Location, bullet.Destination, bullet);
                    }
                    if (bullet.HasReachedEnemy(player1.Location, player2.Location))
                        player1.Hp--;
                };
                moveTimer.Start();
                MouseClick += (sender, args) =>
                {
                    if (args.Button == MouseButtons.Left)
                    {
                        if (points.count > 0)
                        {
                            if (Player.Turn == "player1" && !player1.IsMoving)
                            {
                                player1.Destination = player1.FindPosition(field);
                                player1.Path = player1.FindPath(player1.Location, player1.Destination, field);
                                player1.CellsToPass = player1.Path.Count - 1;
                                points.UpdatePoints(player1.CellsToPass);
                            }

                            else if (Player.Turn == "player2" && !player2.IsMoving)
                            {
                                player2.Destination = player2.FindPosition(field);
                                player2.Path = player2.FindPath(player2.Location, player2.Destination, field);
                                player2.CellsToPass = player2.Path.Count - 1;
                                points.UpdatePoints(player2.CellsToPass);
                            }
                        }

                    }

                    else if (args.Button == MouseButtons.Right && !player2.IsMoving)
                    {
                        if(points.count >= 2 && Player.Turn == "player2")
                        {
                            Attack2(sender, args);
                            Draw.DrawHearts(player1, new Point(0, field.Location.Y + Cell.SideLength / 2), g,5);
                        }
                    }  
                };
                player1.MouseClick += new MouseEventHandler(Attack2);
                player2.MouseClick += new MouseEventHandler(Attack1);
            }

            public void PlayAnimation()
            {
                var anim = new Animation();
                Timer timer = new Timer();
                timer.Interval = 100;
                timer.Tick += (sender, args) =>
                {
                    if (player1.IsMoving)
                    {
                        anim.PlayMovingAnimationPlayer1(player1);    
                    }
                    else if(!player1.IsMoving)
                    {
                        anim.PlayStaticAnimationPlayer1(player1);
                    }
                    anim.PlayAnimationPlayer2(player2);
                    if(player2.IsAttacking)
                        anim.PlayAttackAnimationPlayer2(player2);

                    if(player1.IsAttacking)
                        anim.PlayAttackAnimationPlayer1(player1);
                };
                
                timer.Start();
            }

            public void AttackOfPlayer2(Point initPos, Point dest, Bullet bullet)
            {
                bullet.MoveBullet(initPos, dest, player2, field);
                Draw.DrawHearts(player1, new Point(0, field.Location.Y + Cell.SideLength / 2), g,5);
            }

            public static void UpdateCell(Player player, Field field, Point position, Label label, Graphics g, PlayerPoints points)
            {
                if(Draw.ObstPosition.Count != 0)
                {
                    var dest = player.FindPosition(field);
                    if (dest != player.Location)
                    {
                        var amountOfCells = player.FindPath(player.Location, dest, field).Count - 1;
                        if (!Draw.ObstPosition.Contains(field.FindCell(MousePosition, player.Location)))
                        {
                            label.Text = amountOfCells.ToString();
                            label.Location = position;
                        }
                        if (amountOfCells > points.count || Draw.ObstPosition.Contains(field.FindCell(MousePosition, player.Location)))
                            Cell.DrawCell(Cell.SideLength, field.FindCell(MousePosition, player.Location), g, Color.Red);
                        else
                            Cell.DrawCell(Cell.SideLength, field.FindCell(MousePosition, player.Location), g, Color.Green);
                    }
                }
            }

            public void Attack1(object sender, EventArgs e)
            {
                AttackOfPlayer1(player1.Location, player2.Location);
                Draw.DrawHearts(player2, new Point(field.Location.X + Cell.SideLength * 10 + Cell.SideLength / 2, field.Location.Y + Cell.SideLength / 2), g,4);
            }

            public void Attack2(object sender, EventArgs e)
            {
                bullet.Location = new Point(player2.Location.X, player2.Location.Y);
                bullet.Destination = field.FindCell(MousePosition, player2.Location);
                if(((bullet.Location.X != bullet.Destination.X && bullet.Location.Y == bullet.Destination.Y) ||
                    (bullet.Location.Y != bullet.Destination.Y && bullet.Location.X == bullet.Destination.X)) && points.count >= 2
                    && Player.Turn == "player2" && !bullet.IsMoving)
                {
                    bullet.IsMoving = true;
                    if (bullet.Location.X > bullet.Destination.X)
                        bullet.Image = Image.FromFile("..\\..\\Resources\\Images\\bullet_left.png");
                    if (bullet.Location.X < bullet.Destination.X)
                        bullet.Image = Image.FromFile("..\\..\\Resources\\Images\\bullet_right.png");
                    if (bullet.Location.Y > bullet.Destination.Y)
                        bullet.Image = Image.FromFile("..\\..\\Resources\\Images\\bullet_up.png");
                    if (bullet.Location.Y < bullet.Destination.Y)
                        bullet.Image = Image.FromFile("..\\..\\Resources\\Images\\bullet_down.png");
                    player2.IsAttacking = true;
                    points.UpdatePoints(2);
                }
            }

            public void AttackOfPlayer1(Point player1Pos, Point player2Pos)
            {
                if ((((player1Pos.X + Cell.SideLength == player2Pos.X || player1Pos.X - Cell.SideLength == player2Pos.X) 
                    && player1Pos.Y  == player2Pos.Y) || ((player1Pos.Y - Cell.SideLength == player2Pos.Y 
                    || player1Pos.Y + Cell.SideLength == player2Pos.Y) 
                    && player1Pos.X == player2Pos.X))
                    && points.count >= 3)
                {
                    player1.IsAttacking = true;
                    player2.Hp--;
                    points.UpdatePoints(3);
                }

            }

            void ButtonFunctions()
            {

                refreshPointsButton.MouseClick += (sender, args) =>
                {
                    points.UpdatePoints();
                    if (Player.Turn == "player1")
                        Player.Turn = "player2";
                    else
                        Player.Turn = "player1";
                };

                howToPlay.MouseEnter += (sender, args) =>
                {
                    howToPlay.BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\CellBig_02.png");
                    howToPlay.BackColor = Color.Black;
                };

                howToPlay.MouseLeave += (sender, args) =>
                {
                    howToPlay.BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\CellBig_01.png");
                };

                howToPlay.Click += (sender, args) =>
                {
                    new Settings("how to play", this, "Как играть").Show();
                };

                setButton.MouseEnter += (sender, args) =>
                {
                    setButton.BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\CellBig_02.png");
                    setButton.BackColor = Color.Black;
                };

                setButton.MouseLeave += (sender, args) =>
                {
                    setButton.BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\CellBig_01.png");
                };

                setButton.Click += (sender, args) =>
                {
                    settings.Show();
                };
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams handleParam = base.CreateParams;
                    handleParam.ExStyle |= 0x02000000;       
                    return handleParam;
                }
            }

        }
    }
}
