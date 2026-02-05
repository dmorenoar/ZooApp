using System.Collections.Concurrent;
using Zoo.Core.Interfaces;
using Zoo.Core.Models;
using ZooApp.Core.Interfaces;
using ZooApp.Tools;
using ZooApp.UI;

namespace Zoo.UI
{
    public class Program
    {
        
        
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Animal[] zoo = new Animal[3];

            /*Null Theory */
            Lion pepito = new Lion("Pepito", 3, 150.5, null, true);

            //If we try to access to the length of SpecialCare, we will get a NullReferenceException because SpecialCare is null
            //Console.WriteLine(pepito.SpecialCare.Length);

            //Null-Coalescing Operator (??) - If SpecialCare is null, it will return the string "No special care instructions"
            Console.WriteLine("Null-Coalescing Operator (??)");
            string careInstructions = null;
            Console.WriteLine(careInstructions ?? "No care defined");

            //Null-Coalescing Assignment Operator (??=) - If SpecialCare is null, it will assign the string "No special care instructions" to SpecialCare
            Console.WriteLine("Null-Coalescing Assignment Operator (??=)");
            careInstructions ??= "No care defined";
            Console.WriteLine(careInstructions);

            //Null-Conditional Operator (?.) - If SpecialCare is null, it will return null instead of throwing a NullReferenceException
            //We can use it to check if SpecialCare is null before trying to access its length
            //We can resist against NullReferenceException and we can check if the result is null
            Console.WriteLine("Null-Conditional Operator (?.)");
            string careInstructionsNotDefined = null;
            Console.WriteLine(careInstructionsNotDefined?.Length);


            pepito.ShowCareInstructionsWithNullCoalescing();
            pepito.ShowCareInstructionsIsNull();

            pepito.SpecialCare = "Needs extra attention during the winter season.";

            pepito.ShowCareInstructionsWithNullCoalescing();
            pepito.ShowCareInstructionsIsNull();

            /*Interfaces Theory*/

            /*Interface Default Interface Method*/
            Console.WriteLine("Need vaccination?");
            Console.WriteLine(((IVaccinable) pepito).NeedsVaccination);

            //Playing with casting and interfaces to show how we can access to the default implementation of the interface method
            IVaccinable vaccinablePepito = pepito;
            Console.WriteLine(vaccinablePepito.NeedsVaccination ? $"Yes, {((Lion)vaccinablePepito).Name} need vaccination" : "No, it's OK");


            //TO-DO

            /*Object class*/


            /*Equals*/


            /*GetHashCode*/

            /*ToString*/


            try
            {
                Console.WriteLine(UIConfig.Prompt.PromptWelcome);
                Console.WriteLine(UIConfig.Design.Divider);

                Console.WriteLine(UIConfig.Prompt.PromptLion);
                string name = Utils.ReadString(UIConfig.Input.InputName, UIConfig.ValidationError.InvalidInputName, 5);
                int age = Utils.ReadInt(UIConfig.Input.InputAge, UIConfig.ValidationError.InvalidInputAge);
                double weight = Utils.ReadDouble(UIConfig.Input.InputWeight, UIConfig.ValidationError.InvalidInputWeight);
                bool claws = Utils.ReadBool(UIConfig.Input.InputHasSharpClaws, UIConfig.ValidationError.InvalidInputHasSharpClaws);

                Lion simba = new Lion(name, age, weight,null, claws);

                Console.WriteLine(UIConfig.SuccessMessage.AnimalCreated);

                Lion scar = new Lion("Scar", 5, 190.5);

                //Console.WriteLine(simba.IsOverWeight);

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