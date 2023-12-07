namespace Console_Playground.Deloitte
{
    public class ArrayTimes17
    {
        //A[] = [3,5,1] == 153
        //find sum of digits of (17*(A[] => number))
        public int Solve(int[] A)
        {
            double aValue = 0;

            for (int i = 0; i < A.Length; i++)
            {
                //10^i to pad zeroes on right for each consecutive number 
                //[3,5,1] ==> 3 + 50 + 100 ==> 153
                double multiplier = Math.Pow(10, i);
                aValue += A[i] * multiplier;
            }
            aValue *= 17;

            int sumDigits = 0;

            string stringified = aValue.ToString();
            foreach (char c in stringified)
            {
                sumDigits += c - '0'; //trick to convert char to int
            }
            return sumDigits;
        }


        public static int Solve2(int[] A)
        {
            int total = 0;

            for (int i = 0; i < A.Length; i++) // N loops here
            {
                int sum = 0;
                int n = A[i] * 17;
                // n will never be larger than 153 - three loops max
                // no need for a counter to carry over and figure out where it goes
                while (n != 0) 
                {
                    sum += n % 10;
                    n /= 10;
                }
                total += sum;
            }
            return total;
        }
    }
}