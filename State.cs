using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snake_ai
{
    public class State
    {
        private List<List<Node>> map;
        private Snake snek;
        private int xSize;
        private int ySize;

        public State(int r, int c)
        {
            snek = new Snake(this);
            map = new List<List<Node>>();
            xSize = c;
            ySize = r;

            int posY = 0;
            for (int y = 0; y < r; y++)
            {
                map.Add(new List<Node>());
                int posX = 0;

                for (int x = 0; x < c; x++)
                {
                    map[y].Add(new Node(0, posX++ * 10, posY * 10));
                }

                posY++;
            }
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (List<Node> l in map)
            {
                foreach(Node n in l)
                {
                    n.Draw(e);
                }
            }
        }

        public void Update(Tuple<int, int> pos, int type)
        {
            map[pos.Item1][pos.Item2].SetType(type);
        }

        public Tuple<int, int> GetSize()
        {
            return new Tuple<int, int>(xSize, ySize);
        }

        public override string ToString()
        {
            string result = "";

            map.Select(l => l.Select(n => result += n.ToString()));

            return result;
        }
    }
}
