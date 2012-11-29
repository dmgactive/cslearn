using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LearnThread.LearnSemaphore
{
    public class AgainBoundedQueue<T>
    {
        private Semaphore producerSemaphore;
        private Semaphore consumerSemaphore;

        private Mutex mutex = new Mutex();

        private Queue<T> queue=new Queue<T>();

        public AgainBoundedQueue(int capacity)
        {
            producerSemaphore=new Semaphore(capacity,capacity);
            consumerSemaphore=new Semaphore(0,capacity);
        }

        public void Enqueue(T obj)
        {
            producerSemaphore.WaitOne();

            mutex.WaitOne();

            try
            {
                queue.Enqueue(obj);
            }
            finally 
            {
                
                mutex.ReleaseMutex();
            }

            consumerSemaphore.Release();

        }

        public void Dequeue()
        {
            consumerSemaphore.WaitOne();

            mutex.WaitOne();

            try
            {
                queue.Dequeue();
            }
            finally 
            {
                mutex.ReleaseMutex();
            }

            producerSemaphore.Release();
        }
    }
}
