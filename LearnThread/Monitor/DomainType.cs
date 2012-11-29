#define DOMAIN_NEUTRAL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;



namespace LearnThread.Monitor
{
    public class DomainType:ILearn
    {
        private const string sEventName = "SharedEvent";


        
        #region ILearn Members
#if DOMAIN_NEUTRAL
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
#endif
        public void Learn()
        {
            EventWaitHandle wh=new EventWaitHandle(false,EventResetMode.ManualReset,sEventName);

            Console.WriteLine("#1: acquiring lock");
            lock (typeof(Program))
            {
                AppDomain ad2 = AppDomain.CreateDomain("2");
                ThreadPool.QueueUserWorkItem(AppDomainWorker, ad2);

                Console.WriteLine("#1: waiting for event");
                wh.WaitOne();
                Console.WriteLine("#1: exiting lock");
            }
        }

        #endregion

        private void AppDomainWorker(object obj)
        {
            AppDomain ad = (AppDomain) obj;

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
