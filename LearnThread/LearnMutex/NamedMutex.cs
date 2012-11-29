using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LearnThread.LearnMutex
{
    public class NamedMutex:ILearn
    {
        #region ILearn Members

        public void Learn()
        {
            bool isNew = false;
            Mutex m=new Mutex(true,"MyMutex",out isNew);
            Console.WriteLine(isNew);

            Console.WriteLine("Waiting for the Mutex.");
            m.WaitOne();

            Console.WriteLine("This application owns the mutex. " +
            "Press ENTER to release the mutex and exit.");
            Console.ReadLine();

            m.ReleaseMutex();
            Console.WriteLine("Release the mutex.");
            m.Close();
            Console.WriteLine("Close the mutex.");

        }

        #endregion
    }
}
