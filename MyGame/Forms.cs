using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame
{
    class Forms
    {
        public static StartRoom room1 = new StartRoom();
        public static MainMenu menu = new MainMenu();
        public static SecondRoom room2 = new SecondRoom();
        public static ThirdRoom room3 = new ThirdRoom();
        public static FourthRoom room4 = new FourthRoom();
        public static FivethRoom room5 = new FivethRoom();
        public static WinWin WinRoom = new WinWin();
        public static StartMenu StartMenu = new StartMenu();
        public static LoseWin loseWin = new LoseWin();
        public static bool haveDiamond = false;
        public static bool isWin = true;
        public static int roomNumber;
    }
}
