using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnAlgorithm.Mergesort;

namespace LearnAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            ILearn learn = new MyMergeSort();
            learn.Learn();

            Console.ReadLine();
        }
    }
}
