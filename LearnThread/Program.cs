#define DOMAIN_NEUTRAL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnThread.LearnMutex;
using LearnThread.Monitor;
using LearnThread.LearnHandle;
using LearnThread.LearnGC;
using System.Threading;

namespace LearnThread
{

    class Program
    {

        private const string sEventName = "SharedEvent";
#if DOMAIN_NEUTRAL
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
#endif
        static void Main(string[] args)
        {
            ILearn learn = new SingalWait();
            learn.Learn();

            Console.ReadKey();


            //EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.ManualReset, sEventName);

            //Console.WriteLine("#1: acquiring lock");
            //lock (typeof(Program))
            //{
            //    AppDomain ad2 = AppDomain.CreateDomain("2");
            //    ThreadPool.QueueUserWorkItem(AppDomainWorker, ad2);

            //    Console.WriteLine("#1: waiting for event");
            //    wh.WaitOne();
            //    Console.WriteLine("#1: exiting lock");
            //}

            //Console.ReadKey();
        }

        private static void AppDomainWorker(object obj)
        {
            AppDomain ad = (AppDomain)obj;

            ad.DoCallBack(delegate
            {
                EventWaitHandle wh = EventWaitHandle.OpenExisting(sEventName);

                Console.WriteLine("#2: acquiring lock");
                lock (typeof(Program))
                {
                    Console.WriteLine("#2: lock acquired, setting event");
                    wh.Set();
                    Console.WriteLine("#2: exiting lock");
                }
            });
        }
    }
}
