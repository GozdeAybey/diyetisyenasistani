namespace DiyetisyenApp.Models.ViewModels;

public class CalculationSummaryResult
{
    public MacroResult MaxProtein { get; set; }
    public MacroResult MinProtein { get; set; }
    public MacroResult AvgProtein { get; set; }

    public MacroResult MaxCarbs { get; set; }
    public MacroResult MinCarbs { get; set; }
    public MacroResult AvgCarbs { get; set; }

    public MacroResult MaxFat { get; set; }
    public MacroResult MinFat { get; set; }
    public MacroResult AvgFat { get; set; }
}