using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace learnCLR.LearnRegex
{
    class TestRegex:ILearn
    {
        public void Learn()
        {
            string line = "2012-08-06 03:09:27,297 [http-0.0.0.0-7901-1] [commonLoginLog] [INFO] - #BeforeAuthToAD##cpadmin#cpadmin##https://portal.retailsolutions.com#A##";

            string[] twoColumns = line.Split(new string[] {"#" },2, StringSplitOptions.None);

            string firstColumns = twoColumns[0].Trim();
            string secondColumns = twoColumns[1].Trim();

            string[] firstStrs = firstColumns.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string date = firstStrs[0] + " " + firstStrs[1];

            string[] logInfos = secondColumns.Split(new string[] { "#" }, StringSplitOptions.None);

            


            foreach (string column in logInfos)
            {
                Console.WriteLine(column+"");
            }
        }
    }
}
