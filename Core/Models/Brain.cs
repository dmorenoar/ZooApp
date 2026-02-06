using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp.Core.Models
{
    public class Brain
    {
        public int Neurons { get; set; }

        public void ProcessInformation(int neurons)
        {
            Console.WriteLine($"Processing information with {neurons}");
        }
    }
}
