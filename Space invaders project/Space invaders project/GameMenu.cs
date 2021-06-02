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
    public partial class GameMenu : Form
    {
       
        public GameMenu()
        {
            InitializeComponent();
        }

        private void hardLevel(object sender, EventArgs e)
        {

            HardLevel fm3 = new HardLevel(15);
            
            fm3.Show();
            this.Hide();
            
        }

        private void normalLevel(object sender, EventArgs e)
        {
            HardLevel fm3 = new HardLevel(10);
            
            fm3.Show();
            this.Hide();
        }

        private void easyLevel(object sender, EventArgs e)
        {

            HardLevel fm3 = new HardLevel(5);
           
            fm3.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
