using Microsoft.EntityFrameworkCore;
using UTB.Restaurace.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using UTB.Restaurace.Infrastructure.Database;

public class ReservationAppService : IReservationAppService
{
    private readonly RestauraceDbContext _context;

    public ReservationAppService(RestauraceDbContext context)
    {
        _context = context;
    }

    public IList<Reservation> Select()
    {
        // Vrátí všechny rezervace z databáze
        return _context.Reservations.ToList();
    }

    public Reservation GetById(int id)
    {
        return _context.Reservations.FirstOrDefault(r => r.Id == id);
    }

    public void Create(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
    }

    public void Update(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        _context.SaveChanges();
    }

    public bool Delete(int id)
    {
        var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
