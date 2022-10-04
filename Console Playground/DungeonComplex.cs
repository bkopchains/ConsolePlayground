namespace Console_Playground
{
    internal class DungeonComplex
    {
        /// <summary>
        /// Find shortest path from top left to bottom right, able to delete k number of obstacles
        /// </summary>
        /// <param name="grid">grid matrix</param>
        /// <param name="k">number of obstacles you can delete</param>
        /// <returns></returns>
        public static int ShortestPath(int[][] grid, int k)
        {
            int[] end = new int[2] { grid.Length - 1, grid[0].Length - 1 };
            //vectors 
            int[] dx = new int[4] { 0, 0, 1, -1 };
            int[] dy = new int[4] { 1, -1, 0, 0 };

            PriorityQueue<StepState, int> queue = new PriorityQueue<StepState, int>();
            //trying to be too smart here - stop reading the stupid comments!!!
            //Dictionary<int[], int> visited = new Dictionary<int[], int>();
            HashSet<StepState> visited = new HashSet<StepState>();

            //add the start to the queue and mark it as visited
            StepState start = new StepState(0, 0, 0, k, end);
            queue.Enqueue(start, start.estimate);
            //visited.Add(start.position, start.estimate);
            visited.Add(start);

            //loop until queue is empty
            while (queue.Count > 0)
            {
                //dequeue by priority, next to be popped will have the shortest estimate
                StepState current = queue.Dequeue();

                //we can reach the target in the manhattan distance even if all that's left are obstacles
                int remainMinDistance = current.estimate - current.steps;
                if (remainMinDistance <= current.k)
                {
                    return current.estimate;
                }

                //check out all the vectors
                for (int j = 0; j < 4; j++)
                {
                    int ddy = current.row + dy[j];
                    int ddx = current.col + dx[j];

                    //enqueue if it's in the bounds of the grid
                    if (ddy >= 0 && ddx >= 0 && ddy <= end[0] && ddx <= end[1])
                    {
                        //lower the elim. count if the grid has an obstacle
                        int nextElim = current.k - grid[ddy][ddx];

                        StepState nextStep = new StepState(current.steps+1, ddy, ddx, nextElim, end);

                        //if (nextElim >= 0 && (!visited.ContainsKey(nextStep.position) || visited[nextStep.position] > nextStep.k))
                        if (nextElim >= 0 && !visited.Contains(nextStep))
                        {
                            visited.Add(nextStep);
                            queue.Enqueue(nextStep, nextStep.estimate);
                        }
                    }
                }
            }
            return -1;
        }

        public static int LongestStrChain(string[] words)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string[] sorted = words.Distinct().OrderBy(w => w.Length).ToArray();
            int possible = 0;
            foreach (string word in sorted)
            {
                int bestChainLength = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    string prev = word.Remove(i, 1);
                    bestChainLength = Math.Max(dict.GetValueOrDefault(prev,0)+1, bestChainLength);
                }
                dict.Add(word, bestChainLength);
                possible = Math.Max(possible, bestChainLength);
            }
            return possible;
        }

    }

    public class StockPrice
    {
        //<timestamp, price>
        Dictionary<int, int> stockValues;
        PriorityQueue<KeyValuePair<int,int>, int> minHeap;
        PriorityQueue<KeyValuePair<int, int>, int> maxHeap;
        int latest;

        public StockPrice()
        {
            stockValues = new Dictionary<int, int>();
            minHeap = new PriorityQueue<KeyValuePair<int, int>, int>(Comparer<int>.Create((a,b) => b-a));
            maxHeap = new PriorityQueue<KeyValuePair<int, int>, int>(Comparer<int>.Create((a,b) => a-b));
        }

        public void Update(int timestamp, int price)
        {
            if (timestamp >= latest)
            {
                latest = timestamp;
            }
            if (stockValues.ContainsKey(timestamp))
            {
                stockValues[timestamp] = price;
            }
            else
            {
                stockValues.Add(timestamp, price);
            }
            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(timestamp, price);
            minHeap.Enqueue(kvp, price);
            maxHeap.Enqueue(kvp, price);
        }

        public int Current()
        {
            return stockValues[latest];
        }

        public int Maximum()
        {
            KeyValuePair<int, int> maxval = maxHeap.Peek();
            if (stockValues[maxval.Key] == maxval.Value)
            {
                return maxval.Value;
            } else
            {
                maxHeap.Dequeue();
                return Maximum();
            }
        }

        public int Minimum()
        {
            KeyValuePair<int, int> minval = minHeap.Peek();
            if (stockValues[minval.Key] == minval.Value)
            {
                return minval.Value;
            }
            else
            {
                minHeap.Dequeue();
                return Minimum();
            }
        }
    }

    public class StepState: IComparable
    {
        public int estimate, steps, row, col, k;
        private int[] target;

        public StepState(int _steps, int _row, int _col, int _k, int[] _target)
        {
            steps = _steps;
            row = _row;
            col = _col;
            k = _k;
            target = _target;

            int manhattanDistance = target[0] - row + target[1] - col;
            // h(n) = manhattan distance,  g(n) = 0
            // estimate = h(n) + g(n)
            estimate = manhattanDistance + steps;
        }

        public int[] position { get { return new int[2] { row, col }; } }

        public int CompareTo(object? obj)
        {
            // order the elements solely based on the 'estimate' value
            if (!(obj is StepState))
            {
                throw new ArgumentException();
            }
            StepState other = (StepState)obj;
            return estimate - other.estimate;
        }
        public override int GetHashCode()
        {
            return (row + 1) * (col + 1) * k;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is StepState)) {
                return false;
            }
            StepState newState = (StepState)obj;
            return (row == newState.row) && (col == newState.col) && (k == newState.k);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
