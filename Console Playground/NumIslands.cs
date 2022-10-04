using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    public class NumIslands
    {
        public int numIslands = 0;
        char[][] grid;

        public int CountIslands(char[][] grid)
        {
            this.grid = grid;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        numIslands++;
                        dfs(r, c);
                    }
                }
            }
            return numIslands;
        }

        //find all nearby '1's and clear out when found
        public void dfs(int row, int col)
        {

            bool inRange =
                row < grid.Length && row >= 0 &&
                col < grid[0].Length && col >= 0;

            if (inRange && grid[row][col] != '0')
            {
                char current = grid[row][col];
                bool isIsland = current == '1';

                grid[row][col] = '0';

                dfs(row + 1, col);
                dfs(row - 1, col);
                dfs(row, col + 1);
                dfs(row, col - 1);
            }
        }
    }
}
