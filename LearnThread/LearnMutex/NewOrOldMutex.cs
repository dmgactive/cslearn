using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LearnThread.LearnMutex
{
    public class NewOrOldMutex:ILearn
    {
        private const string mutexName = "MyMutex";

        #region Create Same Mutex name Method
        public void OneMutex()
        {
            bool isNew = false;
            //initially, use Mutex oneMutex = new Mutex(true, mutexName, out isNew);
            Mutex oneMutex = new Mutex(false, mutexName, out isNew);

            
            if (isNew)
            {
                Console.WriteLine("OneMutex create a new mutex:{0}",mutexName);
            }
            else
            {
                Console.WriteLine("OneMutex can't create a new mutex:{0}",mutexName);
            }
            Console.WriteLine("OneMutex wait to get mutex.");
            oneMutex.WaitOne();
            Console.WriteLine("OneMutex get mutex.");
            //Thread.Sleep(5000);
            oneMutex.ReleaseMutex();
            Console.WriteLine("OneMutex release mutex.");
            Thread.Sleep(10000);
            Console.WriteLine("OneMutex run over.");
        }

        public void TwoMutex()
        {
            bool isNew = false;
            Mutex twoMutex = new Mutex(false, mutexName, out isNew);

            
            if (isNew)
            {
                Console.WriteLine("TwoMutex create a new mutex:{0}", mutexName);
            }
            else
            {
                Console.WriteLine("TwoMutex can't create a new mutex:{0}", mutexName);
            }
            Console.WriteLine("TwoMutex wait to get mutex.");
            twoMutex.WaitOne();
            Console.WriteLine("TwoMutex get mutex.");
            twoMutex.ReleaseMutex();
            Console.WriteLine("TwoMutex release mutex.");
        }
        #endregion

        #region Check Close Handle

        public void CloseMutex()
        {
            bool isNew = false;
            Mutex closeMutex = new Mutex(true, mutexName, out isNew);

            
            if (isNew)
            {
                Console.WriteLine("CloseMutex create a new mutex:{0}", mutexName);
            }
            else
            {
                Console.WriteLine("CloseMutex can't create a new mutex:{0}", mutexName);
            }
            closeMutex.WaitOne();

            closeMutex.ReleaseMutex();

            Console.WriteLine("CloseMutex release mutex.");

            Thread.Sleep(5000);

            closeMutex.Close();

            Console.WriteLine("Close mutex");
        }

        public void NextMutex()
        {
            Console.WriteLine("Enter into NextMutex.");
            bool isNew = false;
            Mutex nextMutex = new Mutex(true, mutexName, out isNew);

            //Thread.Sleep(6000);

            
            if (isNew)
            {
                Console.WriteLine("NextMutex create a new mutex:{0}", mutexName);
            }
            else
            {
                Console.WriteLine("NextMutex can't create a new mutex:{0}", mutexName);
            }
            nextMutex.WaitOne();

            Thread.Sleep(6000);
            
            nextMutex.ReleaseMutex();
            
        }
        #endregion

        #region ILearn Members

        public void Learn()
        {
            //TestCloseHandle();
            TestOne();
        }

        #endregion

        #region Composite Methods

        private void TestOne()
        {
            //OneMutex();
            //TwoMutex();

            Thread oneThread = new Thread(new ThreadStart(OneMutex));
            oneThread.Start();

            //Thread.Sleep(5000);

            Thread twoThread = new Thread(new ThreadStart(TwoMutex));
            twoThread.Start();
        }

        private void TestCloseHandle()
        {
            Thread oneThread = new Thread(new ThreadStart(CloseMutex));
            oneThread.Start();

            Thread.Sleep(500);

            Thread twoThread = new Thread(new ThreadStart(NextMutex));
            twoThread.Start();
        }

        #endregion
    }
}
