using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snake_ai
{
    public class State
    {
        private List<List<int>> map;
        private Snake snek;
        private Tuple<int, int> size;

        public State(int r, int c)
        {
            snek = new Snake(this);
            map = new List<List<int>>();
            size = new Tuple<int, int>(r, c);
            
            for (int y = 0; y < r; y++)
            {
                map.Add(new List<int>());
                for (int x = 0; x < c; x++)
                {
                    map[0].Add(0);
                }
            }
        }

        public State(State state)
        {
            snek = new Snake(this);
            map = new List<List<int>>(state.map);
            size = new Tuple<int, int>(state.size.Item1, state.size.Item2);
        }

        public void Draw(PaintEventArgs e)
        {
            snek.Update();
            foreach (List<int> list in map)
            {
                foreach (int pos in list)
                {
                    Draw(pos, e);
                }
            }
        }

        private void Draw(int type, PaintEventArgs e)
        {
            SolidBrush brush;
            switch (type)
            {
                case 0: // blank
                    brush = new SolidBrush(Color.Black);
                    break;
                case 1: // head
                case 2: // segment
                    brush = new SolidBrush(Color.Green);
                    break;
                default: // food
                    brush = new SolidBrush(Color.Red);
                    break;
            }
            e.Graphics.FillRectangle(brush, new RectangleF(x, y, 9, 9));
            brush.Dispose();
        }

        public void Update(Tuple<int, int> pos, int type)
        {
            map[pos.Item1][pos.Item2] = type;
        }

        public Tuple<int, int> GetSize()
        {
            return new Tuple<int, int>(size.Item1, size.Item2);
        }

        public List<List<int>> CopyMap()
        {
            return new List<List<int>>(map);
        }

        public override string ToString()
        {
            string result = "";

            foreach (List<int> list in map)
            {
                foreach (int pos in list)
                {
                    result += pos;
                }
            }

            return result;
        }
    }
}
