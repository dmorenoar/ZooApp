using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp.UI
{
    public static class UIConfig
    {
        public static class Prompt
        {
            public const string PromptWelcome = "Welcome to the Zoo Management System";
            public const string PromptCreateLion = "Welcome to the process to create a Lion";
            public const string PromptLion = "The 🦁 ";
        }

        public static class Input
        {
            public const string InputName = "Insert the animal name (min. 5 characters):";
            public const string InputAge = "Insert the animal age:";
            public const string InputWeight = "Insert the animal weight:";
            public const string InputHasSharpClaws = "The animal has sharp claws? (true or false)";
        }
        public static class ValidationError
        {
            public const string InvalidInputName = "Invalid input! Please enter a correct name";
            public const string InvalidInputAge = "Invalid input! Please enter a positive number for age";
            public const string InvalidInputWeight = "Invalid input! Please enter a positive number for weight";
            public const string InvalidInputHasSharpClaws = "Invalid input! Please enter a correct value (true or false) for hasSharpClaws"; 
        }

        public static class Design
        {
            public static string Divider = new string('-', 40);
        }

        public static class SuccessMessage
        {
            public const string AnimalCreated = "The animal has been created successfully!";
        }

    }
}
