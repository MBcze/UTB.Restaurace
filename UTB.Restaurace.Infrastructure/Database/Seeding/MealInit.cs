using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                Name = "Kuřecí řízek v bylinkové omáčce",
                Description = "Křupavý kuřecí řízek podávaný s jemnou bylinkovou omáčkou a čerstvým salátem.",
                Price = 165.00,
                ImageSrc = "/img/kureci_rizek.jpg",
                Category = "hlavní jídlo",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 2,
                Name = "Flank Steak",
                Description = "Šťavnatý flank steak, grilovaný na střední propečení, podávaný s bylinkovým máslem.",
                Price = 250.00,
                ImageSrc = "/img/flank_steak.jpg",
                Category = "hlavní jídlo",
                Available = false
            });

            meals.Add(new Meal
            {
                Id = 3,
                Name = "Vepřové s knedlíkem a zelím",
                Description = "Tradiční české jídlo s pečeným vepřovým masem, knedlíky a zelím.",
                Price = 180.00,
                ImageSrc = "/img/vepro_knedlo_zelo.jpg",
                Category = "hlavní jídlo",
                Available = true
            });

            return meals;
        }
    }
}