using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Command
{
    class ComputerOnCommand:Command
    {
        Computer computer;

        public ComputerOnCommand(Computer computer)
        {
            this.computer = computer;
        }

        public void Execute()
        {
            computer.On();
        }
    }
}
