using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Zoo.Core.Models;

namespace ZooApp.Tools
{
    public static class Utils
    {
        // Genereric method to read and validate a positive integer from console
        public static int ReadInt(string message, string errorMessage)
        {
            int result;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out result) || result < 0)
            {
                Console.WriteLine(errorMessage);
            }
            return result;
        }

        //Generic method to read and validate a positive double from console
        public static double ReadDouble(string message, string errorMessage)
        {
            double result;
            Console.WriteLine(message);
            while(!double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.WriteLine(errorMessage);
            }
            return result;
        }

        // Generic method to read and validate a non-empty string with minimum length from console
        public static string ReadString(string message, string errorMessage, int minLength)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(input) || input.Length < minLength)
            {
                Console.WriteLine(errorMessage);
                input = Console.ReadLine() ?? string.Empty;
            }
            return input;
        }

        //Generic method to read and validate a boolean from console
        public static bool ReadBool(string message, string errorMessage)
        {
            bool result;
            Console.WriteLine(message);
            while (!bool.TryParse(Console.ReadLine()?.ToLower().Trim(), out result)) {
                Console.WriteLine(errorMessage);
            }
            return result;
        }
    }
}
