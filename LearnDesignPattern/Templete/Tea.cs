using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Templete
{
    public class Tea:CaffeineBeverage
    {
        public override void brew()
        {
            Console.WriteLine("Steeping the tea.");
        }

        public override void addCondiments()
        {
            Console.WriteLine("Adding Lemon.");
        }
    }
}
