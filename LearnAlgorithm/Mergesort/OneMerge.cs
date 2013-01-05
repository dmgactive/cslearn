using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnAlgorithm.Mergesort
{
    class OneMerge:ILearn
    {
        public void Learn()
        {
            int[] a = { 5, 12, 1, 8, 0, 20,66, 5, 23, 9, 2, 33, 99, 13 };
            int[] temp = new int[30];
            MergeSort(a, 0, a.Length - 1, temp);
            foreach (int b in a)
            {
                Console.WriteLine(b);
            }
        }

        public void MergeArray(int[] array, int first, int mid, int last,int[] temp)
        {
            int i = first;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= last)
            {
                if (array[i] <= array[j])
                {
                    temp[k++] = array[i++];
                }
                else
                {
                    temp[k++] = array[j++];
                }
                
            }

            while (i <= mid)
            {
                temp[k++] = array[i++];
            }
            while (j <= last)
            {
                temp[k++] = array[j++];
            }

            int n = 0;
            while (n < k)
            {
                array[first++] = temp[n++];
            }
        }

        public void MergeSort(int[] array,int first,int last,int[] temp)
        {
            if (first < last)
            {
                int mid = (first + last) / 2;
                MergeSort(array, first, mid, temp);
                MergeSort(array, mid + 1, last, temp);
                MergeArray(array, first, mid, last, temp);
            }
        }
    }
}

