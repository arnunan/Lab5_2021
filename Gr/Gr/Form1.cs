using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gr.Controllers;

namespace Gr
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Controller.Init(this);
		}
	}
}

