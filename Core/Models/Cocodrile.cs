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

        public override string? SpecialCare { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
