using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai {
    public class Brain
    {
        private Dictionary<string, Tuple<int, double>> table;
        private State state;
        private readonly double discount = .9;
        private double learningRate = 1;
        private readonly List<int> actions = new List<int> { -2, -1, 1, 2 };

        public Brain(State state)
        {
            table = new Dictionary<string, Tuple<int, double>>();
            this.state = state;
        }

        public int GetAction(int currentDirection)
        {
            if (new Random().NextDouble() >= learningRate && table.TryGetValue(state.ToString(), out Tuple<int, double> actionAndReward) && actionAndReward.Item1 != 0)
            {
                return actionAndReward.Item1;
            }

            table[state.ToString()] = Simulate(new State(state), currentDirection, discount);

            learningRate *= .97;

            return table[state.ToString()].Item1;
        }

        private Tuple<int, double> Simulate(State state, int currentDirection, double discount)
        {
            if (discount < .05) // rewards negligible due to discount
            {
                return new Tuple<int, double>(0, 0);
            }

            int bestAction = 0;
            double bestReward = 0;
            string mapString = state.ToString();

            foreach (int action in actions.Where(a => a != -currentDirection).ToArray<int>())
            {
                State next = new State(state);
                next.snake.Update(action);
                double reward = InstantReward(state.CopyMap(), action, mapString) + discount * Simulate(next, action, Math.Pow(discount, 2)).Item2;

                if (reward > bestReward)
                {
                    bestAction = action;
                    bestReward = reward;
                }
            }

            return new Tuple<int, double>(bestAction, bestReward);
        }

        private double InstantReward(List<List<int>> map, int direction, string key)
        {
            int headRow = map.FindIndex(l => l.Contains(1));

            if (headRow < 0)
            {
                return -50;
            }

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
                return -50;
            }

            if (map[nextRow][nextCol] == 2) // Going to crash into self
            {
                return -50;
            }

            if (map[nextRow][nextCol] == 3) // Going to eat food
            {
                return 25;
            }

            int foodRow = map.FindIndex(l => l.Contains(3));
            int foodCol = map[foodRow].FindIndex(x => x == 3);

            return 1.0 / (Math.Abs((double)(nextRow - foodRow)) + Math.Abs((double)(nextCol - foodCol))); // Distance to food
        }
    }
}
