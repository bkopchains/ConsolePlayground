using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Playground
{
    internal class ArrayMerge
    {
        public static long totalInversions = 0;
        public static long countInversions(List<int> arr)
        {
            sort(arr, 0, arr.Count() - 1);
            return totalInversions;
        }

        //merge subarrays
        private static void merge(List<int> arr, int iLeft, int iMiddle, int iRight)
        {

            //setup for the subarrays
            int[] L = new int[iMiddle - iLeft + 1];
            int[] R = new int[iRight - iMiddle];

            //populate the subarrays
            for (int i = 0; i < iMiddle - iLeft + 1; i++)
            {
                L[i] = arr[iLeft + i];
            }
            for (int j = 0; j < iRight - iMiddle; j++)
            {
                R[j] = arr[iMiddle + 1 + j];
            }

            //counters, loop over the sides and reorder based on value
            int iL = 0;
            int iR = 0;
            //counter for array, starting at left
            int iA = iLeft;

            //while both have length
            while (iL < L.Length && iR < R.Length)
            {
                if (L[iL] <= R[iR])
                {
                    arr[iA] = L[iL];
                    iL++;
                }
                else
                {
                    arr[iA] = R[iR];
                    totalInversions++;
                    iR++;
                }
                iA++;
            }

            //clean up sides if one is longer/left over
            while (iL < L.Length)
            {
                arr[iA] = L[iL];
                iL++;
                iA++;
            }
            while (iR < R.Length)
            {
                arr[iA] = R[iR];
                iR++;
                iA++;
            }
        }

        //sort arr from left to right indices
        private static void sort(List<int> arr, int iLeft, int iRight)
        {
            if (iLeft < iRight)
            {
                //get midpoint between indices
                int iMiddle = iLeft + (iRight - iLeft) / 2;

                //sort again on both halves
                sort(arr, iLeft, iMiddle);
                sort(arr, iMiddle + 1, iRight);

                merge(arr, iLeft, iMiddle, iRight);
            }
        }
    }
}
