public class NutritionSummary
{
    public int Carbs { get; set; }
    public int Protein { get; set; }
    public int Fat { get; set; }

    public int Energy { get; set; }

    public double CarbPercent { get; set; }
    public double ProteinPercent { get; set; }
    public double FatPercent { get; set; }

    public void CalculatePercentages()
    {
        var carbKcal = Carbs * 4;
        var proteinKcal = Protein * 4;
        var fatKcal = Fat * 9;

        Energy = carbKcal + proteinKcal + fatKcal;

        if (Energy == 0) return;

        CarbPercent = (double)carbKcal / Energy * 100;
        ProteinPercent = (double)proteinKcal / Energy * 100;
        FatPercent = (double)fatKcal / Energy * 100;
    }
}