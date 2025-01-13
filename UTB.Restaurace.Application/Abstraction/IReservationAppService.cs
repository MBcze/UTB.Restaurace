using UTB.Restaurace.Domain.Entities;

public interface IReservationAppService
{
    IList<Reservation> Select();
    Reservation GetById(int id);
    void Update(Reservation reservation);
    bool Delete(int id);
    IList<ReserveMeal> GetReserveMealsByReservationId(int reservationId);
    void Create(Reservation reservation);
    void AddReserveMeals(List<ReserveMeal> reserveMeals);
}
