using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Command
{
    class Stereo
    {
        public void On()
        {
            Console.WriteLine("Living room stereo is on.");
        }

        public void SetCD()
        {
            Console.WriteLine("Living room stereo is set CD for input.");
        }

        public void SetVolume()
        {
            Console.WriteLine("Living room stereo is set volume.");
        }

        public void Off()
        {
            Console.WriteLine("Living room stereo is off.");
        }
    }
}
