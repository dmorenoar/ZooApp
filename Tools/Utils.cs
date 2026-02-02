using System;
using System.Collections.Generic;
using System.Text;
using Zoo.Core.Models;

namespace ZooApp.Tools
{
    public static class Utils
    {

        public static Lion BuildLionWithValidation()
        {
            const string Prompt = "Welcome to the process to create a Lion";
            const string InputName = "Insert the animal name (min. 5 characters):";
            const string InvalidInputName = "Invalid input! Please enter a correct name";
            const string InputAge = "Insert the animal age:";
            const string InvalidInputAge = "Invalid input! Please enter a positive number for age";
            const string InputWeight = "Insert the animal weight:";
            const string InvalidInputWeight = "Invalid input! Please enter a positive number for weight";
            const string InputHasSharpClaws = "The animal has sharp claws? (true or false)";
            const string InvalidInputHasSharpClaws = "Invalid input! Please enter a correct valure for hasSharpClaws";

            Lion? lion = null; //We indicate that the variable can be null temporaly

            do
            {
                string name;
                int age;
                double weight;
                bool hasSharpClaws;

                Console.WriteLine(Prompt);

                Console.WriteLine(InputName);
                name = Console.ReadLine() ?? string.Empty; //If we get null we convert the input in ""

                while (string.IsNullOrWhiteSpace(name) || name.Length < 5)
                {
                    Console.WriteLine(InvalidInputName);
                    name = Console.ReadLine() ?? string.Empty;
                }

                Console.WriteLine(InputAge);
                while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                {
                    Console.WriteLine(InvalidInputAge);
                }

                Console.WriteLine(InputWeight);
                while (!double.TryParse(Console.ReadLine(), out weight) || weight < 0)
                {
                    Console.WriteLine(InvalidInputWeight);
                }

                Console.WriteLine(InputHasSharpClaws);
                while(!bool.TryParse(Console.ReadLine()?.ToLower().Trim(), out hasSharpClaws))
                {
                    Console.WriteLine(InvalidInputHasSharpClaws);
                }

                lion = new Lion(name, age, weight, hasSharpClaws);

            } while (lion == null);

            return lion;
        }
    }
}
