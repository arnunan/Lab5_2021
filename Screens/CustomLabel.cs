using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    public class CustomLabel : Label
    {
        public CustomLabel(Point location, Size size, Font font, String text)
        {
            Location = location;
            Text = text;
            Font = font;
            Size = size;
            BackColor = Color.Transparent;
            ForeColor = Color.Orange;
        }
    }
}
