using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Templete
{
    public class Coffee:CaffeineBeverage
    {
        public override void brew()
        {
            Console.WriteLine("Dripping coffee through filter.");
        }

        public override void addCondiments()
        {
            Console.WriteLine("Adding sugar and milk.");
        }
    }
}
