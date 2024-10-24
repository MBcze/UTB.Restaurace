using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Restaurace.Domain.Entities
{
    public class ReserveMeal : Entity<int>
    {
        [ForeignKey(nameof(Reservation))]
        public int ReservationID { get; set; }
        [ForeignKey(nameof(Meal))]
        public int MealID { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public double Price { get; set; }
        public Reservation? Reservation { get; set; }
        public Meal? Meal { get; set; }
    }
}
