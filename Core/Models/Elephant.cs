using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Core.Models
{
    public class Elephant : Mammal
    {
        private const string SpeciesName = "Loxodonta africana";
        private const string Prompt = "The 🐘 ";
        private const string Sound = "says: PUFFF!";

        public bool HasTusks { get; set; }
        public Elephant(string name, int age, double weight, bool hasTusks = true) : base(name, age, weight, SpeciesName)
        {
            HasTusks = hasTusks;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Prompt} {Name} {Sound}"); 
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"{Prompt} loves the {food}");
        }

        public override string ToString()
        {
            return base.ToString() + $", HasTusks: {HasTusks}";
        }
    }
}