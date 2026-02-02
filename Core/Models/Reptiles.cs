

using Zoo.Core.Models;

namespace ZooApp.Core.Models
{
    public abstract class Reptiles : Animal
    {
        
        protected Reptiles(string name, int age, double weight, string species) : base(name, age, weight, species)
        {
        }



    }
}
