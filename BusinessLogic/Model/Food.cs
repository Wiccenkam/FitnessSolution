using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Food
    {
        public string Name { get; }
        public double Fats { get; }
        public double Proteins { get; }
        public double Calorie { get; }
        public double Carbohydrates { get; }
        private double CaloriesPerGramm { get { return Calorie / 100.0; } }
        private double ProteinsPerGramm { get { return Proteins / 100.0; } }
        private double FatsPerGramm { get { return Fats / 100.0; } }
        private double CarbohydratesPerGramm { get { return Carbohydrates / 100.0; } }

        public Food(string name)
        {
            //Todo: Conditions

            Name = name;
        }
        public Food(string name, double fats, double proteins, double calories, double carbohydrates)
        {
            //Todo: Conditions
            Name = name;
            Fats = fats / 100.0;
            Proteins = proteins / 100.0;
            Calorie = calories / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
