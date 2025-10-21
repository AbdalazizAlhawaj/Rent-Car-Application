using System;
using RentCarApp.Interfaces;
using RentCarApp.Services;

namespace RentCarApp.Abstracts
{
    //تطبيق التغليف: المركبة فئة مجردة  
    public abstract class Vehicle : IRentable
    {
        //  التغليف  

        private readonly Guid _id;
        private string _brand;
        private string _model;
        private int _year;
        private double _dailyRate;
        private bool _available;
        //  خاصية ساكنة  
                public static int TotalVehicles { get; private set; } = 0;
        //  الخصائص  
        public Guid Id => _id;
        public string Brand
        {
            get => _brand;
            set
            {
                if (!Validator.ValidateNonEmpty(value))
                    throw new ArgumentException("Brand cannot be empty");
                _brand = value.Trim();
            }
        }
        public string Model
        {
            get => _model;
            set
            {
                if (!Validator.ValidateNonEmpty(value))
                    throw new ArgumentException("Model cannot be empty");
                _model = value.Trim();
            }
        }
        public int Year
        {
            get => _year;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                    throw new ArgumentOutOfRangeException(nameof(Year), "Invalid year");
                _year = value;
            }
        }
        public double DailyRate
        {
            get => _dailyRate;
            set
            {
                if (!Validator.ValidatePositive(value))
                    throw new ArgumentException("Daily rate must be positive");
                _dailyRate = value;
            }
        }
        public bool IsAvailable => _available;

        //  الأحداث والتفويض 
        public delegate void VehicleEventHandler(Vehicle vehicle, string message);
        public event VehicleEventHandler? VehicleEvent;
        //  الباني  
        protected Vehicle(string brand, string model, int year, double dailyRate)
        {
            _id = Guid.NewGuid();
            Brand = brand;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            _available = true;
            TotalVehicles++;
        }
        //  دالة مجردة  
                public abstract string GetInfo();
        //  تنفيذ الواجهة  

        public virtual bool Rent(string customerName)
        {
            if (!_available)
            {
                OnVehicleEvent($"{Brand} {Model} is not available.");
                return false;
            }
            _available = false;
            OnVehicleEvent($"{Brand} {Model} rented by {customerName}.");
            return true;
        }

        public virtual bool Return()
        {
            if (_available)
            {
                OnVehicleEvent($"{Brand} {Model} is already returned.");
                return false;
            }
            _available = true;
            OnVehicleEvent($"{Brand} {Model} returned successfully.");
            return true;
        }

        protected void OnVehicleEvent(string message)
        {
            VehicleEvent?.Invoke(this, message);
        }
    }
}
