using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Core.Models
{

    public abstract class Mammal : Animal
    {
        protected Mammal(string name, int age, double weight, string species) : base(name, age, weight, species)
        {

        }

        public virtual void Nurse()
        {
            Console.WriteLine($"The {this.GetType().Name} is nursing his baby...");
        }

        //Overriding the abstract method from Animal class
        // Sealed method: The derived classes from Mammal cannot override this method
        //We use sealed beacuse we want to provide a specific implementation of the Breath method for all mammals
        // This is because all mammals share the same breathing mechanism through lungs
        public sealed override void Breath()
        {
            Console.WriteLine("Breathing through Lungs....");
        }
    }
}