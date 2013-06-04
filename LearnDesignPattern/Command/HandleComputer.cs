using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Command
{
    class HandleComputer:ILearn
    {
        public void Learn()
        {
            ComputerControl control = new ComputerControl();
            Computer computer = new Computer();

            ComputerOnCommand onCommand = new ComputerOnCommand(computer);
            ComputerOffCommand offCommand = new ComputerOffCommand(computer);

            control.SetCommand(onCommand, offCommand);

            control.PowerOn();
            control.PowerOff();
        }
    }
}
