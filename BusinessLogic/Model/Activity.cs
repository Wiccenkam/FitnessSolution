using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Activity
    {
        public string Name { get; }
        public double CaloriesPerMinute { get; }
        public Activity(string name, double caloriesperminute)
        {
            Name = name;
            CaloriesPerMinute = caloriesperminute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
