using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    public partial class LoseWin : Form
    {
        public static Label label2;
        public LoseWin()
        {
            InitializeComponent();
            label2 = new Label()
            {
                BackColor = Color.Transparent,
                Font = new Font("Showcard Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = SystemColors.ButtonHighlight,
                Location = new Point(514, 75),
                Size = new Size(892, 74),
                Text = "К сожалению, вы проиграли("
            };
            this.Controls.Add(label2);
            this.WindowState = FormWindowState.Maximized;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
