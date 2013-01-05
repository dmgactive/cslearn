using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnAlgorithm.Mergesort;
using LearnAlgorithm.HeapSort;

namespace LearnAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            ILearn learn = new OneHeapSort();
            learn.Learn();

            Console.ReadLine();
        }
    }
}
