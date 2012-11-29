using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LearnThread.LearnSemaphore
{
    public class BlockingBoundedQueue<T>
    {
        private Queue<T> m_queue=new Queue<T>();
        private Mutex m_mutex=new Mutex();
        private Semaphore m_producerSemaphore;
        private Semaphore m_consumerSemaphore;

        public BlockingBoundedQueue(int capacity)
        {
            m_producerSemaphore=new Semaphore(capacity,capacity);
            m_consumerSemaphore=new Semaphore(0,capacity);
        }

        public void Enqueue(T obj)
        {
            m_producerSemaphore.WaitOne();

            m_mutex.WaitOne();

            try
            {
                m_queue.Enqueue(obj);
            }
            finally 
            {
                m_mutex.ReleaseMutex();
            }

            m_consumerSemaphore.Release();
        }

        public  void Dequeue()
        {
            m_consumerSemaphore.WaitOne();

            m_mutex.WaitOne();

            try
            {
                m_queue.Dequeue();
            }
            finally 
            {
                m_mutex.ReleaseMutex();
            }

            m_producerSemaphore.Release();
        }
    }
}
