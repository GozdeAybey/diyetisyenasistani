namespace DiyetisyenApp.Models.ViewModels.Enums;

public class MacroSummaryRow
{
    public string MacroName { get; set; } = string.Empty;
    public MacroLevel Level { get; set; }

    public int Calories { get; set; }
    public double Grams { get; set; }
    public double Percent { get; set; }
}