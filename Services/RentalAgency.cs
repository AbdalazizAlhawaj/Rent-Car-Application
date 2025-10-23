using System;
using System.Collections.Generic;
using System.Linq;
using RentCarApp.Abstracts;

namespace RentCarApp.Services
{    //  فئة الخدمة 

    public class RentalAgency
    {
        // List of all vehicles managed by the agency
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();
        
        // Delegate to handle vehicle-related events such as rental and return
        public delegate void RentalEventHandler(Vehicle vehicle, string message);
        public event RentalEventHandler? RentalEvent;

        public static int TotalVehiclesInSystem => Vehicle.TotalVehicles;
        
        // Adds a new vehicle to the agency and subscribes to its event
        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
            vehicle.VehicleEvent += OnVehicleEvent;
            RentalEvent?.Invoke(vehicle, "Vehicle added to agency.");
        }
        
        // Forwards vehicle events to the agency-level event handler
        private void OnVehicleEvent(Vehicle vehicle, string message)
        {
            RentalEvent?.Invoke(vehicle, message);
        }
        
        // Displays all vehicles using polymorphism via GetInfo() method
        public void ShowAllVehicles()
        {
            Console.WriteLine("=== Vehicle List ===");
            foreach (var v in _vehicles)
                Console.WriteLine(v.GetInfo());
        }

        // Rents a vehicle by its unique ID using the Rent method from the abstract class
        public bool RentVehicle(Guid id, string customer)
        {
            var v = _vehicles.FirstOrDefault(x => x.Id == id);
            return v != null && v.Rent(customer);
        }

        // Returns a vehicle by its unique ID using the Return method from the abstract class
        public bool ReturnVehicle(Guid id)
        {
            var v = _vehicles.FirstOrDefault(x => x.Id == id);
            return v != null && v.Return();
        }
    }
}

