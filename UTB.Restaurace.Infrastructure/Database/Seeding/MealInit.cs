using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Restaurace.Domain.Entities;

namespace UTB.Restaurace.Infrastructure.Database.Seeding
{
    internal class MealInit
    {
        public IList<Meal> GetThreeMeals()
        {
            IList<Meal> meals = new List<Meal>();

            meals.Add(new Meal
            {
                Id = 1,
                Name = "Rohlík",
                Description = "placeholder",
                Price = 2,
                ImageSrc = "/img/placeholder.jpg"
            });

            meals.Add(new Meal
            {
                Id = 2,
                Name = "Bageta",
                Description = "placeholder",
                Price = 3,
                ImageSrc = "/img/placeholder.jpg"
            });

            meals.Add(new Meal
            {
                Id = 3,
                Name = "Řízek",
                Description = "placeholder",
                Price = 8,
                ImageSrc = "/img/placeholder.jpg"
            });

            return meals;
        }
    }
}
