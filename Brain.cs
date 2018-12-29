using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai {
    public class Brain
    {
        private Dictionary<string, Tuple<int, double>> table;
        private State state;
        private double learningRate = 1;
        private readonly double discount = .8;
        private readonly List<int> actions = new List<int> { -2, -1, 1, 2 };

        public Brain(State state)
        {
            table = new Dictionary<string, Tuple<int, double>>();
            this.state = state;
        }

        public int GetAction(int currentDirection)
        {
            Simulate(state.CopyMap(), currentDirection, discount);
            learningRate *= .97;

            return table[state.ToString()].Item1;
        }

        private Tuple<int, double> Simulate(List<List<int>> map, int currentDirection, double discount)
        {
            if (discount < .05)
            {
                return new Tuple<int, int>(0, 0);
            }

            var actionAndReward = new Tuple<int, double>(0, 0);

            foreach (int action in actions.Where(a => a != -currentDirection).ToArray<int>())
            {
                double reward = (1 - learningRate) * r
            }

            table[state.ToString()] = actionAndReward;

            return table[state.ToString()];
        }

        private double InstantReward(List<List<int>> map, int direction)
        {
            var headPos = new Tuple<int, int>(map.FindIndex()
        }
    }
}
