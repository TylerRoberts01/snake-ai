using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake_ai {
    public class Snake {
        SnakeMap map;
        NeuralNetwork brain;

        public Snake(SnakeMap map) {
            this.map = map;
            this.brain = new NeuralNetwork();
        }

        void look() {
            // Forward

        }

        int think() {

        }

        public void move() {
            look();
            return think();
        }
    }
}
