using Microsoft.AspNetCore.Mvc;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Application.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace UTB.Restaurace.Controllers
{
    public class DrinksController : Controller
    {
        private readonly IMealAppService _mealAppService;

        public DrinksController(IMealAppService mealAppService)
        {
            _mealAppService = mealAppService;
        }

        public IActionResult Index()
        {
            IList<Meal> drinks = _mealAppService.Select().Where(m => m.Category == "nápoj").ToList();
            return View(drinks);
        }
    }
}
