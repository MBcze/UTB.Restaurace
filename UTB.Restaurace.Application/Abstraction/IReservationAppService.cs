using UTB.Restaurace.Domain.Entities;

public interface IReservationAppService
{
    IList<Reservation> Select();
    Reservation GetById(int id);
    void Create(Reservation reservation);
    void Update(Reservation reservation);
    bool Delete(int id);
}
