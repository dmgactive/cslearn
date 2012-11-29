using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learnCLR.LearnMethod
{
    class TrickyConstructor:ILearn
    {
        public void Learn()
        {
            //Cat cat = new Cat(5);
            Cat cat = new Cat();
        }
    }

    public class Animal
    {
        int m = 0;
        string you = "sdf";
        int n;
        public Animal()
        {
            Console.WriteLine("base class");
        }

        public Animal(int i)
        {
            Console.WriteLine("parameter base class");
        }
    }

    public class Cat:Animal
    {
        int m = 0;
        string you = "sdf";
        int n;
        public Cat()
        {
            Console.WriteLine("derived class");
        }
        
    }
}
