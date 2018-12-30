using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace snake_ai
{
    public class Episode
    {
        State state;

        public Episode()
        {
            this.state = new State(20, 20);
        }

        public void Draw(PaintEventArgs e)
        {
            state.Draw(e);
        }
    }
}
