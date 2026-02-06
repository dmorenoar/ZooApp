using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Core.Models
{
    public abstract class Animal
    {
        //Nullable reference type, can be null if no special care is needed
        public abstract string? SpecialCare { get; set; }

        //Auto-implemented property with only get accessor
        //We can only set the value in the constructor or will be default value (null for reference types, 0 for numeric types, etc)
        public DateTime BirthDate { get; }

        //Static auto-implemented property to keep track of total number of animals created.
        public static int TotalAnimals { get; private set; } = 0;

        public int Age { get; set; }

        //Auto-implemented property with default value
        //Bool by default is false, but we set it to true
        public bool hasTail { get; set; } = true;

        public readonly string? _name;
        //Auto-implemented property with init accessor, can only be set during object initialization
        //If we don't set a value during initialization, it will be " ", and can't be changed later
        //We should use backing field if we want to implement custom logic in the setter
        //Required keyword forces to set a value during initialization
        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name can't be empty!");
                }
                _name = value;

            }
        } //Not change after born

        //Auto-implemented properties with restricted access, only accessible within the class and derived classes (no outside access)
        public string Species { get; protected set; }

        //Auto-implemented properties with private set, only accessible within the class
        //In this case, we set the Id only in the constructor

        public int Id { get; }

        //Expression-bodied Property/member
        //Note: This property is read-only and computes its value baded in referencte to another properties
        //Each time we access this property, it will calculate the value based on a rule

        //Large way
        public bool isAdult
        {
            get
            {
                return Age >= 2;
            }
        }

        //Short way
        public bool IsOverWeight => _weight > 100;

        public string SizeCategory => _weight > 100 ? "Giant" : "Small";

        //Backing Field for a property with custom logic
        private string? _nickname;

        public string Nickname
        {
            get => _nickname;

            set
            {
                //This is our last wall of defense to ensure the nickname is valid
                if (value.Length < 2)
                {
                    Console.WriteLine($"The nickname is too short!");
                    _nickname = "NoNickName";

                }
                else
                {
                    _nickname = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                }

            }
        }

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("The weight can't be negative");
                    _weight = 0;
                }
                else
                {
                    _weight = value;
                }
            }

        }


        protected Animal(string name, int age, double weight, string species)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Species = species;
            BirthDate = DateTime.Now;
            TotalAnimals++;
        }

        //Abstract method: Each animal makes a sound. Child classes must implement this method.
        public abstract void MakeSound();

        //Virtual method: Eat method can be overridden by child classes if needed.
        public virtual void Eat(string food)
        {
            Console.WriteLine($"The {this.GetType().Name} is eating {food}.");
        }

        public override string ToString()
        {
            return $"[{this.GetType().Name}] Name: {Name}, Age: {Age}, Weight: {Weight}kg, Species: {Species}";
        }

        public abstract void Breath();

        public void ShowCareInstructionsIsNull()
        {
            //Checking nullable reference type
            //Check if the animal requires special care
            //if SpecialCare is null, print "Standard care", otherwise print the special care instructions
            Console.WriteLine(SpecialCare is null ? "Standar care" : SpecialCare);
        }

        public void ShowCareInstructionsWithNullCoalescing()
        {
            //Using null-coalescing operator to provide a default value if SpecialCare is null
            Console.WriteLine(SpecialCare ?? "Standard care");

        }
    }
}