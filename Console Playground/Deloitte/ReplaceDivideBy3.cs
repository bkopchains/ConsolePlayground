namespace Console_Playground.Deloitte
{
    class ReplaceDivideBy3
    {
        int possible = 0;
        public int Solve(string S)
        {

            // modulo somehow?

            //something in common b/w all divisible numbers - sum of all digits divisible by 3

            //check the initial number
            int sum = 0;//sum is the base case
            foreach (char c in S)
            {
                //given every char is guaranteed to be a letter, can just cast here
                sum += c - '0'; //trick to convert char to int
            }
            checkPossible(sum);

            //same thing as above but swap out for all digits 0-9?
            for (int i = 0; i < S.Length; i++)
            { //not really o(n^2), more like o(9n)?
              //subtract current digit from sum, replace in sum with 0-9
                int currentDigit = S[i] - '0';
                int tempSum = sum - currentDigit;
                for (int j = 0; j <= 9; j++)
                {
                    if (j != currentDigit)
                    {
                        //this way, we're still technically checking all values, 
                        //but don't have to iterate over the string an extra time to get the sum
                        checkPossible(tempSum + j);
                    }
                }
            }
            return possible;
        }

        private void checkPossible(int tempSum)
        {
            if (tempSum % 3 == 0)
            {
                possible++;
            }
        }
    }
}
