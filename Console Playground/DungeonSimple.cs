using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    internal class DungeonSimple
    {
        //private static char[][] map;

        //private static int sx = 0;
        //private static int sy = 0;
        //private static int Y = 0;
        //private static int X = 0;
        //private static int steps = 0;
        //private static int remaining_current = 1;
        //private static int remaining_next = 0;
        //private static Queue<int> yQ = new Queue<int>();
        //private static Queue<int> xQ = new Queue<int>();
        //private static bool reached = false;
        //private static bool[,] visited;
        ////vectors 
        //private static int[] vY = new int[] { -1, +1, 0, 0 };
        //private static int[] vX = new int[] { 0, 0, +1, -1 };

        ///// <summary>
        ///// My solution - low memory usage but sluggish performance
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <returns></returns>
        //public static int GetFood(char[][] grid)
        //{
        //    map = grid;
        //    //char[y][x]
        //    Y = map.Length; //height/num of rows
        //    X = map[0].Length; //width/num of cols

        //    visited = new bool[Y, X];

        //    //find start
        //    for (int y = 0; y < Y; y++)
        //    {
        //        for (int x = 0; x < X; x++)
        //        {
        //            if (map[y][x] == '*')
        //            {
        //                sx = x;
        //                sy = y;
        //                break;
        //            }
        //        }
        //    }

        //    solve();
        //    if (reached)
        //    {
        //        return steps;
        //    }
        //    return -1;
        //}

        //private static void solve()
        //{
        //    yQ.Enqueue(sy);
        //    xQ.Enqueue(sx);
        //    visited[sy, sx] = true;
        //    while (yQ.Count > 0)
        //    {
        //        int y = yQ.Dequeue();
        //        int x = xQ.Dequeue();
        //        if (map[y][x] == '#')
        //        {
        //            reached = true;
        //            break;
        //        }
        //        neighbors(y, x);
        //        remaining_current--;
        //        if (remaining_current == 0)
        //        {
        //            remaining_current = remaining_next;
        //            remaining_next = 0;
        //            steps++;
        //        }
        //    }
        //}

        ////traverse the neighbors, enqueue the possible values
        //private static void neighbors(int y, int x)
        //{
        //    for (int v = 0; v < 4; v++)
        //    {
        //        int tY = y + vY[v]; //transformed values (added the vectors)
        //        int tX = x + vX[v];
        //        if (
        //            (0 <= tY && tY < Y) &&
        //            (0 <= tX && tX < X) &&
        //            !visited[tY, tX] &&
        //            map[tY][tX] != 'X'
        //        )
        //        {
        //            yQ.Enqueue(tY);
        //            xQ.Enqueue(tX);
        //            visited[tY, tX] = true;
        //            remaining_next++;
        //        }
        //    }
        //}


        /// <summary>
        /// From the solutions on leetcode - v fast performance
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int GetFood_Faster(char[][] grid)
        {
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '*')
                    {
                        grid[i][j] = 'X'; // mark as visited
                        queue.Enqueue(new int[] { i, j });
                        break;
                    }
                }
            }
            int steps = 0;
            while (queue.Count > 0)
            {

                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int[] curr = queue.Dequeue();

                    if (grid[curr[0]][curr[1]] == '#')
                        return steps;

                    int[] dx = new int[4] { 0, 0, 1, -1 };
                    int[] dy = new int[4] { 1, -1, 0, 0 };

                    for (int j = 0; j < 4; j++)
                    {
                        int ddx = curr[0] + dx[j];
                        int ddy = curr[1] + dy[j];
                        if (ddx >= 0 && ddx < grid.Length && ddy >= 0 && ddy < grid[0].Length && grid[ddx][ddy] != 'X')
                        {

                            if (grid[ddx][ddy] == 'O')
                            {
                                grid[ddx][ddy] = 'X';
                            }

                            queue.Enqueue(new int[] { ddx, ddy });
                        }
                    }
                }
                steps++;
            }
            return -1;
        }
    }
}
