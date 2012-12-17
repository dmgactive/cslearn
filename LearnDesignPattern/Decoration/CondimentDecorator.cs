using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDesignPattern.Decoration
{
    public abstract class CondimentDecorator:Beverage
    {
        public override abstract string GetDescription();
    }
}
