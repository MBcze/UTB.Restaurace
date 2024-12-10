using Microsoft.AspNetCore.Mvc;


namespace UTB.Restaurace.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MealController : Controller
    {
        public IActionResult Select()
        {
            return View();
        }
    }
}
