using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snake_ai {
    public class Node {
        string type;
        int x;
        int y;

        public Node(string type, int x, int y) {
            this.type = type;
            this.x = x;
            this.y = y;

        }

        public void draw(PaintEventArgs e) {
            SolidBrush brush;
            switch(type) {
                case "food":
                    brush = new SolidBrush(Color.Red);
                    break;
                case "blank":
                    brush = new SolidBrush(Color.Black);
                    break;
                default:
                    brush = new SolidBrush(Color.Green);
                    break;
            }
            e.Graphics.FillRectangle(brush, new RectangleF(x, y, 9, 9));
            brush.Dispose();
        }
    }
}
