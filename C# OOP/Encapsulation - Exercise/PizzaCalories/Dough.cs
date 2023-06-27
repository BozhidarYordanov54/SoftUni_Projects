using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseDoughCaloriesPerGram = 2;
        private Dictionary<string, double> flourTypeCalories;
        private Dictionary<string, double> backingTecniquesCalories;

        private double weight;
        private string flourType;
        private string backingTecnique;

        public Dough(string flourType, string backingTechnique, double grams)
        {
            flourTypeCalories = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
            backingTecniquesCalories = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

            Flour = flourType;
            Backing = backingTechnique;
            Weight = grams;

        }

        public string Flour
        {
            get { return flourType; }
            private set
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough!");
                }
                flourType = value.ToLower();
            }
        }

        public string Backing
        {
            get { return backingTecnique; }
            private set
            {
                if (!backingTecniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough!");
                }
                backingTecnique = value.ToLower();
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double flourTypeModifier = backingTecniquesCalories[backingTecnique];
                double techniqueModifier = flourTypeCalories[flourType];

                return (BaseDoughCaloriesPerGram * weight * flourTypeModifier * techniqueModifier);
            }
        }
    }
}



 