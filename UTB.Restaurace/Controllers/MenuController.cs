using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Domain.Entities;

public class MenuController : Controller
{
    private readonly IMealAppService _mealAppService;

    public MenuController(IMealAppService mealAppService)
    {
        _mealAppService = mealAppService;
    }

    public IActionResult Index()
    {
        IList<Meal> meals = _mealAppService.Select();
        return View(meals);
    }
}
