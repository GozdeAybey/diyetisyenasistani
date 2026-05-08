namespace DiyetisyenApp.Models.Domain;

public class FoodGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // TÜBER - 1 değişim değerleri
    public int CaloriesPerExchange { get; set; }
    public int CarbsPerExchange { get; set; }
    public int ProteinPerExchange { get; set; }
    public int FatPerExchange { get; set; }
}