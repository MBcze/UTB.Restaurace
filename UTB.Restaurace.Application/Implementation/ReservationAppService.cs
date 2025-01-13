﻿using Microsoft.EntityFrameworkCore;
using UTB.Restaurace.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using UTB.Restaurace.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using UTB.Restaurace.Infrastructure.Identity;

public class ReservationAppService : IReservationAppService
{
    private readonly RestauraceDbContext _restauraceDbContext;
    private readonly UserManager<User> _userManager;

    public ReservationAppService(RestauraceDbContext restauraceDbContext, UserManager<User> userManager)
    {
        _restauraceDbContext = restauraceDbContext;
        _userManager = userManager;
    }

    public IList<Reservation> Select()
    {
        // Načteme všechny rezervace
        var reservations = _restauraceDbContext.Reservations.ToList();

        // Pro každou rezervaci načteme uživatelské jméno
        foreach (var reservation in reservations)
        {
            // Načteme uživatelské jméno podle UserId
            var user = _userManager.Users.FirstOrDefault(u => u.Id == reservation.UserId);
            if (user != null)
            {
                // Uložení uživatelského jména přímo do rezervace
                reservation.UserName = user.UserName;
            }
        }

        return reservations;
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
            existingReservation.Status = reservation.Status;
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

    public IList<ReserveMeal> GetReserveMealsByReservationId(int reservationId)
    {
        // Získání rezervovaných jídel pro danou rezervaci
        var reserveMeals = _restauraceDbContext.ReserveMeals
            .Where(rm => rm.ReservationID == reservationId)
            .Include(rm => rm.Meal)  // Zahrnutí jídla (Meal) do výsledků
            .ToList();

        return reserveMeals;
    }

}
