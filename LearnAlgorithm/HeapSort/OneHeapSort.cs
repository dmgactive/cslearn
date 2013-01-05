using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnAlgorithm.HeapSort
{
    class OneHeapSort:ILearn
    {
        public void Learn()
        {
            int[] a = { 2,88,5, 12, 1, 8, 0, 20, 66, 5, 23, 9, 2, 33, 99, 13 };
            HeapSort(a);
            foreach (int b in a)
            {
                Console.WriteLine(b);
            }
        }

        public void MaxHeapify(int[] array, int i,int heapSize)
        {
            int leftIndex = 2 * i;
            int rightIndex = leftIndex + 1;
            int highestIndex = i;


            if (heapSize >= leftIndex && array[i] < array[leftIndex])
            {
                highestIndex = leftIndex;
            }

            if (heapSize >= rightIndex && array[highestIndex] < array[rightIndex])
            {
                highestIndex = rightIndex;
            }

            if (highestIndex != i)
            {
                swap(array, i, highestIndex);
                MaxHeapify(array, highestIndex,heapSize);
            }
        }

        public void BuildHeap(int[] array)
        {
            int length = array.Length;
            int start = length / 2 - 1;
            for (; start >= 0; start--)
            {
                MaxHeapify(array, start,length-1);
            }
        }

        public void HeapSort(int[] array)
        {
            BuildHeap(array);
            int heapSize = array.Length-1;
            swap(array, 0, heapSize);
            heapSize--;
            for (; heapSize > 0; heapSize--)
            {
                MaxHeapify(array, 0,heapSize);
                swap(array, 0, heapSize);
            }
        }

        public void swap(int[] array, int m, int n)
        {
            int temp = array[m];
            array[m] = array[n];
            array[n] = temp;
        }

    }
}
