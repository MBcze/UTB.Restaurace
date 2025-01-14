// Areas/User/Controllers/UserReservationController.cs
using Microsoft.AspNetCore.Mvc;
using UTB.Restaurace.Application.Abstraction;
using Microsoft.AspNetCore.Identity;
using UTB.Restaurace.Infrastructure.Identity;
using UTB.Restaurace.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using UTB.Restaurace.Infrastructure.Identity.enums;
using UTB.Restaurace.Areas.User.Models;
using UTB.Restaurace.Application.Implementation;
using System.Collections.Generic;


namespace UTB.Restaurace.Areas.User.Controllers
{
    [Area("User")]  // Deklarace oblasti User
    [Authorize(Roles = nameof(Roles.Customer))]
    public class UserReservationController : Controller
    {
        private readonly IMealAppService _mealAppService;
        private readonly IReservationAppService _reservationAppService;
        private readonly UserManager<UTB.Restaurace.Infrastructure.Identity.User> _userManager;


        public UserReservationController(IReservationAppService reservationAppService,IMealAppService mealAppService, UserManager<UTB.Restaurace.Infrastructure.Identity.User> userManager)
        {
            _reservationAppService = reservationAppService;
            _mealAppService = mealAppService;
            _userManager = userManager;
        }

        [HttpGet]

        public IActionResult Create()
        {
            var availableMeals = _mealAppService.Select().Where(m => m.Available).Select(m => new MealViewModel
            {
                MealId = m.Id,
                Name = m.Name ?? string.Empty,
                Description = m.Description ?? string.Empty,
                Price = m.Price,
                Amount = 0,
                IsSelected = false,
                Image = m.ImageSrc
            }).ToList();
            var model = new UserReservationModel
            {
                Reservation = new Reservation(),
                AvailableMeals = availableMeals
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserReservationModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                viewModel.Reservation.UserId = user.Id;

                // Vypočítání celkové ceny
                viewModel.Reservation.TotalPrice = viewModel.AvailableMeals
                    .Where(m => m.Amount > 0)
                    .Sum(m => m.Price * m.Amount);

                _reservationAppService.Create(viewModel.Reservation);

                // Zpracování vybraných jídel
                var selectedMeals = viewModel.AvailableMeals.Where(m => m.Amount > 0)
                    .Select(m => new ReserveMeal
                    {
                        ReservationID = viewModel.Reservation.Id,
                        MealId = m.MealId,
                        Amount = m.Amount,
                        Price = m.Price * m.Amount
                    }).ToList();

                _reservationAppService.AddReserveMeals(selectedMeals);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            //}

            // Pokud je model neplatný, vraťte stejný model zpět do view
            return View(viewModel);
        }

        public async Task<IActionResult> UserReservations()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var reservations = _reservationAppService.GetUserReservations(user.Id);
            var reserveMeals = new List<ReserveMeal>();

            foreach (var reservation in reservations)
            {
                var meals = _reservationAppService.GetReserveMealsByReservationId(reservation.Id);
                reserveMeals.AddRange(meals);
            }

            ViewBag.ReserveMeals = reserveMeals;

            return View(reservations);
        }
    }
}