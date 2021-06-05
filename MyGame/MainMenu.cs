using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Forms.roomNumber == 1)
                Forms.room1.Show();
            else if (Forms.roomNumber == 2)
                Forms.room2.Show();
            else if (Forms.roomNumber == 3)
                Forms.room3.Show();
            else if (Forms.roomNumber == 4)
                Forms.room4.Show();
            else
                Forms.room5.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
