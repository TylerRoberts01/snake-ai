using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai {
    public class Brain
    {
        private Dictionary<string, Tuple<int, double>> table;
        private State state;
        private readonly double discount = .8;
        private readonly List<int> actions = new List<int> { -2, -1, 1, 2 };

        public Brain(State state)
        {
            table = new Dictionary<string, Tuple<int, double>>();
            this.state = state;
        }

        public int GetAction(int currentDirection)
        {
            Simulate(new State(state), currentDirection, discount);

            return table[state.ToString()].Item1;
        }

        private Tuple<int, double> Simulate(State state, int currentDirection, double discount)
        {
            if (discount < .05) // rewards negligible due to discount
            {
                table[state.ToString()] = new Tuple<int, double>(0, 0);
                return new Tuple<int, double>(0, 0);
            }

            int bestAction = 0;
            double bestReward = 0;

            foreach (int action in actions.Where(a => a != -currentDirection).ToArray<int>())
            {
                double reward = InstantReward(state.CopyMap(), currentDirection) + discount * Simulate(new State(state), action, Math.Pow(discount, 2)).Item2;

                if (reward > bestReward)
                {
                    bestAction = action;
                    bestReward = reward;
                }
            }

            table[state.ToString()] = new Tuple<int, double>(bestAction, bestReward);

            return table[state.ToString()];
        }

        private double InstantReward(List<List<int>> map, int direction)
        {
            int headRow = map.FindIndex(l => l.Contains(1));
            int headCol = map[headRow].FindIndex(x => x == 1);

            int nextRow = headRow;
            int nextCol = headCol;

            switch (direction)
            {
                case -2: // down
                    nextRow--;
                    break;
                case -1: // left
                    nextCol--;
                    break;
                case 1: // right
                    nextCol++;
                    break;
                case 2: // up
                    nextRow++;
                    break;
                default:
                    break;
            }
            
            if (nextRow < 0 || nextRow >= map.Count() || nextCol < 0 || nextCol >= map[0].Count()) // Going to crash into wall
            {
                return -20;
            }

            if (map[nextRow][nextCol] == 2) // Going to crash into self
            {
                return -20;
            }

            if (map[nextRow][nextCol] == 3) // Going to eat food
            {
                return 5;
            }

            int foodRow = map.FindIndex(l => l.Contains(3));
            int foodCol = map[headRow].FindIndex(x => x == 3);

            return 1 / (Math.Abs(nextRow - foodRow) + Math.Abs(nextCol - foodCol)); // Distance to food
        }
    }
}
