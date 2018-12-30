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
        private State state;

        public SnakeApp()
        {
            this.state = new State(11, 11);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!state.Draw(e))
            {
                state = new State(11, 11);
            }
            Wait(200);
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Wait(int ms)
        {
            Timer timer = new Timer();

            if (ms == 0 || ms < 0)
            {
                return;
            }

            timer.Interval = ms;
            timer.Enabled = true;
            timer.Start();
            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
            };

            while (timer.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
}
