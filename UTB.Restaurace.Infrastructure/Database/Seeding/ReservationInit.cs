using System;
using System.Collections.Generic;
using UTB.Restaurace.Domain.Entities;

namespace UTB.Restaurace.Infrastructure.Database.Seeding
{
    internal class ReservationInit
    {
        public IList<Reservation> GetReservations()
        {
            IList<Reservation> reservations = new List<Reservation>();

            reservations.Add(new Reservation
            {
                Id = 1,
                UserId = 1,  // První uživatel
                ReservationDate = DateTime.Now.AddDays(1),  // Datum rezervace
                TotalPrice = 460.00,  // Celková cena za rezervaci
                Status = "Confirmed"  // Stav rezervace
            });

            reservations.Add(new Reservation
            {
                Id = 2,
                UserId = 2,  // Druhý uživatel
                ReservationDate = DateTime.Now.AddDays(2),  // Datum rezervace
                TotalPrice = 450.00,  // Celková cena za rezervaci
                Status = "Pending"  // Stav rezervace
            });

            return reservations;
        }
    }
}
