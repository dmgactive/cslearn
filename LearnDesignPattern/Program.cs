using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnDesignPattern.Decoration;
using LearnDesignPattern.Command;
using LearnDesignPattern.Templete;

namespace LearnDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ILearn learn = new TempleteRun();
            learn.Learn();

            Console.ReadKey();
        }
    }
}
