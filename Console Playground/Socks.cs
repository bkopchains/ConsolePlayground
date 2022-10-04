using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    internal class Socks
    {
        public static int sockMerchant(int n, List<int> ar)
        {
            //101 in this case because 0 < n < 100 and 0 < ar[n] < 100
            int[] freq = new int[101];
            int totalPairs = 0;

            for(int i = 0; i < n; i++)
            {
                freq[ar[i]]++;
            }

            for (int i = 1; i < freq.Length; i++)
            {
                totalPairs += freq[i] / 2;
            }


            return totalPairs;
        }
    }
}
