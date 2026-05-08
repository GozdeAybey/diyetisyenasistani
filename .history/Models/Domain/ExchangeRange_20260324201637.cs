
using System.ComponentModel.DataAnnotations;
namespace DiyetisyenApp.Models.Domain;

public class ExchangeRange
{
    public int FoodGroupId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Min değeri 0'dan küçük olamaz")]
    public int Min { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Max değeri 0'dan küçük olamaz")]
    public int Max { get; set; }
}