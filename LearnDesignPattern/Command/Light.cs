using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Command
{
    class Light
    {
        public void On() 
        {
            Console.WriteLine("Living room light is on.");
        }

        public void Off()
        {
            Console.WriteLine("Living room light is off.");
        }
    }
}
