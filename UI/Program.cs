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
            Lion pepito = new Lion("Pepito", 3, 150.5);



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


            /*Theory composition*/
            Console.WriteLine($"Beats per minute {pepito.GetBeatsPerMinute()}");

            //TO-DO

            //Understanding inheritance terms
            /*
            abstract: "Hijo, tienes que hacer esto, pero no te digo cómo".

            virtual: "Hijo, yo lo hago así, pero si quieres puedes hacerlo diferente".

            override: "Papá, estoy haciendo lo que me pediste".

            sealed override: "Hijo, yo lo hago así, y te prohíbo hacerlo diferente".
             */


            /*Object class*/
            Lion leoncito = new Lion("Leoncito", 2, 120.5);
            Object leoncitoObject = leoncito; //Upcasting - Implicit conversion from Lion to Object (because Lion is a subclass of Object)

            //Principal methods of the Object class: Equals, GetHashCode and ToString

            /*Equals*/
            /*CAUTION: COMMENT METHOD Equals AND TEST IT. THEN UNCOMMENT Equals AND TEST IT AGAIN*/

            /*Equals is a virtual method, we can override it to
             compare the properties of the Lion class instead of comparing the reference of the object */

            Lion leoncito2 = new Lion("Leoncito", 2, 120.5);

            /*We have the same properties but they are different objects in memory.
             * They're not the same reference
             */
            Console.WriteLine($"Son iguals leoncito i leoncito2?:{leoncito.Equals(leoncito2)}");

            Lion leoncito3 = leoncito2;

            /*We havethe same properties and they are the same object in memory. 
             * If we want to compare the properties of the Lion class, we need to override the Equals method in the Lion class and 
             * compare the properties of the Lion class instead of comparing the reference of the object.
             */
            Console.WriteLine($"Son iguals leoncito3 i leoncito2?:{leoncito2.Equals(leoncito3)}");

            /*GetHashCode: We can use the GetHashCode method to get a hash code for the object, 
             * this is useful when we want to use the object as a key in a dictionary or as an element in a HashSet.
             * We use to have fast lookups in collections that use hashing and avoid duplicates in collections that use hashing,
             * and avoid loop all the elements in the collection to find an element, we can use the hash code to find the element in a faster way.
             * We can get 0(1) time complexity instead of O(n) time complexity.
             * /
            /*Returns a hash code for the object.
            The default implementation returns a hash code based on the reference of the object in memory.*/
            /*CAUTION: COMMENT METHOD GetHashCode AND TEST IT. THEN UNCOMMENT EQUALS AND TEST IT GetHashCode*/

            /*If we don't override the GetHashCode method, the hash code will be based on the reference of the object in memory, 
             * so leoncito and leoncito2 will have different hash codes even if they have the same properties.
             */
            HashSet<Lion> lionHashSet = new HashSet<Lion>();

            lionHashSet.Add(leoncito);
            lionHashSet.Add(leoncito2);

            /*If we did the override of the GetHashCode method correctly, leoncito and leoncito2 will have the same hash code and only one of them will be added
            to the HashSet because HashSet does not allow duplicate elements.*/
            foreach (Lion lion in lionHashSet)
            {
                Console.WriteLine($"Lion in HashSet: {lion.Name} with hash {lion.GetHashCode()}");
            }

            Console.WriteLine($"Està a dins del HashSet? -> {lionHashSet.Contains(new Lion("Leoncito", 2, 120.5))}");

            /*ToString*/
            /*CAUTION: COMMENT METHOD ToString AND TEST IT. THEN UNCOMMENT EQUALS AND TEST IT ToString*/
            //ToString is virtual method, we can override it we want or use the default implementation of the Object class
            Console.WriteLine(leoncito.ToString());


            /*
            try
            {
                Console.WriteLine(UIConfig.Prompt.PromptWelcome);
                Console.WriteLine(UIConfig.Design.Divider);
                
                Console.WriteLine(UIConfig.Prompt.PromptLion);
                string name = Utils.ReadString(UIConfig.Input.InputName, UIConfig.ValidationError.InvalidInputName, 5);
                int age = Utils.ReadInt(UIConfig.Input.InputAge, UIConfig.ValidationError.InvalidInputAge);
                double weight = Utils.ReadDouble(UIConfig.Input.InputWeight, UIConfig.ValidationError.InvalidInputWeight);
                bool claws = Utils.ReadBool(UIConfig.Input.InputHasSharpClaws, UIConfig.ValidationError.InvalidInputHasSharpClaws);
                

                Lion simba = new Lion(name, age, weight, 20, null, claws);

                //Named Arguments - We can use named arguments to specify the parameters we want to assign,
                //this is useful when we have many parameters and we want to avoid confusion
                //We can also use named arguments to assign values to optional parameters and leave the non-optional parameters in their default position
                Lion simba2 = new Lion(name, age, weight, 20, hasSharpClaws: claws);
                

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

                foreach (Animal animal in zooAnimals)
                {
                    if (animal is Mammal mammalAnimal)
                    {
                        Console.WriteLine($"The {mammalAnimal.Name} is a {mammalAnimal.Species} and it says:");
                        animal.MakeSound();
                    }

                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error creating lion: {ex.Message}");
                Console.WriteLine("Please try again.\n");
            }
            */
        }
    }
}