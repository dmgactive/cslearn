using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnAlgorithm.HeapSort
{
    class MyHeapSort:ILearn
    {
        public void Learn()
        {
            int[] a = { 78, 19, 2, 7, 12, 29, 6, 23, 3, 8 };

            HeapSort(a);

            foreach(int m in a)
            {
                Console.WriteLine(m);
            }
        }

        public void HeapSort(int[] a)
        {
            BuildMaxHeap(a);
            int heapSize = a.Length - 1;


            ExchangeData(a, 0, heapSize);
            heapSize--;

            while (heapSize > 0)
            {
                MaxHeapify(a, 0, heapSize);
                ExchangeData(a, 0, heapSize);
                heapSize--;
            }
        }

        private void MaxHeapify(int[] a, int location,int heapSize)
        {
            int leftLoc = 2 * location;
            int rightLoc = leftLoc + 1;
            
            if (location == 0)
            {
                leftLoc = 1;
                rightLoc = 2;
            }
            
            int largest = -1;

            if (leftLoc <= heapSize )
            {
                if(a[leftLoc] > a[location])
                {
                    largest = leftLoc;
                }
                else
                {
                    largest=location;
                }
                
            }

            if (rightLoc <= heapSize && a[rightLoc] > a[largest])
            {
                largest = rightLoc;
            }

            if (largest > location)
            {
                ExchangeData(a,largest, location);

                MaxHeapify(a, largest, heapSize);
            }
        }

        private void BuildMaxHeap(int[] a)
        {
            int heapSize = a.Length;

            int start = (heapSize / 2)-1;

            for (; start >= 0; start--)
            {
                MaxHeapify(a, start, heapSize-1);
            }
        }

        private void ExchangeData(int[] a, int m, int n)
        {
            int tempData;

            tempData = a[m];
            a[m] = a[n];
            a[n] = tempData;
        }
    }
}
