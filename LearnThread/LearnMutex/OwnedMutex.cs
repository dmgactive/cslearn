using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LearnThread.LearnMutex
{
    public class OwnedMutex:ILearn
    {
        private readonly static Mutex mutex = new Mutex(true);
        private readonly static Mutex mutexTwo=new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;

        public void Learn()
        {
            for (int i = 0; i < numThreads; i++)
            {
                Thread myThread = new Thread(new ThreadStart(MyThreadProc));
                myThread.Name = String.Format("Thread{0}", i + 1);
                myThread.Start();
            }

            Console.WriteLine("Creating thread owns the Mutex.");
            Thread.Sleep(1000);

            Console.WriteLine("Creating thread releases the Mutex.\r\n");
            mutex.ReleaseMutex();


        }

        private void MyThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        private static void UseResource()
        {
            Console.WriteLine("{0} is waiting",
                Thread.CurrentThread.Name);
            mutex.WaitOne();

            Console.WriteLine("{0} has entered the protected area",
                Thread.CurrentThread.Name);

            Thread.Sleep(5000);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            mutex.ReleaseMutex();
        }
    }
}
