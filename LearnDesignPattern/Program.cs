using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnDesignPattern.Decoration;

namespace LearnDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ILearn learn = new MyDecorate();
            learn.Learn();

            Console.ReadKey();
        }
    }
}
