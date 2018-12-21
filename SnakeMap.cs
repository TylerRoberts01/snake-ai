using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snake_ai {
    public class SnakeMap {
        Node[,] map;
        Snake snek;

        public SnakeMap(int r, int c, Snake snek) {
            map = new Node[r, c];

            int posY = 0;
            for (int y = 0; y < r; y++) {
                int posX = 0;

                for (int x = 0; x < c; x++) {
                    map[y, x] = new Node("blank", posX++ * 10, posY * 10);
                }

                posY++;
            }

            snek = new Snake();
        }

        public void draw(PaintEventArgs e) {
            foreach (Node n in map) {
                n.draw(e);
            }
        }
    }
}
