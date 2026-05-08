using DiyetisyenApp.Models.Domain;
using DiyetisyenApp.Models.ViewModels;

namespace DiyetisyenApp.Services;

public class FoodGroupService
{
    public List<FoodGroup> GetFoodGroups()
    {
        return new List<FoodGroup>
        {
            new()
            {
                Id = 1,
                Name = "Ekmek Yerine Geçenler",
                CarbsPerExchange = 15,
                ProteinPerExchange = 2,
                FatPerExchange = 0
            },
            new()
            {
                Id = 2,
                Name = "Et",
                CarbsPerExchange = 0,
                ProteinPerExchange = 6,
                FatPerExchange = 5
            },
            new()
            {
                Id = 3,
                Name = "Süt",
                CarbsPerExchange = 9,
                ProteinPerExchange = 6,
                FatPerExchange = 6
            },
            new()
            {
                Id = 4,
                Name = "Sebze",
                CarbsPerExchange = 6,
                ProteinPerExchange = 2,
                FatPerExchange = 0
            },
            new()
            {
                Id = 5,
                Name = "Meyve",
                CarbsPerExchange = 15,
                ProteinPerExchange = 0,
                FatPerExchange = 0
            },
            new()
            {
                Id = 6,
                Name = "Yağ",
                CarbsPerExchange = 0,
                ProteinPerExchange = 0,
                FatPerExchange = 5
            },
            new()
            {
                Id = 7,
                Name = "Yağlı Tohum",
                CarbsPerExchange = 0,
                ProteinPerExchange = 2,
                FatPerExchange = 5
            }
        };
    }

    // 🔥 İŞTE EKSİK OLAN METOT
    public NutritionSummary CalculateSingleExchangeSummary(
        int milk,
        int meat,
        int eyg,
        int vegetable,
        int fruit,
        int fat)
    {
        var groups = GetFoodGroups();

        int carbs =
            milk * groups.First(x => x.Name == "Süt").CarbsPerExchange +
            meat * groups.First(x => x.Name == "Et").CarbsPerExchange +
            eyg * groups.First(x => x.Name == "Ekmek Yerine Geçenler").CarbsPerExchange +
            vegetable * groups.First(x => x.Name == "Sebze").CarbsPerExchange +
            fruit * groups.First(x => x.Name == "Meyve").CarbsPerExchange +
            fat * groups.First(x => x.Name == "Yağ").CarbsPerExchange;

        int protein =
            milk * groups.First(x => x.Name == "Süt").ProteinPerExchange +
            meat * groups.First(x => x.Name == "Et").ProteinPerExchange +
            eyg * groups.First(x => x.Name == "Ekmek Yerine Geçenler").ProteinPerExchange +
            vegetable * groups.First(x => x.Name == "Sebze").ProteinPerExchange +
            fruit * groups.First(x => x.Name == "Meyve").ProteinPerExchange +
            fat * groups.First(x => x.Name == "Yağ").ProteinPerExchange;

        int fatTotal =
            milk * groups.First(x => x.Name == "Süt").FatPerExchange +
            meat * groups.First(x => x.Name == "Et").FatPerExchange +
            eyg * groups.First(x => x.Name == "Ekmek Yerine Geçenler").FatPerExchange +
            vegetable * groups.First(x => x.Name == "Sebze").FatPerExchange +
            fruit * groups.First(x => x.Name == "Meyve").FatPerExchange +
            fat * groups.First(x => x.Name == "Yağ").FatPerExchange;

        var summary = new NutritionSummary
        {
            Carbs = carbs,
            Protein = protein,
            Fat = fatTotal
        };

        summary.CalculatePercentages();
        return summary;
    }
}