namespace Console_Playground.Deloitte
{
    class Spikes
    {
        int count = 0;
        public int Solve(int[] A)
        {
            int max = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in A)
            { //o(n) ?
              //update the highest value while iterating
                max = Math.Max(i, max);
                //build a frequency dict
                if (dict.ContainsKey(i))
                {
                    dict[i] += 1;
                }
                else
                {
                    dict.Add(i, 1);
                }
            }
            dict[max] = 1; //set the highest value to only 1 - can't have it flat on the top /-\ => /\
            foreach (int Key in dict.Keys)
            { //o(n.distinct) ?
                count += Math.Min(2, dict[Key]); //max 2, one value on each side
            }

            return count;
        }
    }
}
