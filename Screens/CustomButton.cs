using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public class CustomButton : Button
    {
        public CustomButton(Point location, string text, int fontSize, Size size)
        {
            Location = location;
            Size = size;
            Text = text;
            Font = new Font("Bahnschrift", fontSize);
            BackColor = Color.Transparent;
            BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\Ui01.png");
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;

            MouseEnter += (sender, args) =>
            {
                BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\Ui02.png");
                BackColor = Color.Black;
            };

            MouseLeave += (sender, args) =>
            {
                BackgroundImage = Image.FromFile("..\\..\\Resources\\Images\\Ui01.png");
            };
        }
    }
}
