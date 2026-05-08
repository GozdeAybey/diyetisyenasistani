namespace DiyetisyenApp.Models.ViewModels;

public class MacroSummaryRow
{
    // Protein / Karbonhidrat / Yağ
    public string MacroName { get; set; } = string.Empty;

    // Low / Average / High
    public MacroLevel Level { get; set; }

    // Toplam değerler
    public int Calories { get; set; }
    public double Grams { get; set; }
    public double Percent { get; set; }
}