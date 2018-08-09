using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalKingdom.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalKingdom.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        public IActionResult Index()
        {
            return View(animalRepository.GetAllAnimals());
        }

        public IActionResult AnimalPage(int id)
        {
            var animal = animalRepository.GetAnimalById(id);

            if (animal == null)
                return NotFound();

            return View(animal);
        }
    }
}