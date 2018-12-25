using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai {
    public class Brain
    {
        private QTable memory;
        private State state;
        private double e;

        public Brain(State state)
        {
            e = 1;
        }

        public int GetAction()
        {
            int[] rewards = new int[3];

            for (int i = 0; i < 3; i++)
            {

            }

            e *= .97;
        }
    }
}
