using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Core.Interfaces;
using ZooApp.Core.Interfaces;
using ZooApp.UI;

namespace Zoo.Core.Models
{
    public class Lion : Mammal, IFeedable, IVaccinable
    {
        private const string SpeciesName = "Panthera leo";

        private const string Sound = "says: ROARRR!";
        public bool HasSharpClaws { get; set; }
        public bool IsHungry { get; set; } = true;
        public DateTime? LastVaccinateDate { get; set; }
        public override string? SpecialCare { get; set; }

        public Lion(string name, int age, double weight, int neurons = 10, string? specialCare = null, bool hasSharpClaws = true) : base(name, age, weight, SpeciesName, neurons)
        {
            HasSharpClaws = hasSharpClaws;
            SpecialCare = specialCare;
        }

        //The lion can change his species because can access the protected set accessor of Species property from Animal class
        public void ChangeMySpecies(string newSpecies)
        {
            //We can decide some rules for changing species
            if (newSpecies.Equals("Dog"))
            {
                Console.WriteLine("A lion can't be a dog");
                return;
            }
            this.Species = newSpecies;
        }


        public override void MakeSound()
        {
            Console.WriteLine($"{UIConfig.Prompt.PromptLion} {Name} {Sound}");
        }


        public override void Nurse()
        {
            Console.WriteLine($"{UIConfig.Prompt.PromptLion} is nursing his baby 🍼");
        }

        public void Feed(string food)
        {
            Console.WriteLine((IsHungry) ? $"{UIConfig.Prompt.PromptLion} {Name} is eating {food}." :
                $"{UIConfig.Prompt.PromptLion} {Name} is not hungry right now.");
        }

        public void Vaccinate(string vaccine)
        {
            LastVaccinateDate = DateTime.Now;
            Console.WriteLine($"{UIConfig.Prompt.PromptLion} {Name} is vaccinated against {vaccine} right now {LastVaccinateDate}.");
        }

        public override int GetBeatsPerMinute() => 40;


        // Sealed method: The Lion class cannot override the Breath method from Mammal class
        /* public override void Breath()
         {
                        Console.WriteLine($"{Prompt} Breathing through Lungs....");
         }
        */

        public override string ToString() => $"{UIConfig.Prompt.PromptLion} has te name: {Name}";

        // Override Equals method to compare two Lion objects based on their properties
        //If we not override the Equals method, it will compare the references of the objects, not their properties. 
        public override bool Equals(object? obj)
        {
            if (obj is not Lion otherLion) return false;

            return Name == otherLion.Name && Age == otherLion.Age && Weight == otherLion.Weight;
        }

        //RULE: If we override the Equals method, we must also override the GetHashCode method to maintain the contract between them. 
        //If two lions have the same name, age and weight, they are considered equal, and they should return the same hash code.
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, Weight);

        }

    }
}