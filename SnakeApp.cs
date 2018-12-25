using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snake_ai
{
    public partial class SnakeApp : System.Windows.Forms.Form
    {
        State map;

        public SnakeApp()
        {
            InitializeComponent();
            map = new State(5, 5);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            map.Draw(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
