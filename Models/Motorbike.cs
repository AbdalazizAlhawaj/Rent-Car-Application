using RentCarApp.Abstracts;

namespace RentCarApp.Models
{    //  الوراثة وتعدد الأشكال 

    public class Motorbike : Vehicle
    {
        private int _cc;

        public int CC
        {
            get => _cc;
            set
            {
                if (value <= 0) throw new ArgumentException("Engine capacity must be positive");
                _cc = value;
            }
        }

        public Motorbike(string brand, string model, int year, double dailyRate, int cc)
            : base(brand, model, year, dailyRate)
        {
            CC = cc;
        }

        public override string GetInfo()
        {
            return $"Motorbike: {Brand} {Model} ({Year}) - {CC}cc, Rate: {DailyRate:C}";
        }
    }
}
