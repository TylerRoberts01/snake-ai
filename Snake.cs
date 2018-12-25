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
        private int currentDirection; // l r u d
        private int xPos;
        private int yPos;

        public Snake(State state)
        {
            this.state = state;
            this.brain = new Brain(state);
            moves = new List<int>();
            length = 5;
            currentDirection = 1;
            xPos = state.GetSize().Item1/2;
            yPos = state.GetSize().Item2/2;

            for (int i = 0; i < length; i++)
            {
                moves.Add(currentDirection);
            }
        }

        public void Update()
        {
            for (int i = 0; i < length; i++)
            {
                
            }
        }
    }
}
