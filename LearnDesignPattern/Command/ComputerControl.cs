using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Command
{
    class ComputerControl
    {
        Command onCommand;
        Command offCommand;

        public ComputerControl()
        {
            this.onCommand = new NoCommand();
            this.offCommand = new NoCommand();
        }

        public void SetCommand(Command onCommand,Command offCommand)
        {
            this.onCommand = onCommand;
            this.offCommand = offCommand;
        }

        public void PowerOn()
        {
            onCommand.Execute();
        }

        public void PowerOff()
        {
            offCommand.Execute();
        }
    }
}
