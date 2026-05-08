namespace DiyetisyenApp.Models.ViewModels
{
    public class MacroFocusRow
    {
        public string FocusMacro { get; set; }   // KH / Protein / Yağ
        public string Level { get; set; }        // Min / Orta / Max
        public int TotalCalories { get; set; }

        public int Carbs { get; set; }
        public double CarbsPercent { get; set; }

        public int Protein { get; set; }
        public double ProteinPercent { get; set; }

        public int Fat { get; set; }
        public double FatPercent { get; set; }
    }
}