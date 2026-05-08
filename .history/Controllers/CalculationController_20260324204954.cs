using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DiyetisyenApp.Services;
using DiyetisyenApp.Models.ViewModels;
using DiyetisyenApp.Models.Domain;

namespace DiyetisyenApp.Controllers;

[Authorize]
public class CalculationController : Controller
{
    private readonly FoodGroupService _foodGroupService;
    private readonly CalculationService _calculationService;

    public CalculationController(
        FoodGroupService foodGroupService,
        CalculationService calculationService)
    {
        _foodGroupService = foodGroupService;
        _calculationService = calculationService;
    }

    // =========================
    // GET – Sayfa ilk açıldığında
    // =========================
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Index()
    {
        var foodGroups = _foodGroupService.GetFoodGroups();

        // 🔹 SADECE varsayılan değerler
        var model = new CalculationRequest
        {
            MinCalories = 1600,   // kullanıcı isterse değiştirecek
            MaxCalories = 1800,   // kullanıcı isterse değiştirecek
            ExchangeRanges = foodGroups.Select(f => new ExchangeRange
            {
                FoodGroupId = f.Id,
                Min = 0,
                Max = 2
            }).ToList()
        };

        ViewBag.FoodGroups = foodGroups;
        ViewBag.Table = null;

        return View(model);
    }

    // =========================
    // POST – Kullanıcı hesapla dediğinde
    // =========================
 [AllowAnonymous]
[HttpPost]
public IActionResult Index(CalculationRequest request)
{
    var foodGroups = _foodGroupService.GetFoodGroups();

    // 🔥 1. MODEL VALIDATION
    if (!ModelState.IsValid)
    {
        ViewBag.FoodGroups = foodGroups;
        return View(request);
    }

    // 🔥 2. KALORİ KONTROL
    if (request.MinCalories > request.MaxCalories)
    {
        ModelState.AddModelError("", "Minimum kalori maksimum kaloriden büyük olamaz.");

        ViewBag.FoodGroups = foodGroups;
        return View(request);
    }

    // 🔥 3. DEĞİŞİM KONTROL
    if (request.ExchangeRanges.Any(x => x.Min > x.Max))
    {
        ModelState.AddModelError("", "Minimum değişim değeri Maximum değişim değerinden büyük olamaz.");

        ViewBag.FoodGroups = foodGroups;
        return View(request);
    }

    if (request.ExchangeRanges.Any(x => x.Min < 0 || x.Max < 0))
    {
        ModelState.AddModelError("", "Negatif değer girilemez.");

        ViewBag.FoodGroups = foodGroups;
        return View(request);
    }

    // 🔥 4. HESAPLAMA
    var table = _calculationService.BuildFullMacroTable(foodGroups, request);

    // 🔥 5. SONUÇ YOKSA
    if (table == null || !table.Any())
    {
        ViewBag.NoResult = true;
    }

    ViewBag.FoodGroups = foodGroups;
    ViewBag.Table = table;

    return View(request);
}
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Clear()
    {
        return RedirectToAction("Index");
    }
    
}