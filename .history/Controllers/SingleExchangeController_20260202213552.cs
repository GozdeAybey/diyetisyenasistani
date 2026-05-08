using DiyetisyenApp.Models.ViewModels;
using DiyetisyenApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiyetisyenApp.Controllers;

public class SingleExchangeController : Controller
{
    private readonly FoodGroupService _foodGroupService;

    public SingleExchangeController()
    {
        _foodGroupService = new FoodGroupService();
    }

    // 📌 Sayfayı açar
    [HttpGet]
    public IActionResult Index()
    {
        return View(new SingleExchangeRequest());
    }

    // 📌 Hesaplar
    [HttpPost]
    public IActionResult Index(SingleExchangeRequest request)
    {
        var result = _foodGroupService.CalculateSingleExchangeSummary(
            request.Milk,
            request.Meat,
            request.Eyg,
            request.Vegetable,
            request.Fruit,
            request.Fat
        );

        ViewBag.Result = result;
        return View(request);
    }
}