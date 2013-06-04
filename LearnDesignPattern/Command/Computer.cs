using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Command
{
    class Computer
    {
        public void On()
        {
            Console.WriteLine("Open the computer.");
        }

        public void Off()
        {
            Console.WriteLine("Close the computer.");
        }
    }
}
