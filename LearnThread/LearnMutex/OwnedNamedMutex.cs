using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LearnThread.LearnMutex
{
    public class OwnedNamedMutex:ILearn
    {
        public void Learn()
        {
            // Set this variable to false if you do not want to request 
            // initial ownership of the named mutex.
            bool requestInitialOwnership = true;
            bool mutexWasCreated;

            // Request initial ownership of the named mutex by passing
            // true for the first parameter. Only one system object named 
            // "MyMutex" can exist; the local Mutex object represents 
            // this system object. If "MyMutex" is created by this call,
            // then mutexWasCreated contains true; otherwise, it contains
            // false.
            Mutex m = new Mutex(requestInitialOwnership,
                                "MyMutex",
                                out mutexWasCreated);

            Console.WriteLine(mutexWasCreated);
            // This thread owns the mutex only if it both requested 
            // initial ownership and created the named mutex. Otherwise,
            // it can request the named mutex by calling WaitOne.);
            if (!(requestInitialOwnership && mutexWasCreated))
            {
                Console.WriteLine("Waiting for the named mutex.");
                m.WaitOne();
            }

            // Once the process has gained control of the named mutex,
            // hold onto it until the user presses ENTER.
            Console.WriteLine("This process owns the named mutex. " +
                "Press ENTER to release the mutex and exit.");
            Console.ReadLine();

            // Call ReleaseMutex to allow other threads to gain control
            // of the named mutex. If you keep a reference to the local
            // Mutex, you can call WaitOne to request control of the 
            // named mutex.
            m.ReleaseMutex();

        }
    }
}
