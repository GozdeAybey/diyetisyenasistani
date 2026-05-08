using DiyetisyenApp.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace DiyetisyenApp.Models.ViewModels;

public class CalculationRequest
{
    [Range(0, 10000, ErrorMessage = "Kalori 0'dan küçük olamaz")]
    public int? MinCalories { get; set; }
    [Range(0, 10000, ErrorMessage = "Kalori 0'dan küçük olamaz")]
    public int? MaxCalories { get; set; }

    public List<ExchangeRange> ExchangeRanges { get; set; } = new();
}