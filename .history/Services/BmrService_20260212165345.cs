using DiyetisyenApp.Models.ViewModels;

namespace DiyetisyenApp.Services;

public class BmrService
{
    public BmrCalculationViewModel Calculate(BmrCalculationViewModel model)
    {
        // 🔹 BMI
        double heightMeter = model.Height / 100.0;
        model.BMI = model.Weight / (heightMeter * heightMeter);

        // 🔹 Harris-Benedict
        if (model.Gender == "Male")
        {
            model.HarrisBenedict =
                88.36 +
                (13.4 * model.Weight) +
                (4.8 * model.Height) -
                (5.7 * model.Age);
        }
        else
        {
            model.HarrisBenedict =
                447.6 +
                (9.2 * model.Weight) +
                (3.1 * model.Height) -
                (4.3 * model.Age);
        }

        // 🔹 Mifflin-St Jeor
        if (model.Gender == "Male")
        {
            model.Mifflin =
                (10 * model.Weight) +
                (6.25 * model.Height) -
                (5 * model.Age) + 5;
        }
        else
        {
            model.Mifflin =
                (10 * model.Weight) +
                (6.25 * model.Height) -
                (5 * model.Age) - 161;
        }

        // 🔹 Aktivite Katsayısı
        double activityMultiplier = model.ActivityLevel switch
        {
            "VeryLight" => 1.2,
            "Light" => 1.375,
            "Moderate" => 1.55,
            "Heavy" => 1.725,
            "VeryHeavy" => 1.9,
            _ => 1.2
        };

        model.TotalEnergyExpenditure =
            model.HarrisBenedict * activityMultiplier;

        return model;
    }
}