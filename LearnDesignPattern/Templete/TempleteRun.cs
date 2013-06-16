using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Templete
{
    class TempleteRun:ILearn
    {
        public void Learn()
        {
            CaffeineBeverage tea = new Tea();
            CaffeineBeverage coffee = new Coffee();
            CaffeineBeverageWithHook coffeeHook = new CoffeeWithHook();
            tea.prepareRecipe();
            coffee.prepareRecipe();
            coffeeHook.prepareRecipe();
        }
    }
}
