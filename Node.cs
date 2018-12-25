using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snake_ai
{
    public class Node
    {
        private int type;
        private int x;
        private int y;

        public Node(int type, int x, int y)
        {
            // 0 = blank
            // 1 = head
            // 2 = segment
            // 3 = food

            this.type = type;
            this.x = x;
            this.y = y;

        }

        public void SetType(int type)
        {
            this.type = type;
        }

        public void Draw(PaintEventArgs e)
        {
            SolidBrush brush;
            switch(type)
            {
                case 0:
                    brush = new SolidBrush(Color.Black);
                    break;
                case 1:
                case 2:
                    brush = new SolidBrush(Color.Green);
                    break;
                default:
                    brush = new SolidBrush(Color.Red);
                    break;
            }
            e.Graphics.FillRectangle(brush, new RectangleF(x, y, 9, 9));
            brush.Dispose();
        }

        public override string ToString()
        {
            return "" + type;
        }
    }
}
