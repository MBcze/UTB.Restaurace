using System;
using System.Collections.Generic;
using UTB.Restaurace.Domain.Entities;

namespace UTB.Restaurace.Infrastructure.Database.Seeding
{
    internal class ReserveMealInit
    {
        public IList<ReserveMeal> GetReserveMeals()
        {
            IList<ReserveMeal> reserveMeals = new List<ReserveMeal>();

            // Rezervace 1 pro uživatele 1
            reserveMeals.Add(new ReserveMeal
            {
                Id = 1,
                ReservationID = 1,  // Rezervace 1
                MealId = 1,  // Kuřecí řízek
                Amount = 2,  // Počet porcí
                Price = 330.00  // Cena za dvě porce
            });

            reserveMeals.Add(new ReserveMeal
            {
                Id = 2,
                ReservationID = 1,  // Rezervace 1
                MealId = 5,  // Pepperonni pizza
                Amount = 1,  // Počet porcí
                Price = 220.00  // Cena za jednu porci
            });

            // Rezervace 2 pro uživatele 2
            reserveMeals.Add(new ReserveMeal
            {
                Id = 3,
                ReservationID = 2,  // Rezervace 2
                MealId = 2,  // Flank Steak
                Amount = 1,  // Počet porcí
                Price = 250.00  // Cena za jednu porci
            });

            reserveMeals.Add(new ReserveMeal
            {
                Id = 4,
                ReservationID = 2,  // Rezervace 2
                MealId = 6,  // Smažený sýr
                Amount = 2,  // Počet porcí
                Price = 300.00  // Cena za dvě porce
            });

            return reserveMeals;
        }
    }
}
