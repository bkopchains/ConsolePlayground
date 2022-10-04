using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    internal class Valleys
    {
        public static int countingValleys(int steps, string path)
        {
            int height = 0;
            int valleys = 0;
            for (int s = 0; s < steps; s++)
            {
                int prevHeight = height;
                if (path[s] == 'U')
                {
                    height++;
                } else if (path[s] == 'D')
                {
                    height--;
                }
                if(prevHeight < height && height == 0)
                {
                    valleys++;
                }
            }
            return valleys;
        }

        public static int LongestMountain(int[] arr)
        {

            int[] rising = new int[arr.Length];
            int[] falling = new int[arr.Length];
            int longest = 0;

            int f = arr.Length - 2;
            for (int r = 1; r < arr.Length; r++, f--)
            {
                if (arr[r] > arr[r - 1])
                {
                    rising[r] = rising[r - 1] + 1;
                }
                if (arr[f] > arr[f + 1])
                {
                    falling[f] = falling[f + 1] + 1;
                }
            }

            //EX: end up with
            //rising  [0,1,0,1,2,0,0]
            //falling [0,1,0,0,2,1,0]

            //find the areas where both aren't zero (peaks),
            //sum of the two peak values plus 1 will be the length

            for (int i = 0; i < arr.Length; i++)
            {
                if (rising[i] > 0 && falling[i] > 0)
                {
                    longest = Math.Max(longest, rising[i] + falling[i] + 1);
                }
            }

            return longest;
        }


    }
}
