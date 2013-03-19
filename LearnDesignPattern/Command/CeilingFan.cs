using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Command
{
    class CeilingFan
    {
        private readonly static int HIGH = 3;
        private readonly static int MEDIUM = 2;
        private readonly static int LOW = 1;
        private readonly static int OFF = 0;

        string location;
        int speed;

        public CeilingFan(string location)
        {
            this.location = location;
            speed = OFF;
        }

        public void High()
        {
            speed = HIGH;
            Console.WriteLine("Living room ceiling fan is HIGH.");
        }

        public void Medium()
        {
            speed = MEDIUM;
            Console.WriteLine("Living room ceiling fan is MEDIUM.");
        }

        public void Low()
        {
            speed = LOW;
            Console.WriteLine("Living room ceiling fan is LOW.");
        }

        public void Off()
        {
            speed = OFF;
            Console.WriteLine("Living room ceiling fan is OFF.");
        }

        public int GetSpeed()
        {
            return speed;
        }
    }
}
