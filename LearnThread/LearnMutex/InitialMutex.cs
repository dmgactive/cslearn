using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LearnThread.LearnMutex
{
    public class InitialMutex:ILearn
    {
        private readonly static Mutex mutex=new Mutex();
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

        }

        private void MyThreadProc()
        {
            for(int i=0;i<numIterations;i++)
            {
                UseResource();
            }
        }

        private static void UseResource()
        {
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
