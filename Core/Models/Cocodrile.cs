using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp.Core.Models
{
    public class Cocodrile : Reptiles
    {
        private const string SpeciesName = "Crocodylus niloticus";
        private const string Prompt = "The 🐊 ";
        private const string Sound = "says: ÑAMMM!";

        public Cocodrile(string name, int age, double weight, string species) : base(name, age, weight, SpeciesName)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Prompt} {Sound}");
        }

        public override void Breath()
        {
            Console.WriteLine($"{Prompt} use lungs also!");
        }
    }
}
