using System.Collections.Concurrent;
using Zoo.Core.Interfaces;
using Zoo.Core.Models;
using ZooApp.Core.Interfaces;
using ZooApp.Tools;

namespace Zoo.UI
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Animal[] zoo = new Animal[3];

            try
            {
                Lion simba = Utils.BuildLionWithValidation();

                Lion scar = new Lion("Scar", 5, 190.5);

                Console.WriteLine(simba.IsOverWeight);

                string inputNickName;

            do
            {
                Console.WriteLine("Insert the lion nickname (min 2 characters):");
                inputNickName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputNickName) || inputNickName.Length < 2)
                {
                    Console.WriteLine("Nickname must be at least 2 characters long. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(inputNickName) || inputNickName.Length < 2);

            simba.Nickname = inputNickName;

            Console.WriteLine($"The {simba.Name} nickname is: {simba.Nickname}");

            Lion mufasa = new Lion("Mufasa", 45, 300.2);

            zoo[0] = simba;

            mufasa.ChangeMySpecies("Panthera leo leo");

            if (simba.GetType() == typeof(Lion))
            {
                Console.WriteLine("Simba is a Lion");
            }

            Console.WriteLine(simba.ToString());
            Console.WriteLine(mufasa.ToString());

            Elephant dumbo = new Elephant("Dumbo", 110, 300.2);

            //TotalAnimals is a static property, we can access it without creating an instance
            Console.WriteLine(Animal.TotalAnimals);


            Console.WriteLine(dumbo.ToString());

            Console.WriteLine("Feed the animals");
            simba.Eat("meat");

            dumbo.Eat("banana");


            simba.Nurse();

            dumbo.Nurse();

            simba.IsHungry = false;
            simba.Feed("meat");

            simba.Vaccinate("Rabies");

            //(Polimorphism with Classes)
            Animal[] zooAnimals = { simba, mufasa, dumbo };

            // Search animals can be feed if they implement IFeedable
            foreach (Animal animal in zooAnimals)
            {
                if (animal is IFeedable feedableAnimal)
                {
                    feedableAnimal.Feed("special food");
                }
            }

            //Animal implement IFeedable and this animal is hungry
            //Pattern Matching with "is". Ask to the object if it implements IFeedable
            foreach (Animal animal in zooAnimals)
            {
                if (animal is IFeedable feedableAnimal && feedableAnimal.IsHungry)
                {
                    feedableAnimal.Feed("emergency food");
                }
            }

            //Old casting way (not recommended) - Strict type comparison
            //Trows NullReferenceException if animal is null
            foreach (Animal animal in zooAnimals)
            {
                if (animal.GetType() == typeof(Lion))
                {
                    Lion lionAnimal = (Lion)animal;
                    Console.WriteLine($"The lion {lionAnimal.Name} says:");
                    lionAnimal.MakeSound();
                }
            }


            //Pattern Matching with "is". Ask to the object if it is a Lion
            //Recommended way, this is more flexible and allows inheritance
            //Security against null (NullReferenceException)
            foreach (Animal animal in zooAnimals)
            {
                if (animal is Lion lionAnimal)
                {
                    Console.WriteLine($"The lion {lionAnimal.Name} says:");
                    lionAnimal.MakeSound();
                }
            }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error creating lion: {ex.Message}");
                Console.WriteLine("Please try again.\n");
            }

        }
    }
}