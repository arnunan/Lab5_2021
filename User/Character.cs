using System;
using System.Windows.Forms;

namespace User
{
    public static class Character
    {
        private static readonly int MaxValue = (int)Math.Pow(2, SaveFile.ParameterLengthInBytes * 8) - 1;

        public static Label MetalCount;
        public static Label ElectronicsCount;
        public static Label FoodCount;
        public static Label WeaponValue;
        public static Label CharismaValue;
        public static Label EngineeringValue;

        private static int _metal = 0;
        private static int _electronics = 0;
        private static int _food = 0;

        public static int _weapon = 0;
        public static int _charisma = 0;
        public static int _engineering = 0;

        public static int Metal
        {
            get => _metal;
            set
            {
                if (value <= 0)
                    return;
                _metal = value > MaxValue ? MaxValue : value;
            }
        }
        public static int Electronics
        {
            get => _electronics;
            set
            {
                if (value <= 0)
                    _electronics = 0;
                _electronics = value > MaxValue ? MaxValue : value;
            }
    }
        public static int Food
        {
            get => _food;
            set
            {
                if (value <= 0)
                    _food = 0;
                _food = value > MaxValue ? MaxValue : value;
            }
        }

        public static int Weapon
        {
            get => _weapon;
            set
            {
                if (value <= 0)
                    _weapon = 0;
                _weapon = value > MaxValue ? MaxValue : value;
            }
        }
        public static int Charisma
        {
            get => _charisma;
            set
            {
                if (value <= 0)
                    _charisma = 0;
                _charisma = value > MaxValue ? MaxValue : value;
            }
        }
        public static int Engineering
        {
            get => _engineering;
            set
            {
                if (value <= 0)
                    _engineering = 0;
                _engineering = value > MaxValue ? MaxValue : value;
            }
        }

        public static void UpdateCharacter(int m, int el, int f, int w, int c, int en)
        {
            Metal = m;
            Electronics = el;
            Food = f;
            Weapon = w;
            Charisma = c;
            Engineering = en;
        }

        public static void UpdateInfo()
        {
            MetalCount.Text = Metal.ToString();
            ElectronicsCount.Text = Electronics.ToString();
            FoodCount.Text = Food.ToString();
            WeaponValue.Text = Weapon.ToString();
            CharismaValue.Text = Charisma.ToString();
            EngineeringValue.Text = Engineering.ToString();
        }
    }
}
