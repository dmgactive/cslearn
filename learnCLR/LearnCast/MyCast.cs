using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnCLR.LearnCast
{
    class MyCast:ILearn
    {
        public void Learn()
        {
            object o1 = new object();
            object o2 = new Employee();
            object o3 = new Manager();
            object o4 = o3;

            Employee e1 = new Employee();
            Employee e2 = new Manager();
            Manager m1 = new Manager();

            //Employee e3 = new object();
            //Manager m2 = new object();

            Employee e4 = m1;
            //Manager m3 = e2;

            Manager m4 = (Manager)m1;
            Manager m5 = (Manager)e2;
            Manager m6 = (Manager)e1;

            Employee e5 = (Employee)o1;

            Employee e6 = (Manager)e2;


        }
    }

    class Employee { }

    class Manager : Employee { }
}
