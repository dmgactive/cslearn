using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnAlgorithm.Mergesort
{
    class MyMergeSort:ILearn
    {
        public void Learn()
        {
            int[] a = {5,12,1,8,0,20,5,23,9,2,33,99,13};
            int[] temp=new int[20];
            MergeSort(a, 0, a.Length - 1, temp);

            foreach (int now in a)
            {
                Console.WriteLine(now);
            }
        }

        public void MergeSort(int[] a,int first,int last,int[] temp)
        {
            if (first < last)
            {
                int mid = (first + last) / 2;
                MergeSort(a, first, mid, temp);
                MergeSort(a, mid + 1, last, temp);
                MergeArray(a, first, mid, last, temp);
            }
        }

        public void MergeArray(int[] a,int first,int mid,int last,int[] temp)
        {
            int i = first, j = mid + 1, k = 0;

            while (i <= mid && j <= last)
            {
                if (a[i] < a[j])
                {
                    temp[k++] = a[i++];
                }
                else
                {
                    temp[k++] = a[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = a[i++];
            }

            while (j <= last)
            {
                temp[k++] = a[j++];
            }

            for (int v = 0; v < k; v++)
            {
                a[first + v] = temp[v];
            }
        }
    }
}
