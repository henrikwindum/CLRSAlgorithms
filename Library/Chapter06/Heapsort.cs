using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chapter06
{
    public class Heapsort
    {
        private int[] array;
        private int heapSize;

        public Heapsort(int[] inputArray)
        {
            array = inputArray;
            heapSize = inputArray.Length;
            BuildMaxHeap();
        }

        private void BuildMaxHeap()
        {
            for (int i = heapSize / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        private void MaxHeapify(int i)
        {
            int left = Left(i);
            int right = Right(i);
            int largest = i;

            if (left < heapSize && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < heapSize && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(ref array[i], ref array[largest]);
                MaxHeapify(largest);
            }
        }

        private void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        private int Parent(int i)
        {
            return i / 2;
        }

        private int Left(int i)
        {
            return 2 * i + 1;
        }

        private int Right(int i)
        {
            return 2 * i + 2;
        }

        public void Sort()
        {
            for (int i = heapSize - 1; i >= 0; i--)
            {
                Swap(ref array[0], ref array[i]);
                heapSize--;
                MaxHeapify(0);
            }
        }

        public int[] GetSortedArray()
        {
            return array;
        }

    }
}
