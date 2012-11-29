using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using learnADO.Pool;

namespace learnADO
{
    class Program
    {
        static void Main(string[] args)
        {
            ILearn learn = new ConnectionPool();
            learn.Learn();

            Console.ReadLine();
        }
    }
}
