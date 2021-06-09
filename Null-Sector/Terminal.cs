using System.IO;
using System.Windows.Forms;
using User;

namespace Null_Sector
{
    static class Terminal
    {
        private const string TerminalTextsFolder = SystemFiles.PropertiesFolder + "Terminal/";
        public static TextBox TerminalBox;

        public static void Welcome()
        {
            NewMessage(File.ReadAllText(TerminalTextsFolder + "WelcomeText.txt"));
        }

        public static void NewMessage(string text) => TerminalBox.Text += $"{text}\r\n" + "=== === ===\r\n";

        public static void Clear() => TerminalBox.Clear();
    }
}
