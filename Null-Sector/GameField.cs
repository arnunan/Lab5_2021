using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using User;

namespace Null_Sector
{
    /// <summary>
    /// <param name="_fieldAnchor">Field's anchor position. Field's anchor — upper-left angle.</param>
    /// </summary>
    static class GameField
    {
        private const int FieldSize = 16;
        private const int SeeAreaSize = 9;
        private static readonly PictureBox Player = new PictureBox
        {
            Location = new Point(0, 0),
            Image = Image.FromFile(SystemFiles.PlayerSprite),
            Size = new Size(Tile.SpriteWidth, Tile.SpriteWidth),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Name = "Player",
            BackColor = Color.Transparent,
            Dock = DockStyle.Fill
        };

        public static Tile[,] Tiles;

        private static Point _playerPosition = new Point(Map.Size / 2, Map.Size / 2); // global pos
        private static Point _fieldAnchor = new Point((Map.Size - FieldSize) / 2, (Map.Size - FieldSize) / 2); // global pos

        public static SelectablePanel Field;

        public static void LoadField()
        {
            Field.Controls.Clear();
            for (int x = _fieldAnchor.X; x < _fieldAnchor.X + FieldSize; ++x)
            for (int y = _fieldAnchor.Y; y < _fieldAnchor.Y + FieldSize; ++y)
            {
                PictureBox tile = new PictureBox()
                {
                    Location = new Point((x - _fieldAnchor.X) * Tile.SpriteWidth, 
                        (y - _fieldAnchor.Y) * Tile.SpriteHeight),
                    Image = Image.FromFile(Tiles[y, x].SpriteName),
                    Size = new Size(Tile.SpriteWidth, Tile.SpriteHeight),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = $"{x - _fieldAnchor.X}x{y - _fieldAnchor.Y}"
                };

                Field.Controls.Add(tile);
            }
            TileAt(_playerPosition.X - _fieldAnchor.X, _playerPosition.Y - _fieldAnchor.Y).Controls.Add(Player);
        }

        #region Player

        public static void Loot()
        {
            if (!IsTile("ShipRuin", _playerPosition.X, _playerPosition.Y)) return;
            Tiles[_playerPosition.Y, _playerPosition.X] = new Tile('.');
            TileAt(_playerPosition.X - _fieldAnchor.X, _playerPosition.Y - _fieldAnchor.Y).Image = Image.FromFile(Tiles[_playerPosition.Y, _playerPosition.X].SpriteName);
            Character.Metal += 2;
            Character.Electronics += 10;
            Character.UpdateInfo();
        }

        public static bool IsTile(string name, int x, int y) => Tiles[y, x].Name == name;

        #endregion

        #region Move

        public static void MovePlayer(Direction dir)
        {
            int border;
            int dirSign;

            switch (dir)
            {
                case Direction.Down:
                    border = Map.Size - 1;
                    dirSign = 1;
                    VerticalMove(border, dirSign);
                    break;
                case Direction.Right:
                    border = Map.Size - 1;
                    dirSign = 1;
                    HorizontalMove(border, dirSign);
                    break;
                case Direction.Left:
                    border = 0;
                    dirSign = -1;
                    HorizontalMove(border, dirSign);
                    break;
                case Direction.Up:
                    border = 0;
                    dirSign = -1;
                    VerticalMove(border, dirSign);
                    break;
            }
        }

        private static void HorizontalMove(int border, int dirSign)
        {
            if (!PositionCalculator.CanPlayerMoveHorizontal(border, dirSign, ref _playerPosition) || 
                IsFoodOver())
                return;

            Character.UpdateInfo();

            bool fieldPosInc = false;
            int fieldBorder = _fieldAnchor.X + (1 + dirSign) * (FieldSize) / 2 + (dirSign - 1) / 2;
            int seeBorder = _playerPosition.X + dirSign * (SeeAreaSize - 1) / 2;

            if (seeBorder == fieldBorder - dirSign && IsCloser( _playerPosition.X, seeBorder, border))
            {
                fieldPosInc = true;
            }

            if (fieldPosInc)
            {
                MoveField(dirSign == 1 ? Direction.Right : Direction.Left);
            }
            else
            {
                TileAt(_playerPosition.X - _fieldAnchor.X - dirSign, _playerPosition.Y - _fieldAnchor.Y).Controls.Clear();
                TileAt(_playerPosition.X - _fieldAnchor.X, _playerPosition.Y - _fieldAnchor.Y).Controls.Add(Player);
            }
        }

        private static bool IsFoodOver()
        {
            if (Character.Food > 0 || Game.IsGameOver) return Game.IsGameOver;
            DeleteForm<SelectablePanel>("FieldWindow");
            DeleteForm<TextBox>("Input");
            DeleteForm<Button>("Send");
            Terminal.Clear();
            Terminal.NewMessage("ТЫ УМЕР! ТЫ УМЕР! ТЫ УМЕР!");
            Game.IsGameOver = true;
            return Game.IsGameOver;
        }

        public static void DeleteForm<T>(string name) where T : Control
        {
            var form = Game.GameForm.FindChild<T>(new[] {name});
            form?.Dispose();
        }

        private static void VerticalMove(int border, int dirSign)
        {
            if (!PositionCalculator.CanPlayerMoveHorizontal(border, dirSign, ref _playerPosition) ||
                IsFoodOver())
                return;

            Character.UpdateInfo();

            bool fieldPosInc = false;
            int fieldBorder = _fieldAnchor.Y + (1 + dirSign) * (FieldSize) / 2 + (dirSign - 1) / 2;
            int seeBorder = _playerPosition.Y + dirSign * (SeeAreaSize - 1) / 2;

            if (seeBorder == fieldBorder - dirSign && IsCloser(_playerPosition.Y, seeBorder, border))
            {
                fieldPosInc = true;
            }

            if (fieldPosInc)
            {
                MoveField(dirSign == 1 ? Direction.Down : Direction.Up);
            }
            else
            {
                TileAt(_playerPosition.X - _fieldAnchor.X, _playerPosition.Y - _fieldAnchor.Y - dirSign).Controls.Clear();
                TileAt(_playerPosition.X - _fieldAnchor.X, _playerPosition.Y - _fieldAnchor.Y).Controls.Add(Player);
            }
        }

        private static void MoveField(Direction dir)
        {
            switch (dir)
            {
                case Direction.Right:
                {
                    for (int x = 0; x < FieldSize - 1; ++x)
                    for (int y = 0; y < FieldSize; ++y)
                    {
                        TileAt(x, y).Image = TileAt(x + 1, y).Image;
                    }

                    for (int y = 0; y < FieldSize; ++y)
                    {
                        TileAt(FieldSize - 1, y).Image = 
                            Image.FromFile(Tiles[_fieldAnchor.Y + y, _fieldAnchor.X + FieldSize].SpriteName);
                    }

                    _fieldAnchor.X++;
                    return;
                }
                case Direction.Left:
                {
                    for (int x = FieldSize - 1; x > 0; --x)
                    for (int y = 0; y < FieldSize; ++y)
                    {
                        TileAt(x, y).Image = TileAt(x - 1, y).Image;
                    }

                    for (int y = 0; y < FieldSize; ++y)
                    {
                        TileAt(0, y).Image = 
                            Image.FromFile(Tiles[_fieldAnchor.Y + y, _fieldAnchor.X - 1].SpriteName);
                    }

                    _fieldAnchor.X--;
                    return;
                }
                case Direction.Up:
                {
                    for (int x = 0; x < FieldSize; ++x)
                    for (int y = FieldSize - 1; y > 0; --y)
                    {
                        TileAt(x, y).Image = TileAt(x, y - 1).Image;
                    }

                    for (int x = 0; x < FieldSize; ++x)
                    {
                        TileAt(x, 0).Image =
                            Image.FromFile(Tiles[_fieldAnchor.Y - 1, _fieldAnchor.X + x].SpriteName);
                    }

                    _fieldAnchor.Y--;
                    return;
                }
                case Direction.Down:
                {
                    for (int x = 0; x < FieldSize; ++x)
                    for (int y = 0; y < FieldSize - 1; ++y)
                    {
                        TileAt(x, y).Image = TileAt(x, y + 1).Image;
                    }

                    for (int x = 0; x < FieldSize; ++x)
                    {
                        TileAt(x, FieldSize - 1).Image =
                            Image.FromFile(Tiles[_fieldAnchor.Y + FieldSize, _fieldAnchor.X + x].SpriteName);
                    }

                    _fieldAnchor.Y++;
                    return;
                    }
            }
        }

        #endregion

        private static bool IsCloser(int player, int o1, int o2) => Math.Abs(player - o1) < Math.Abs(player - o2);

        private static PictureBox TileAt(int x, int y) =>
            (PictureBox)Field.Controls.Find($"{x}x{y}", false)[0];
    }
}
