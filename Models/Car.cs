using RentCarApp.Abstracts;

namespace RentCarApp.Models
{
    //  الوراثة وتعدد الأشكال 
    public class Car : Vehicle
    {
        private int _seats;

        public int Seats
        {
            get => _seats;
            set
            {
                if (value <= 0) throw new ArgumentException("Seats must be positive");
                _seats = value;
            }
        }

        public Car(string brand, string model, int year, double dailyRate, int seats)
            : base(brand, model, year, dailyRate)
        {
            Seats = seats;
        }

        public override string GetInfo()
        {
            return $"Car: {Brand} {Model} ({Year}) - Seats: {Seats}, Rate: {DailyRate:C}";
        }
    }
}
