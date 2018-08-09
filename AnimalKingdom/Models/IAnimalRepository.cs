using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalKingdom.Models
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAllAnimals();
        Animal GetAnimalById(int animalId);
    }
}
