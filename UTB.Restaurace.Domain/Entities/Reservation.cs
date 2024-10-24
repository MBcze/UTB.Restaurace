using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Restaurace.Domain.Entities.Interfaces;

namespace UTB.Restaurace.Domain.Entities
{
    public class Reservation : Entity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateTimeCreated { get; protected set; }
        [Required]
        public string ReservationNumber { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public IUser<int> User { get; set; }
        public IList<ReserveMeal> ReserveMeals { get; set; }
    }
}
