using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Core.Models;

namespace ZooApp.Core.Models
{
    public class Veterinarian
    {
        public string Name { get; init; }
        public Veterinarian(string name)
        {
            Name = name;
        }

        //Check the health of the animal, if the animal is null, print a message indicating that there is no animal to check
        //? Allows the method to accept a null value for the animal parameter, and we can resist against null reference exception.
        public void CheckAnimalHealth(Animal? animal)
        {
            Console.WriteLine(animal is null ? "The cage is empty, there is no animal to check" : 
                $"The veterinarian {Name} is checking the animal: {animal.Name}");
        }
    }
}
