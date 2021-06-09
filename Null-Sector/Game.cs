using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Events;
using User;

namespace Null_Sector
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public partial class Game : Form
    {
        private static readonly Queue<IEvent> GameEvents = new Queue<IEvent>();
        private static IEvent _currentEvent;

        public static Control.ControlCollection GameForm;
        public static bool IsGameOver = false;

        public Game()
        {
            InitializeComponent();
            Terminal.TerminalBox = TerminalWindow;
            GameField.Field = FieldWindow;
            GameField.Tiles = UserSettings.Map().TileMap;

            GameEvents.Enqueue(new TradeEvent("Trade1", SystemFiles.EventsFilesFolder + "Trade.txt"));
            GameForm = Controls.FindChild<TableLayoutPanel>(new[] {"Table"}).Controls;
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Game_Load(object sender, EventArgs e)
        {
            MessageBox.Show(SystemFiles.WelcomeText, SystemFiles.WelcomeCaption, MessageBoxButtons.OK);

            GameField.LoadField();
            Terminal.Welcome();

            var resources = Controls.FindChild<FlowLayoutPanel>(new[] { "Table", "ResourcePanel" });

            Character.MetalCount =
                resources.Controls.FindChild<Label>(new[] {"Metal", "mCount"});
            Character.ElectronicsCount =
                resources.Controls.FindChild<Label>(new [] {"Electronics", "eCount"});
            Character.FoodCount =
                resources.Controls.FindChild<Label>(new [] {"Food", "fCount"});
            Character.WeaponValue =
                resources.Controls.FindChild<Label>(new[] {"Weapon", "wValue"});
            Character.CharismaValue =
                resources.Controls.FindChild<Label>(new [] {"Charisma", "cValue"});
            Character.EngineeringValue =
                resources.Controls.FindChild<Label>(new[] {"Engineering", "eValue"});
            var p = UserSettings.File.ParametersInfo;
            Character.UpdateCharacter(p[0] * 256 + p[1],
                p[2] * 256 + p[3],
                p[4] * 256 + p[5],
                p[6] * 256 + p[7],
                p[8] * 256 + p[9],
                p[10] * 256 + p[11]);

            _currentEvent = GameEvents.Dequeue();
            _currentEvent.Start();

            Character.UpdateInfo();
        }

        private void KeyPressed(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    GameField.MovePlayer(Direction.Left);
                    break;
                case Keys.D:
                    GameField.MovePlayer(Direction.Right);
                    break;
                case Keys.W:
                    GameField.MovePlayer(Direction.Up);
                    break;
                case Keys.S:
                    GameField.MovePlayer(Direction.Down);
                    break;
                case Keys.E:
                    GameField.Loot();
                    break;
            }
        }

        public static void NextEvent()
        {
            if (GameEvents.Count == 0)
            {
                _currentEvent = new EmptyEvent();
                _currentEvent.Start();
                return;
            }

            _currentEvent = GameEvents.Dequeue();
            _currentEvent.Start();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            string mes = Input.Text;
            Input.Clear();
            Terminal.NewMessage(mes);
            _currentEvent.Reaction(mes);
        }

        private void Field_SizeChanged(object sender, EventArgs args)
        {
            Tile.ChangeSpriteSize(FieldWindow.Size.Width / 16,
                FieldWindow.Size.Height / 16);
            ChangeResorcePanelSize();
            GameField.LoadField();
        }

        private void ChangeResorcePanelSize()
        {
            var resorcePanel = Controls.FindChild<Panel>(new[] {"Table", "ResourcePanel"}).Controls;
            foreach (Control o in resorcePanel)
            {
                double w = o.Size.Width / o.Size.Height;
                o.Size = new Size((int) (resorcePanel.Owner.Height * w), resorcePanel.Owner.Height);
                foreach (Control oControl in o.Controls)
                {
                    if (oControl.GetType() == typeof(PictureBox))
                    {
                        oControl.Size = new Size((int) (oControl.Width * w), (int) (oControl.Height * w));
                    }
                }
            }
        }
    }

    public static class ControlsExtensions
    {
        public static T FindChild<T>(this Control.ControlCollection parent, string[] names) where T : Control
        {
            Control.ControlCollection currentParent = 
                names
                    .Aggregate(parent, (current, name) => 
                        current?.Find(name, false).FirstOrDefault()?.Controls);

            return (T)currentParent?.Owner;
        }
    }
}
