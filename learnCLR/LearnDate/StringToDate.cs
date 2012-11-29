using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnCLR.LearnDate
{
    class StringToDate:ILearn
    {
        public void Learn()
        {
            string dateStr = "2012-08-06 03:09:27,297";




            string date = string.Format("{0:yyyy-MM-dd}", DateTime.ParseExact(dateStr, "yyyy-MM-dd HH:mm:ss,fff", null));

            

            
            Console.WriteLine(DateTime.ParseExact(dateStr, "yyyy-MM-dd HH:mm:ss,fff", null).Date);
        }
    }
}
