using Microsoft.AspNetCore.Mvc;
using UTB.Restaurace.Application.Abstraction;
using Microsoft.AspNetCore.Authorization;
using UTB.Restaurace.Infrastructure.Identity.enums;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Application.Implementation;

namespace UTB.Restaurace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ReservationController : Controller
    {
        private readonly IReservationAppService _reservationAppService;

        public ReservationController(IReservationAppService reservationAppService)
        {
            _reservationAppService = reservationAppService;
        }

        // GET: Admin/Reservation/Select
        public IActionResult Select(string sortColumn, string sortDirection)
        {
            var reservations = _reservationAppService.Select();

            // Načteme rezervovaná jídla pro každou rezervaci
            foreach (var reservation in reservations)
            {
                reservation.ReserveMeals = _reservationAppService.GetReserveMealsByReservationId(reservation.Id);
            }

            // Default sorting direction if not provided
            sortDirection = sortDirection ?? "asc";

            // Apply sorting based on the selected column
            switch (sortColumn)
            {
                case "Id":
                    reservations = sortDirection == "asc"
                        ? reservations.OrderBy(r => r.Id).ToList()
                        : reservations.OrderByDescending(r => r.Id).ToList();
                    break;
                case "ReservationDate":
                    reservations = sortDirection == "asc"
                        ? reservations.OrderBy(r => r.ReservationDate).ToList()
                        : reservations.OrderByDescending(r => r.ReservationDate).ToList();
                    break;
                case "TotalPrice":
                    reservations = sortDirection == "asc"
                        ? reservations.OrderBy(r => r.TotalPrice).ToList()
                        : reservations.OrderByDescending(r => r.TotalPrice).ToList();
                    break;
                default:
                    reservations = reservations.OrderBy(r => r.Id).ToList(); // Default sorting by Id if no column is provided
                    break;
            }


            // Pass the sort column and direction to the view for generating the sortable links
            ViewData["CurrentSort"] = sortColumn;
            ViewData["SortDirection"] = sortDirection;

            // Return the sorted list of reservations
            return View(reservations);
        }

        // GET: Admin/Reservation/Edit/5
        public IActionResult Edit(int id)
        {
            var reservation = _reservationAppService.GetById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Admin/Reservation/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _reservationAppService.Update(reservation);
            return RedirectToAction(nameof(Select));
        }

        // DELETE: Admin/Reservation/Delete/5
        public IActionResult Delete(int id)
        {
            bool deleted = _reservationAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Select));
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Admin/Reservation/GetReserveMealsByReservationId/{reservationId}
        [HttpGet]
        public IActionResult GetReserveMealsByReservationId(int id)
        {
            var reserveMeals = _reservationAppService.GetReserveMealsByReservationId(id);
            if (reserveMeals == null || !reserveMeals.Any())
            {
                return NotFound(); // Vrací 404, pokud nejsou nalezeny žádné položky
            }

            return Json(reserveMeals);
        }
    }
}
