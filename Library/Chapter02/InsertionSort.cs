using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chapter02
{
    public class InsertionSort
    {
        public static int[] Sort(int[] data)
        {
            if (data.Length <= 1)
            {
                return data;
            }

            int key, j;

            for (int i = 0; i < data.Length; i++)
            {
                key = data[i];

                j = i - 1;

                while (j >= 0 && data[j] > key)
                {
                    data[j + 1] = data[j];
                    j--;
                }
                data[j + 1] = key;
            }

            return data;
        }
    }
}
