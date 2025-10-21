using System;
using System.Collections.Generic;
using System.Linq;
using RentCarApp.Abstracts;

namespace RentCarApp.Services
{    //  فئة الخدمة 

    public class RentalAgency
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public delegate void RentalEventHandler(Vehicle vehicle, string message);
        public event RentalEventHandler? RentalEvent;

        public static int TotalVehiclesInSystem => Vehicle.TotalVehicles;

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
            vehicle.VehicleEvent += OnVehicleEvent;
            RentalEvent?.Invoke(vehicle, "Vehicle added to agency.");
        }

        private void OnVehicleEvent(Vehicle vehicle, string message)
        {
            RentalEvent?.Invoke(vehicle, message);
        }

        public void ShowAllVehicles()
        {
            Console.WriteLine("=== Vehicle List ===");
            foreach (var v in _vehicles)
                Console.WriteLine(v.GetInfo());
        }

        public bool RentVehicle(Guid id, string customer)
        {
            var v = _vehicles.FirstOrDefault(x => x.Id == id);
            return v != null && v.Rent(customer);
        }

        public bool ReturnVehicle(Guid id)
        {
            var v = _vehicles.FirstOrDefault(x => x.Id == id);
            return v != null && v.Return();
        }
    }
}
