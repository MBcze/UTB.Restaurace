using Microsoft.AspNetCore.Mvc;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Application.Implementation;

namespace UTB.Restaurace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MealController : Controller
    {
        IMealAppService _mealAppService;
        public MealController(IMealAppService mealAppService)
        {
            _mealAppService = mealAppService;
        }
        // GET: /<controller>/
        public IActionResult Select()
        {
            IList<Meal> meals = _mealAppService.Select();
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
            _mealAppService.Create(meal);
            return RedirectToAction(nameof(MealController.Select));
            //}

            //return View(meal);
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
