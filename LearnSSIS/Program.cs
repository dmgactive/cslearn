using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnSSIS.Execution;

namespace LearnSSIS
{
    class Program
    {
        static void Main(string[] args)
        {
            ILearn learn = new SsisValidation();
            learn.Learn();


            Console.ReadKey();
        }
    }
}
