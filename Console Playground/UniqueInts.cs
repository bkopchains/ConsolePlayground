namespace Console_Playground
{
    public class UniqueInts
    {
        public static int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            Dictionary<int, int> freqDict = new Dictionary<int, int>();
            foreach (int val in arr)
            {
                if (freqDict.ContainsKey(val))
                {
                    freqDict[val]++;
                }
                else
                {
                    freqDict.Add(val, 1);
                }
            }

            List<KeyValuePair<int,int>> ordered = freqDict.OrderBy(kvp => kvp.Value).ToList();

            int minCount = arr.Length - k;
            for (int i = arr.Length; i > minCount; i--)
            {
                KeyValuePair<int, int> curr = ordered[i];
                int 
                if ((peeked && dq != peek) || (!peeked && pq.Count == 0))
                {
                    freqDict.Remove(dq);
                }
            }
            return freqDict.Count;
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            //two dictionaries?
            Dictionary<int, int> numberFreq = new Dictionary<int, int>();
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            foreach (int num in nums)
            {
                if (numberFreq.ContainsKey(num))
                {
                    numberFreq[num] += 1;
                }
                else
                {
                    numberFreq.Add(num, 1);
                }
                pq.Enqueue(num, numberFreq[num]);
            }
            int[] output = new int[k];
            for (int i = 0; i < k; i++)
            {
                output[i] = pq.Dequeue();
                while(pq.Count > 0 && pq.Peek() == output[i])
                {
                    output[i] = pq.Dequeue();
                }
            }
            return output;
        }
    }
}
