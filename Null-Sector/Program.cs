using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using User;

namespace Null_Sector
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GenerateDemo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }

        private static void GenerateDemo()
        {
            string file = File.ReadAllText(SystemFiles.SaveFilesFolder + "demoMap.txt");

            string[] info = file.Split(';');

            byte[] ps = info
                .Take(SaveFile.CountOfParameters)
                .SelectMany(b =>
                {
                    byte _b = byte.Parse(b);
                    return new[] { (byte)(_b / 256), (byte)(_b % 256) };
                })
                .ToArray();

            byte[] map = info
                .Last()
                .Replace("\r\n", "")
                .Replace(" ", "")
                .Select(c => new Tile(c).Value)
                .ToArray();

            new SaveFile("demo", ps, map);
        }
    }
}
