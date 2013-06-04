using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Command
{
    class ComputerOffCommand:Command
    {
        Computer computer;
        public ComputerOffCommand(Computer computer)
        {
            this.computer = computer;
        }
        public void Execute()
        {
            computer.Off();
        }
    }
}
