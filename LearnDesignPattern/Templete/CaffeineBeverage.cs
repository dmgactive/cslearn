using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Templete
{
    public abstract class CaffeineBeverage
    {
        public void prepareRecipe() 
        {
            boilWater();
            brew();
            pourInCup();
            addCondiments();
        }

        public abstract void brew();
        public abstract void addCondiments();

        public void boilWater()
        {
            Console.WriteLine("Boiling water");
        }

        public void pourInCup()
        {
            Console.WriteLine("Pouring into cup.");
        }
    }
}
