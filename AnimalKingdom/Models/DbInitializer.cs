using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalKingdom.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Animals.Any())
            {
                context.AddRange(
                new Animal() {Name = "Lion"},
                new Animal() {Name = "Tiger"},
                new Animal() {Name = "Cat"},
                new Animal() {Name = "Elephant"},
                new Animal() {Name = "Giraffe"}
            );
            }

            context.SaveChanges();
        }
    }
}
