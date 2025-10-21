using RentCarApp.Abstracts;

namespace RentCarApp.Models
{    //  الوراثة وتعدد الأشكال 

    public class Truck : Vehicle
    {
        private double _capacity;

        public double Capacity
        {
            get => _capacity;
            set
            {
                if (value <= 0) throw new ArgumentException("Capacity must be positive");
                _capacity = value;
            }
        }

        public Truck(string brand, string model, int year, double dailyRate, double capacity)
            : base(brand, model, year, dailyRate)
        {
            Capacity = capacity;
        }

        public override string GetInfo()
        {
            return $"Truck: {Brand} {Model} ({Year}) - Capacity: {Capacity} tons, Rate: {DailyRate:C}";
        }
    }
}
