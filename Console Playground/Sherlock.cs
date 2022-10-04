using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    internal class Sherlock
    {
        public static int sherlockAndAnagrams(string s)
        {
            int total = 0;
            Dictionary<string, int> ssFreq = new Dictionary<string, int>();// frequency map of all alphabetized substrings

            for (int ss = 1; ss < s.Length; ss++)
            { // ss for the substr length
                for (int i = 0; i < s.Length+1 - ss; i++)
                { // i for the index on the string
                    string substr = s.Substring(i, ss);
                    char[] chars = substr.ToArray();
                    Array.Sort(chars);
                    substr = new string(chars); // sort the substring to match with other possible anagrams
                    if (ssFreq.ContainsKey(substr))
                    {
                        ssFreq[substr]++;
                    }
                    else
                    {
                        ssFreq.Add(substr, 1);
                    }
                }
            }

            IEnumerable<KeyValuePair<string, int>> filteredFreq = ssFreq.Where(d => d.Value > 1);
            foreach (KeyValuePair<string, int> kvp in filteredFreq)
            {
                int n = kvp.Value;
                int perms = GetBinCoeff(n, 2);
                total += perms;
            }
            return total;
        }

        public static int GetBinCoeff(int N, int K)
        {
            int r = 1;
            int d;
            if (K > N) return 0;
            for (d = 1; d <= K; d++)
            {
                r *= N--;
                r /= d;
            }
            return r;
        }
    }
}
