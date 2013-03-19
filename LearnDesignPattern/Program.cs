using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnDesignPattern.Decoration;
using LearnDesignPattern.Command;

namespace LearnDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ILearn learn = new RemoteLoader();
            learn.Learn();

            Console.ReadKey();
        }
    }
}
