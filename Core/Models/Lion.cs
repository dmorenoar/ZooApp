using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Core.Interfaces;
using ZooApp.Core.Interfaces;

namespace Zoo.Core.Models
{
    public class Lion : Mammal, IFeedable, IVaccinable
    {
        private const string SpeciesName = "Panthera leo";
        private const string Prompt = "The 🦁 ";
        private const string Sound = "says: ROARRR!";
        public bool HasSharpClaws { get; set; }
        public bool IsHungry { get; set; } = true;
        public DateTime? LastVaccinateDate { get ; set; }
        public override string? SpecialCare { get ; set; }

        public Lion(string name, int age, double weight, int neurons = 10, string? specialCare = null, bool hasSharpClaws = true): base(name,age,weight, SpeciesName, neurons)
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
            Console.WriteLine($"{Prompt} {Name} {Sound}");
        }

        public override string ToString()
        {
            return base.ToString() + $", HasSharpClaws: {HasSharpClaws}";
        }

        public override void Nurse()
        {
            Console.WriteLine($"{Prompt} is nursing his baby 🍼");
        }

        public void Feed(string food)
        {
            Console.WriteLine((IsHungry) ? $"{Prompt} {Name} is eating {food}." : 
                $"{Prompt} {Name} is not hungry right now.");
        }

        public void Vaccinate(string vaccine)
        {
            LastVaccinateDate = DateTime.Now;
            Console.WriteLine($"{Prompt} {Name} is vaccinated against {vaccine} right now {LastVaccinateDate}.");
        }

        public override int GetBeatsPerMinute() => 40;



        // Sealed method: The Lion class cannot override the Breath method from Mammal class
        /* public override void Breath()
         {
                        Console.WriteLine($"{Prompt} Breathing through Lungs....");
         }
        */
    }
}