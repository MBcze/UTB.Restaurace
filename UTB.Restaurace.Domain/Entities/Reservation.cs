﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Restaurace.Domain.Entities.Interfaces;

namespace UTB.Restaurace.Domain.Entities
{
    [Table(nameof(Reservation))]
    public class Reservation : Entity<int>
    {
        // Time when the reservation was created, generated by the database automatically
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ReservationCreationTime { get; protected set; }

        // Time when the reservation is for (the user will pick this time)
        [Required]
        public DateTime ReservationDate { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; } = "Pending";
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public IList<ReserveMeal> ReserveMeals { get; set; }

        // Nová vlastnost pro jméno uživatele
        [NotMapped] // Tato vlastnost nebude mapována do databáze, takže nebude mít sloupec v tabulce
        public string UserName { get; set; }
    }
}
