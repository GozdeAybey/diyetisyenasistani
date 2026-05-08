using Microsoft.AspNetCore.Mvc;
using DiyetisyenApp.Models.ViewModels;
using DiyetisyenApp.Services;

namespace DiyetisyenApp.Controllers;

public class BmrController : Controller
{
    private readonly BmrService _bmrService;

    public BmrController()
    {
        _bmrService = new BmrService();
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(BmrCalculationViewModel model)
    {
        var result = _bmrService.Calculate(model);
        return View(result);
    }
}