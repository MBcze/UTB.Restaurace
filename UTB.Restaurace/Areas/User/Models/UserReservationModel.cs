using UTB.Restaurace.Domain.Entities;

namespace UTB.Restaurace.Areas.User.Models
{
    public class UserReservationModel
    {
        public required Reservation Reservation { get; set; }
        public required List<MealViewModel> AvailableMeals { get; set; }
    }
    public class MealViewModel
    {
        public int MealId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public bool IsSelected { get; set; }
        public int Amount { get; set; }
        public string Image { get; set; }
    }

}
