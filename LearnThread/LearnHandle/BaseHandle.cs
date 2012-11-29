using System;
using System.Threading;

namespace LearnThread.LearnHandle
{
    public class BaseHandle:ILearn
    {
        private static WaitHandle[] waitHandles=new WaitHandle[]
        {
            new AutoResetEvent(false),
            new AutoResetEvent(false)                   
        };

        private Random r=new Random();
        
        #region ILearn Members

        public void Learn()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("Main thread is waiting for BOTH tasks to complete.");
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[0]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[1]);
            WaitHandle.WaitAll(waitHandles);
            Console.WriteLine("Thread {0} time {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            Console.WriteLine("Both tasks are completed (time waited={0})",(DateTime.Now-dt).TotalMilliseconds);
            
            dt = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine("The main thread is waiting for either task to complete.");
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[0]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoTask), waitHandles[1]);

            int index = WaitHandle.WaitAny(waitHandles);
            Console.WriteLine("Thread {0} time {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            Console.WriteLine("Task {0} finished first (time waited={1}).",
            index + 1, (DateTime.Now - dt).TotalMilliseconds);
        }

        #endregion

        private void DoTask(object state)
        {
            Console.WriteLine("Thread {0} start", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread {0} time {1}", Thread.CurrentThread.ManagedThreadId,DateTime.Now);
            AutoResetEvent are = (AutoResetEvent) state;
            int time = 1000*r.Next(2, 10);
            Console.WriteLine("Performing a task for {0} milliseconds.",time);
            Thread.Sleep(10000);
            are.Set();
            Console.WriteLine("Thread {0} finish",Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread {0} time {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
        }
    }
}
