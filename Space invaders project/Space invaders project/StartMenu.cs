using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_invaders_project
{
    public partial class StartMenu : Form
    {
        GameMenu fm2 = new GameMenu();
        public StartMenu()
        {
            InitializeComponent();
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            fm2.Show();
        }

            private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void storyButton_Click(object sender, EventArgs e)
        {
            Story st = new Story();
            st.Show();
        }
    }
}
