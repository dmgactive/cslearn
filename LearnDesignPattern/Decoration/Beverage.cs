using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Decoration
{
    public abstract class Beverage
    {
        protected string description = "Unknown Beverage";

        public virtual  string GetDescription()
        {
            return description;
        }

        public abstract double Cost();
    }
}
