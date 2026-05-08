namespace DiyetisyenApp.Models.ViewModels
{
    public class MacroFocusRow
    {
        public string FocusMacro { get; set; }
        public string Level { get; set; }

        public int TotalCalories { get; set; }

        public int Carbs { get; set; }
        public double CarbsPercent { get; set; }

        public int Protein { get; set; }
        public double ProteinPercent { get; set; }

        public int Fat { get; set; }
        public double FatPercent { get; set; }

        // 🔥 YENİ – DEĞİŞİM BİLGİSİ
        public Dictionary<string, int> ExchangeCounts { get; set; } = new();
    }
}
