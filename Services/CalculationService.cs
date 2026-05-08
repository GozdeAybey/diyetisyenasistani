using DiyetisyenApp.Models.Domain;
using DiyetisyenApp.Models.ViewModels;

namespace DiyetisyenApp.Services;

public class CalculationService
{
    // =====================================================
    // 1️⃣ TÜM KOMBİNASYONLARI ÜRETİR
    // =====================================================
    public List<MacroCombination> Calculate(
        List<FoodGroup> foodGroups,
        CalculationRequest request)
    {
        var results = new List<MacroCombination>();

        // Kalori alanları boşsa hesaplama yapma
        if (!request.MinCalories.HasValue || !request.MaxCalories.HasValue)
            return results;

        // Exchange alanlarından biri boşsa hesaplama yapma
        if (request.ExchangeRanges.Any(x => !x.Min.HasValue || !x.Max.HasValue))
            return results;

        void Recurse(
            int index,
            int totalCarbs,
            int totalProtein,
            int totalFat,
            Dictionary<int, int> exchangeMap)
        {
            if (index == request.ExchangeRanges.Count)
            {
                var totalCalories =
                    (totalCarbs * 4) +
                    (totalProtein * 4) +
                    (totalFat * 9);

                if (totalCalories >= request.MinCalories.Value &&
                    totalCalories <= request.MaxCalories.Value)
                {
                    results.Add(new MacroCombination
                    {
                        TotalCalories = totalCalories,
                        Carbs = totalCarbs,
                        Protein = totalProtein,
                        Fat = totalFat,
                        ExchangeCounts = new Dictionary<int, int>(exchangeMap)
                    });
                }
                return;
            }

            var range = request.ExchangeRanges[index];
            var food = foodGroups.First(f => f.Id == range.FoodGroupId);

            int min = range.Min ?? 0;
            int max = range.Max ?? 0;

            for (int i = min; i <= max; i++)
            {
                var newMap = new Dictionary<int, int>(exchangeMap)
                {
                    [range.FoodGroupId] = i
                };

                Recurse(
                    index + 1,
                    totalCarbs + i * food.CarbsPerExchange,
                    totalProtein + i * food.ProteinPerExchange,
                    totalFat + i * food.FatPerExchange,
                    newMap
                );
            }
        }

        Recurse(0, 0, 0, 0, new Dictionary<int, int>());
        return results;
    }

    // =====================================================
    // 2️⃣ ANA METOT – 3×3 TABLO
    // =====================================================
    public List<MacroFocusRow> BuildFullMacroTable(
        List<FoodGroup> foodGroups,
        CalculationRequest request)
    {
        var combinations = Calculate(foodGroups, request);

        if (!combinations.Any())
            return new List<MacroFocusRow>();

        var table = new List<MacroFocusRow>();

        table.AddRange(BuildFocus(combinations, foodGroups, "KH"));
        table.AddRange(BuildFocus(combinations, foodGroups, "Protein"));
        table.AddRange(BuildFocus(combinations, foodGroups, "Yağ"));

        return table;
    }

    // =====================================================
    // 3️⃣ ODAK MACRO (MIN / ORTA / MAX)
    // =====================================================
    private List<MacroFocusRow> BuildFocus(
        List<MacroCombination> combinations,
        List<FoodGroup> foodGroups,
        string focus)
    {
        Func<MacroCombination, int> selector = focus switch
        {
            "KH" => x => x.Carbs,
            "Protein" => x => x.Protein,
            "Yağ" => x => x.Fat,
            _ => throw new Exception("Geçersiz macro")
        };

        var min = combinations.OrderBy(selector).First();
        var max = combinations.OrderByDescending(selector).First();
        var avgValue = combinations.Average(selector);

        var avg = combinations
            .OrderBy(x => Math.Abs(selector(x) - avgValue))
            .First();

        return new List<MacroFocusRow>
        {
            BuildRow(min, foodGroups, focus, "Min"),
            BuildRow(avg, foodGroups, focus, "Orta"),
            BuildRow(max, foodGroups, focus, "Max")
        };
    }

    // =====================================================
    // 4️⃣ SATIR OLUŞTUR (GRAM + YÜZDE + DEĞİŞİM)
    // =====================================================
    private MacroFocusRow BuildRow(
        MacroCombination c,
        List<FoodGroup> foodGroups,
        string focus,
        string level)
    {
        return new MacroFocusRow
        {
            FocusMacro = focus,
            Level = level,
            TotalCalories = c.TotalCalories,

            Carbs = c.Carbs,
            CarbsPercent = Percent(c.Carbs * 4, c.TotalCalories),

            Protein = c.Protein,
            ProteinPercent = Percent(c.Protein * 4, c.TotalCalories),

            Fat = c.Fat,
            FatPercent = Percent(c.Fat * 9, c.TotalCalories),

            ExchangeCounts = c.ExchangeCounts.ToDictionary(
                x => foodGroups.First(f => f.Id == x.Key).Name,
                x => x.Value
            )
        };
    }

    private static double Percent(int calories, int total)
        => total == 0 ? 0 : (double)calories / total * 100;
}

// =====================================================
// 🔥 KOMBINASYON MODELİ
// =====================================================
public class MacroCombination
{
    public int TotalCalories { get; set; }
    public int Carbs { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }

    public Dictionary<int, int> ExchangeCounts { get; set; } = new();
}