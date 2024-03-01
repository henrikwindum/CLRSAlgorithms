using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chapter06
{
    public class MaxHeap
    {
        private int[] _array;
        private int _heapSize; 

        public MaxHeap(int[] inputArray)
        {
            _array = inputArray;
            _heapSize = _array.Length;
            BuildMaxHeap();
        }

        public void Sort()
        {
            for (int i = (_heapSize - 1); i > 0; i--)
            {
                Swap(i, 0);
                _heapSize--;
                MaxHeapify(0);
            }
        }

        public int GetMaximum()
        {
            if (IsEmpty()) throw new InvalidOperationException("Heap is empty.");
            return _array[0];
        }

        public int ExtractMaximum()
        {
            int max = GetMaximum();
            _array[0] = _array[_heapSize - 1];
            _heapSize--;
            MaxHeapify(0);
            return max;
        }

        public void Insert(int input)
        {
            if (_heapSize == _array.Length)
            {
                throw new InvalidOperationException("Heap is full. Cannot insert new element.");
            }

            _heapSize++;
            _array[_heapSize - 1] = input;

            int currentIndex = _heapSize - 1;
            while (currentIndex > 0 && _array[Parent(currentIndex)] < _array[currentIndex]) 
            {
                Swap(currentIndex, Parent(currentIndex));
                currentIndex = Parent(currentIndex);
            }
        }

        public bool IsEmpty()
        {
            return _heapSize == 0;
        }

        public int[] GetSortedArray()
        {
            return _array;
        }

        private void BuildMaxHeap()
        {
            for (int i = _heapSize / 2 - 1;  i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        private void MaxHeapify(int i)
        {
            int left = Left(i);
            int right = Right(i);

            int largest = i;

            if (left < _heapSize && _array[left] > _array[i])
            {
                largest = left;
            }

            if (right < _heapSize && _array[right] > _array[largest])
            {
                largest = right;
            }

            if (largest != i) {
                Swap(largest, i);
                MaxHeapify(largest);
            }
        }

        private void Swap(int i, int j)
        {
            int temp = _array[i];
            _array[i] = _array[j];
            _array[j] = temp;
        }

        private int Left(int i)
        {
            return 2 * i + 1;
        }

        private int Right(int i)
        {
            return 2 * i + 2;
        }

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }
    }
}
