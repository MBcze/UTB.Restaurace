using Microsoft.EntityFrameworkCore;
using UTB.Restaurace.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using UTB.Restaurace.Infrastructure.Database;

public class ReservationAppService : IReservationAppService
{
    private readonly RestauraceDbContext _restauraceDbContext;

    public ReservationAppService(RestauraceDbContext restauraceDbContext)
    {
        _restauraceDbContext = restauraceDbContext;
    }

    public IList<Reservation> Select()
    {
        // Vrátí všechny rezervace z databáze
        return _restauraceDbContext.Reservations.ToList();
    }

    public Reservation GetById(int id)
    {
        return _restauraceDbContext.Reservations.FirstOrDefault(r => r.Id == id);
    }

    public void Update(Reservation reservation)
    {
        var existingReservation = _restauraceDbContext.Reservations.FirstOrDefault(r => r.Id == reservation.Id);
        if (existingReservation != null)
        {
            existingReservation.ReservationDate = reservation.ReservationDate;
            existingReservation.TotalPrice = reservation.TotalPrice;
           // existingReservation.CustomerName = reservation.CustomerName; // Example: include other fields
           // existingReservation.NumberOfGuests = reservation.NumberOfGuests; // Example: include more fields if necessary

            _restauraceDbContext.SaveChanges(); // Ensure changes are saved
        }
    }


    public bool Delete(int id)
    {
        bool deleted = false;
        Reservation? reservation
            = _restauraceDbContext.Reservations.FirstOrDefault(prod => prod.Id == id);
        if (reservation != null)
        {
            _restauraceDbContext.Reservations.Remove(reservation);
            _restauraceDbContext.SaveChanges();
            deleted = true;
        }
        return deleted;
    }
}
