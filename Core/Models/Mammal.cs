using System;
using System.Collections.Generic;
using System.Text;
using ZooApp.Core.Models;

namespace Zoo.Core.Models
{

    public abstract class Mammal : Animal
    {
        /*EXAMPLE 1 COMPOSITION: receiving the value with abstract method from specific class*/
        protected Heart Heart { get; set; }

        /*EXAMPLE 2 COMPOSITION: receiving the value in the constructor*/
        protected Brain Brain {  get; set; }

        protected Mammal(string name, int age, double weight, string species, int neurons) : base(name, age, weight, species)
        {
            //The Heart is created here because all mammals have a heart
            //If the Mammal is destroyed, the Heart will be destroyed too
            Heart = new Heart();
            Heart.BeatsPerMinute = GetBeatsPerMinute();

            Brain = new Brain();
            Brain.Neurons = neurons;
        }

        //We force the derived classes to implement this method because each mammal can have a different heart rate
        public abstract int GetBeatsPerMinute();


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