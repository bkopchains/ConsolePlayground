namespace Console_Playground
{
    public class SurroundedRegions
    {
        char[][] board;

        //think outside-in - invalidate everything touching the borders
        public void Solve(char[][] board)
        {
            this.board = board;
            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    if ((r == 0 || r == board.Length - 1 || c == 0 || c == board[0].Length - 1) && board[r][c] == 'O')
                    {
                        dfs(r, c);
                    }
                }
            }
            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    if (board[r][c] == 'O')
                    {
                        board[r][c] = 'X';
                    }
                    if (board[r][c] == '?')
                    {
                        board[r][c] = 'O';
                    }
                }
            }
        }
        //find all nearby 'O's and clear out when found
        //only to be called starting on an 'O'
        public void dfs(int row, int col)
        {

            bool inRange =
                row < board.Length && row >= 0 &&
                col < board[0].Length && col >= 0;

            if (inRange)
            {
                if (board[row][col] == 'X' || board[row][col] == '?')
                {
                    return;
                }
                else
                {
                    board[row][col] = '?';

                    dfs(row, col - 1);
                    dfs(row + 1, col);
                    dfs(row, col + 1);
                    dfs(row - 1, col);
                }
            }
        }
    }
}
