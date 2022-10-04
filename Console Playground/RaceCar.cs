using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    public class RaceCar
    {
        //what on earth is this question
        //timing out because i'm using custom classes, only worked after I changed to ISet<string> vs ISet<CarState>

        //[position, speed]
        //PriorityQueue<CarState, int> queue;
        Queue<CarState> queue;
        ISet<string> visited;

        public int Racecar(int target)
        {
            //priority queue based on what's closer to the target?
            //queue = new PriorityQueue<CarState, int>(Comparer<int>.Create((a, b) => Math.Abs(target - a) - Math.Abs(target - b)));
            queue = new Queue<CarState>();
            visited = new HashSet<string>();

            //queue.Enqueue(new CarState() { position = 0, speed = 1, instructions = 0 }, 0);
            CarState start = new CarState() { position = 0, speed = 1, instructions = 0 };
            queue.Enqueue(start);
            visited.Add($"{start.position}{start.speed}");

            while (queue.Count > 0)
            {
                CarState current = queue.Dequeue();

                if (current.position == target)
                {
                    return current.instructions;
                }
                else
                {
                    CarState nextA = accelerate(current);
                    if (nextA.position <= target * 2 && nextA.position > 0 && visited.Add($"{nextA.position}{nextA.speed}")) { 
                        queue.Enqueue(nextA);
                    }
                    CarState nextR = reverse(current);
                    if (nextR.position <= target * 2 && nextR.position > 0 && visited.Add($"{nextR.position}{nextR.speed}"))
                    {
                        queue.Enqueue(nextR);
                    }
                }

            }

            return 0;
        }
        //accelerate in the direction we're moving
        private CarState accelerate(CarState state)
        {
            return new CarState() { position = state.position + state.speed, speed = state.speed*2, instructions = state.instructions+1 };
        }
        //change direction
        private CarState reverse(CarState state)
        {
            int newSpeed = state.speed >= 0 ? -1 : 1;
            return new CarState(){ position = state.position, speed = newSpeed, instructions = state.instructions + 1 };
        }
        public class CarState
        {
            public int position;
            public int speed;
            public int instructions;
        }
    }
}
