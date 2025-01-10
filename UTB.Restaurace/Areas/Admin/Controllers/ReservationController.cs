using Microsoft.AspNetCore.Mvc;
using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Application.Implementation;
using Microsoft.AspNetCore.Authorization;
using UTB.Restaurace.Infrastructure.Identity.enums;

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
    }
}
