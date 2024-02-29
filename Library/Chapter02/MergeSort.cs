using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chapter02
{
    public class MergeSort
    {
        public int[] Sort(int[] data, int start, int end)
        {
            if (start < end)
            {
                // Automatic flooring in C# with integer division
                int mid = (start + end) / 2;

                Sort(data, start, mid);
                Sort(data, mid + 1, end);

                Merge(data, start, mid, end);
            }

            return data;
        }

        private static void Merge(int[] data, int start, int mid, int end)
        {
            int nLeft = mid - start + 1;
            int nRight = end - mid;

            int[] left = new int[nLeft];
            int[] right = new int[nRight];

            for (int x = 0; x < nLeft; x++)
            {
                left[x] = data[start + x];
            }

            for (int y = 0; y < nRight; y++)
            {
                right[y] = data[mid + y + 1];
            }

            int i = 0;
            int j = 0;
            int k = start;

            while (i < nLeft && j < nRight)
            {
                if (left[i] <= right[j])
                {
                    data[k] = left[i];
                    i++;
                }
                else
                {
                    data[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < nLeft)
            {
                data[k] = left[i];
                i++;
                k++;
            }
            while (j < nRight)
            {
                data[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
