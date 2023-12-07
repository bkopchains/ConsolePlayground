namespace Console_Playground
{
    internal class LargestVariance
    {
        public int GetVariance(string s)
        {
            char max = ' ';
            char min = ' ';

            //frequency dict
            Dictionary<char, int> freq = new Dictionary<char, int>();
            Queue<char> minQueue = new Queue<char>();

            foreach (char c in s)
            {
                if (!freq.ContainsKey(c))
                {
                    freq.Add(c, 0);
                }
                freq[c] += 1;

                //increment max if found
                if (max == ' ')
                {
                    max = c;
                }
                else if (min == ' ')
                {
                    min = c;
                    minQueue.Enqueue(c);
                }

                if (max == c)
                {
                    //do nothing
                } 
                else if (min == c)
                {
                    bool found = false;
                    while(minQueue.Count > 0)
                    {
                        char dq = minQueue.Dequeue();
                        if(freq[dq] < freq[c])
                        {
                            min = dq;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        minQueue.Enqueue(c);
                    }
                }
                else
                {
                    if (freq[c] > freq[max])
                    {
                        max = c;
                    }
                    else if (freq[c] < freq[min])
                    {
                        minQueue.Clear();
                        min = c;
                        minQueue.Enqueue(c);
                    } else if (freq[c] == freq[min])
                    {
                        minQueue.Enqueue(c);
                    }
                }
            }
            if (freq[max] <= 1 || max == min)
            {
                return 0;
            }
            return freq[max] - freq[min];
        }
    }
}
