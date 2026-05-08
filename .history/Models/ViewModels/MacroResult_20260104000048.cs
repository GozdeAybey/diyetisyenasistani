namespace DiyetisyenApp.Models.ViewModels;

public class MacroResult
{
    public int TotalCalories { get; set; }

    public int Carbs { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }

    public double CarbsPercent =>
        TotalCalories == 0 ? 0 : (Carbs * 4.0) / TotalCalories * 100;

    public double ProteinPercent =>
        TotalCalories == 0 ? 0 : (Protein * 4.0) / TotalCalories * 100;

    public double FatPercent =>
        TotalCalories == 0 ? 0 : (Fat * 9.0) / TotalCalories * 100;
}