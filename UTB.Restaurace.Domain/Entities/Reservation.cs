﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Restaurace.Domain.Entities.Interfaces;
//using UTB.Restaurace.Infrastructure.Identity;

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
        //[Required]
        public double TotalPrice { get; set; }
        public string Status { get; set; } = "Pending";

        // tato část mi nefunguje kvůli cyklení a nemožnosti použít IUser<int> místo konkrétní třídy User kvůli tvorbě databáze a dalších problémů
        /*
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        // Používáme IUser<int> místo konkrétní třídy User kvůli cyklické referenci
        public IUser<int> User { get; set; }
        */

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public IList<ReserveMeal> ReserveMeals { get; set; }
    }
}
