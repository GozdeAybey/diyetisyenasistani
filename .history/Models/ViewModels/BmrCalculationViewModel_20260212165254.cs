namespace DiyetisyenApp.Models.ViewModels;

public class BmrCalculationViewModel
{
    // Girdiler
    public int Age { get; set; }
    public double Height { get; set; }   // cm
    public double Weight { get; set; }   // kg
    public string Gender { get; set; }   // "Male" / "Female"
    public string ActivityLevel { get; set; }

    // Sonuçlar
    public double BMI { get; set; }
    public double HarrisBenedict { get; set; }
    public double Mifflin { get; set; }
    public double TotalEnergyExpenditure { get; set; }
}