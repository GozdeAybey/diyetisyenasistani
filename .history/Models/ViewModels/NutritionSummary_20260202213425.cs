namespace DiyetisyenApp.Models.ViewModels;

public class NutritionSummary
{
    public int Carbs { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }

    public int Calories =>
        (Carbs * 4) + (Protein * 4) + (Fat * 9);

    public double CarbsPercent { get; set; }
    public double ProteinPercent { get; set; }
    public double FatPercent { get; set; }

    public void CalculatePercentages()
    {
        if (Calories == 0) return;

        CarbsPercent = (Carbs * 4.0) / Calories * 100;
        ProteinPercent = (Protein * 4.0) / Calories * 100;
        FatPercent = (Fat * 9.0) / Calories * 100;
    }
}