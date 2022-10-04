namespace Console_Playground
{
    public class BinaryGap
    {
        int Count = 0;
        public int Solution(int N)
        {
            //convert to binary string
            string BinString = Convert.ToString(N, 2);
            //trim 0's from start and end
            BinString = BinString.TrimStart('0');
            BinString = BinString.TrimEnd('0');
            //split by 1s
            string[] gaps = BinString.Split('1');
            //return length of longest array
            foreach (string gap in gaps)
            {
                Count = Math.Max(gap.Length, Count);
            }
            
            return Count;
        }
    }
}
