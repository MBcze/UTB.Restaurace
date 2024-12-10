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
            _mealAppService.Create(meal);
            return RedirectToAction(nameof(MealController.Select));
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
