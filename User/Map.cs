using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace User
{
    public class Map
    {
        public const int Size = 32;

        public Tile[,] TileMap { get; set; }

        public Map(byte[] map)
        {
            TileMap = ParseToTiles(map);
        }

        public Map(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            byte[] map = new byte[Size * Size];
            stream.Read(map, 0, Size * Size);
            stream.Close();
            string text = System.Text.Encoding.Default.GetString(map).Replace(' ', char.MinValue);
            TileMap = text
                .SkipWhile(c => char.IsDigit(c) || c == ';')
                .Select(c => new Tile(c))
                .ToArray()
                .Convert1DArrayTo2DMap();
        }

        private static Tile[,] ParseToTiles(byte[] array)
        {
            return array
                .Select(b => new Tile(b))
                .ToArray()
                .Convert1DArrayTo2DMap();
        }

        public static byte[] GenerateNewMap()
        {
            byte[,] res = new byte[Size, Size];

            Random rand = new Random();

            for (int r = 0; r < Size; ++r)
            for (int c = 0; c < Size; ++c)
            {
                if ((r == Size / 2 - 1 || r == Size / 2) && (c == Size / 2 - 1 || c == Size / 2))
                {
                    res[r, c] = 1;
                    continue;
                }

                res[r, c] = (byte)(rand.Next(0, 10) < 2 ? 2 : 0);
            }

            return res.Convert2DMapArrayTo1D();
        }
    }

    public class Tile
    {
        public static readonly Dictionary<byte, (string name, string path, char tileChar)> ByteToTile = new Dictionary<byte, (string, string, char)>
        {
            [0] = ("Space", SystemFiles.SpritesFolder + "tiles/space.png", '.'),
            [1] = ("ShipFloor", SystemFiles.SpritesFolder + "tiles/shipFloor.png", '#'),
            [2] = ("ShipRuin", SystemFiles.SpritesFolder + "tiles/shipRuin.png", 'X')
        };

        public static readonly Dictionary<char, (string name, string path, byte tileValue)> CharToTile = new Dictionary<char, (string, string, byte)>
        {
            ['.'] = ("Space", SystemFiles.SpritesFolder + "tiles/space.png", 0),
            ['#'] = ("ShipFloor", SystemFiles.SpritesFolder + "tiles/shipFloor.png", 1),
            ['X'] = ("ShipRuin", SystemFiles.SpritesFolder + "tiles/shipRuin.png", 2)
        };

        public static int SpriteWidth { get; private set; } = 32;
        public static int SpriteHeight { get; private set; } = 32;

        public readonly string Name;
        public readonly byte Value;
        public readonly string SpriteName;
        public readonly char TileChar;

        public static void ChangeSpriteSize(int w, int h)
        {
            if (w <= 0 || h <= 0)
                return;
            SpriteWidth = w;
            SpriteHeight = h;
        }

        public Tile(byte b)
        {
            Name = ByteToTile[b].name;
            Value = b;
            SpriteName = ByteToTile[b].path;
            TileChar = ByteToTile[b].tileChar;
        }

        public Tile(char c)
        {
            Name = CharToTile[c].name;
            Value = CharToTile[c].tileValue;
            SpriteName = CharToTile[c].path;
            TileChar = c;
        }
    }

    public static class ArrayExtension
    {
        public static T[] Convert2DMapArrayTo1D<T>(this T[,] array)
        {
            List<T> res = new List<T>();

            for (int r = 0; r < Map.Size; ++r)
            for (int c = 0; c < Map.Size; ++c)
            {
                res.Add(array[r, c]);
            }

            return res.ToArray();
        }

        public static T[,] Convert1DArrayTo2DMap<T>(this T[] array)
        {
            T[,] res = new T[Map.Size, Map.Size];

            for (int i = 0; i < Map.Size * Map.Size; ++i)
            {
                res[i / Map.Size, i % Map.Size] = array[i];
            }

            return res;
        }
    }
}
