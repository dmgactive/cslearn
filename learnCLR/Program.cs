﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using learnCLR.LearnCast;
using learnCLR.LearnRegex;
using learnCLR.LearnDate;
using learnCLR.LearnMethod;
using learnCLR.LearnParameters;

namespace learnCLR
{
    class Program
    {
        static void Main(string[] args)
        {
            ILearn learn = new DefaultParameters();
            learn.Learn();

            Console.ReadLine();
        }
    }
}
