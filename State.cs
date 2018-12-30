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
        private Tuple<int, int> size;
        public Snake snake;
        public int points;
        public bool lost;

        public State(int rows, int cols)
        {
            map = new List<List<int>>();
            size = new Tuple<int, int>(rows, cols);
            snake = new Snake(this);
            points = 0;

            for (int row = 0; row < rows; row++)
            {
                map.Add(new List<int>());
                for (int col = 0; col < cols; col++)
                {
                    if (row == size.Item1 / 2 && col > size.Item2/2-snake.length && col <= size.Item2/2)
                    {
                        if (col == size.Item2/2)
                        {
                            map[row].Add(1);
                        }

                        else
                        {
                            map[row].Add(2);
                        }
                    }

                    else
                    {
                        map[row].Add(0);
                    }
                }
            }

            PlaceFood();
        }

        public State(State state)
        {
            map = new List<List<int>>();
            size = new Tuple<int, int>(state.size.Item1, state.size.Item2);

            for (int row = 0; row < size.Item1; row++)
            {
                map.Add(new List<int>());
                for (int col = 0; col < size.Item2; col++)
                {
                    map[row].Add(state.map[row][col]);
                }
            }

            snake = new Snake(this);
            points = state.points;
        }

        public void Draw(PaintEventArgs e)
        {
            snake.Update();
            int row = 0;
            int col = 0;

            foreach (List<int> list in map)
            {
                foreach (int type in list)
                {
                    Draw(type, row, col, e);
                    col += 10;
                }
                row += 10;
                col = 0;
            }
        }

        private void Draw(int type, int row, int col, PaintEventArgs e)
        {
            SolidBrush brush;
            switch (type)
            {
                case 0: // blank
                    brush = new SolidBrush(Color.Black);
                    break;
                case 1: // head
                    brush = new SolidBrush(Color.LightGreen);
                    break;
                case 2: // segment
                    brush = new SolidBrush(Color.Green);
                    break;
                default: // food
                    brush = new SolidBrush(Color.Red);
                    break;
            }
            e.Graphics.FillRectangle(brush, new RectangleF(col, row, 9, 9));
            brush.Dispose();
        }

        public void Update(Tuple<int, int> pos, int type)
        {
            if (pos.Item1 < 0 || pos.Item1 >= size.Item1 || pos.Item2 < 0 || pos.Item2 >= size.Item2)
            {
                lost = true;
                return;
            }

            map[pos.Item1][pos.Item2] = type;
        }

        public void PlaceFood()
        {
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            for (int row = 0; row < size.Item1; row++)
            {
                for (int col = 0; col < size.Item2; col++)
                {
                    if (map[row][col] != 1 && map[row][col] != 2)
                    {
                        rows.Add(row);
                        cols.Add(col);
                    }
                }
            }

            int index = new Random().Next(rows.Count());
            map[rows[index]][cols[index]] = 3;
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
