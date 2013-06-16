using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LearnDesignPattern.Templete
{
    class CoffeeWithHook:CaffeineBeverageWithHook
    {
        public override void brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        public override void addCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }

        public override bool customerWantsCondiments()
        {
            string answer = getUserInput();
            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private string getUserInput()
        {
            string answer = null;
            Console.WriteLine("Would you like milk and sugar with your coffee (y/n)? ");
            answer = Console.ReadLine();

            if (answer == null)
            {
                return "no";
            }

            return answer;
        }
    }
}
