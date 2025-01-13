using Microsoft.AspNetCore.Mvc;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Application.Implementation;
using Microsoft.AspNetCore.Authorization;
using UTB.Restaurace.Infrastructure.Identity.enums;
using Microsoft.EntityFrameworkCore;

namespace UTB.Restaurace.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class MealController : Controller
    {
        IMealAppService _mealAppService;
        public MealController(IMealAppService mealAppService)
        {
            _mealAppService = mealAppService;
        }



        // GET: /<controller>/
        public IActionResult Select(string sortColumn, string sortDirection)
        {
            // Get the list of meals from the application service
            IList<Meal> meals = _mealAppService.Select();

            // Default sorting direction if not provided
            sortDirection = sortDirection ?? "asc";

            // Apply sorting based on the selected column
            switch (sortColumn)
            {
                case "Id":
                    meals = sortDirection == "asc" ? meals.OrderBy(m => m.Id).ToList() : meals.OrderByDescending(m => m.Id).ToList();
                    break;
                case "Price":
                    meals = sortDirection == "asc" ? meals.OrderBy(m => m.Price).ToList() : meals.OrderByDescending(m => m.Price).ToList();
                    break;
                case "Category":
                    meals = sortDirection == "asc" ? meals.OrderBy(m => m.Category).ToList() : meals.OrderByDescending(m => m.Category).ToList();
                    break;
                case "Available":
                    meals = sortDirection == "asc" ? meals.OrderBy(m => m.Available).ToList() : meals.OrderByDescending(m => m.Available).ToList();
                    break;
                default:
                    meals = meals.OrderBy(m => m.Id).ToList(); // Default sorting by Id if no column is provided
                    break;
            }

            // Pass the sort column and direction to the view for generating the sortable links
            ViewData["CurrentSort"] = sortColumn;
            ViewData["SortDirection"] = sortDirection;

            // Return the sorted list of meals
            return View(meals);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Meal meal)
        {
            // Momentalne zakomentovano z duvodu chyby pri desetinnych cisel
            //if (ModelState.IsValid)
            //{
            //_mealAppService.Create(meal);
            //return RedirectToAction(nameof(MealController.Select));
            //}
            if (ModelState.IsValid)
            {
                _mealAppService.Create(meal);
                return RedirectToAction(nameof(MealController.Select));
            }

            return View(meal);
            //return View(meal);
        }

        // GET: Meal/Edit/5
        public IActionResult Edit(int id)
        {
            var meal = _mealAppService.GetById(id);
            if (meal == null)
            {
                return NotFound();
            }
            return View(meal);
        }

        // POST: Meal/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Meal meal)
        {
            if (id != meal.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _mealAppService.Update(meal);
                return RedirectToAction(nameof(Select));
            }

            return View(meal);
        }


        [HttpPost]
        public IActionResult ToggleAvailability(int id, bool available)
        {
            var meal = _mealAppService.Select().FirstOrDefault(m => m.Id == id);
            if (meal != null)
            {
                meal.Available = available;
                _mealAppService.Update(meal);
            }
            return RedirectToAction(nameof(Select));
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _mealAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(MealController.Select));
            }
            else
                return NotFound();
        }
    }
}
