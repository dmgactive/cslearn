using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnCLR.LearnParameters
{
    class DefaultParameters:ILearn
    {
        private static Int32 sn = 0;
        public void Learn()
        {
            MyDefault();
            MyDefault(8, "X");
            MyDefault(5, guid: Guid.NewGuid(), dt: DateTime.Now);
            MyDefault(sn++, sn++.ToString());
            MyDefault(s: (sn++).ToString(), x: sn++);
        }

        private void MyDefault(Int32 x = 9, string s = "A", DateTime dt = default(DateTime), Guid guid = new Guid())
        {
            Console.WriteLine("x={0},s={1},dt={2},guid={3}", x, s, dt, guid);
        }
    }
}
