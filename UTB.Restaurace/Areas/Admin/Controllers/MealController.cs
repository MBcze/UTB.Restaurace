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
            return View();
            IList<Meal> meals = _mealAppService.Select();
            return View(meals);
        }
    }
}
