using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai {
    public class Snake
    {
        private State state;
        private Brain brain;
        private LinkedList<int> moves;
        public int length;
        private int currentDirection; // rl = +/-1, ud = +/-2
        private Tuple<int, int> pos;

        public Snake(State state)
        {
            this.state = state;
            this.brain = new Brain(state);
            moves = new LinkedList<int>();
            length = 2;
            currentDirection = 1;
            pos = new Tuple<int, int>(state.GetSize().Item1 / 2, state.GetSize().Item2 / 2);

            for (int i = 0; i < length; i++)
            {
                moves.AddLast(currentDirection);
            }
        }

        public void Think()
        {
            currentDirection = brain.GetAction(currentDirection);
        }

        public void Update()
        {
            Think();
            Update(currentDirection);
        }

        public void Update(int dir)
        {
            pos = Update(pos, dir);

            Tuple<int, int> currentPos = Update(pos, 0);

            moves.AddFirst(dir);

            bool grow = false;
            for (int i = 0; i < length; i++)
            {
                if (state.CopyMap()[pos.Item1][pos.Item2] == 3 && i == 0)
                {
                    state.points *= 100;
                    state.PlaceFood();
                    grow = true;
                }

                state.Update(currentPos, i == 0 ? 1 : 2);
                currentPos = Update(currentPos, -moves.First.Value);
                moves.AddLast(moves.First.Value);
                moves.RemoveFirst();

                if (grow && i == length - 1)
                {
                    length++;
                    moves.AddFirst(moves.First.Value);
                    grow = false;
                }
            }

            state.Update(currentPos, 0);
            moves.RemoveFirst();
        }

        private Tuple<int, int> Update(Tuple<int, int> pos, int dir)
        {
            int row = pos.Item1;
            int col = pos.Item2;
            switch (dir)
            {
                case -2: // down
                    row--;
                    break;
                case -1: // left
                    col--;
                    break;
                case 1: // right
                    col++;
                    break;
                case 2: // up
                    row++;
                    break;
                default:
                    break;
            }

            return new Tuple<int, int>(row, col);
        }

        public void Grow()
        {

        }
    }
}
