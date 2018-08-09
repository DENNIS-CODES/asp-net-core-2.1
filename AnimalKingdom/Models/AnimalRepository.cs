using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalKingdom.Models
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _appDbContext;

        public AnimalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Animal> GetAllAnimals()
        {
            return _appDbContext.Animals;
        }

        public Animal GetAnimalById(int animalId)
        {
            return _appDbContext.Animals.FirstOrDefault(a => a.Id == animalId);
        }
    }
}
