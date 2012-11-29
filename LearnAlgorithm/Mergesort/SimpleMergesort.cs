using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnAlgorithm.Mergesort
{
    class SimpleMergesort:ILearn
    {
        public void Learn()
        {
            int[] a={1,4,5,9,10,34};
            int[] b = { 1,4,7,12,44,100};
            int[] c=new int[20];
            MergeSortTwo(a, b, c);

            foreach (int now in c)
            {
                Console.WriteLine(now);
            }
        }

        public void MergeSort(int[] a,int[] b,int[] c) 
        {
            int aLength = a.Length;
            int bLength = b.Length;

            int i = 0, j = 0, k = 0;

            for (; i < aLength && j < bLength; k++) // && not ||
            {
                if (a[i] < b[j])
                {
                    c[k] = a[i];
                    i++;
                    //write wrong
                    //k++;
                }
                else
                {
                    c[k] = b[j];
                    j++;
                    //k++;
                }
                //else if (b[j] < a[i])
                //{
                //    c[k] = b[j];
                //    j++;
                //    //k++;
                //}

                // write wrong
                //if (b[j] < a[i])
                //{
                //    c[k] = b[j];
                //    j++;
                //    //k++;
                //}
            }

            while (i < aLength)
            {
                c[k] = a[i];
                i++;
                k++;
            }

            while (j < bLength)
            {
                c[k] = b[j];
                j++;
                k++;
            }

            
        }

        public void MergeSortTwo(int[] a, int[] b, int[] c)
        {
            int aLength = a.Length;
            int bLength = b.Length;

            int i = 0, j = 0, k = 0;
            while (i < aLength && j < bLength)
            {
                if (a[i] < b[j])
                {
                    c[k++] = a[i++];
                }
                else
                {
                    c[k++] = b[j++];
                }
            }

            while (i < aLength)
            {
                c[k++] = a[i++];
            }

            while (j < bLength)
            {
                c[k++] = b[j++];
            }
        }
    }
}
