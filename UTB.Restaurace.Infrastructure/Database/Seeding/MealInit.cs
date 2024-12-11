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
                ImageSrc = "/img/chickenSchnitzel.jpg",
                Category = "hlavní jídlo",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 2,
                Name = "Flank Steak",
                Description = "Šťavnatý flank steak, grilovaný na střední propečení, podávaný s bylinkovým máslem.",
                Price = 250.00,
                ImageSrc = "/img/flankSteak.jpg",
                Category = "hlavní jídlo",
                Available = false
            });

            meals.Add(new Meal
            {
                Id = 3,
                Name = "Vepřové s knedlíkem a zelím",
                Description = "Tradiční české jídlo s pečeným vepřovým masem, knedlíky a zelím.",
                Price = 180.00,
                ImageSrc = "/img/veproKnedloZelo.jpg",
                Category = "hlavní jídlo",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 4,
                Name = "Hovězí Burger",
                Description = "Šťavnatý hovězí burger s čerstvou zeleninou a domácí omáčkou.",
                Price = 200.00,
                ImageSrc = "/img/burger.jpg",
                Category = "hlavní jídlo",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 5,
                Name = "Pepperonni pizza",
                Description = "Italská pizza s pikantními plátky pepperoni a sýrem mozzarella.",
                Price = 220.00,
                ImageSrc = "/img/pizza.jpg",
                Category = "hlavní jídlo",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 6,
                Name = "Smažený sýr",
                Description = "Oblíbený smažený sýr podávaný s hranolky/kroketami a tatarskou omáčkou.",
                Price = 150.00,
                ImageSrc = "/img/smazenySyr.jpg",
                Category = "hlavní jídlo",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 7,
                Name = "Rajčatová polévka",
                Description = "Krémová rajčatová polévka zdobená čerstvou bazalkou a parmazánem.",
                Price = 95.00,
                ImageSrc = "/img/tomatoSoup.jpg",
                Category = "polévka",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 8,
                Name = "Coca Cola",
                Description = "Osvěžující nealkoholický nápoj s originální recepturou.",
                Price = 35.00,
                ImageSrc = "/img/cocaCola.jpg",
                Category = "nápoj",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 9,
                Name = "Pepsi",
                Description = "Populární nealkoholický nápoj s jedinečnou chutí.",
                Price = 35.00,
                ImageSrc = "/img/pepsi.jpg",
                Category = "nápoj",
                Available = true
            });

            meals.Add(new Meal
            {
                Id = 10,
                Name = "Staropramen",
                Description = "Klasické české pivo s vyváženou chutí a jemnou hořkostí.",
                Price = 45.00,
                ImageSrc = "/img/staropramen.jpg",
                Category = "nápoj",
                Available = true
            });


            return meals;
        }
    }
}