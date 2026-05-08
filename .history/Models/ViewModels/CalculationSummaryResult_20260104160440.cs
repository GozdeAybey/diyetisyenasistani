using DiyetisyenApp.Models.ViewModels.Enums;

namespace DiyetisyenApp.Models.ViewModels;

public class CalculationSummaryResult
{
    public List<MacroSummaryRow> Rows { get; set; } = new();
}