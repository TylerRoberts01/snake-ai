using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai {
    public class Snake
    {
        private State state;
        private Brain brain;
        private List<int> moves;
        private int length;
        private int currentDirection; // rl = +/-1, ud = +/-2
        private Tuple<int, int> pos;

        public Snake(State state)
        {
            this.state = state;
            this.brain = new Brain(state);
            moves = new List<int>();
            length = 5;
            currentDirection = 1;
            pos = new Tuple<int, int>(state.GetSize().Item1 / 2, state.GetSize().Item2 / 2);

            for (int i = 0; i < length; i++)
            {
                moves.Add(currentDirection);
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
            pos = Update(pos, currentDirection);

            Tuple<int, int> currentPos = Update(pos, 0);

            moves.Add(currentDirection);

            for (int i = 0; i < length; i++)
            {
                state.Update(currentPos, i == 0 ? 1 : 2);
                currentPos = Update(currentPos, -moves[i]);
            }

            state.Update(currentPos, 0);
        }

        private Tuple<int, int> Update(Tuple<int, int> pos, int dir)
        {
            int x = pos.Item1;
            int y = pos.Item2;
            switch (dir)
            {
                case -2: // down
                    y--;
                    break;
                case -1: // left
                    x--;
                    break;
                case 1: // right
                    x++;
                    break;
                case 2: // up
                    y++;
                    break;
                default:
                    break;
            }

            return new Tuple<int, int>(x, y);
        }
    }
}
