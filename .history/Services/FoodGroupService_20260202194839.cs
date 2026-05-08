using DiyetisyenApp.Models.Domain;

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
}