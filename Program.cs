using System;
using RentCarApp.Models;
using RentCarApp.Services;

namespace RentCarApp
{
    public static class Program
    {//تشغيل التطبيق
        public static void Main()
        {
            var agency = new RentalAgency();
            agency.RentalEvent += (vehicle, msg) =>
            {
                Console.WriteLine($"[Event] {vehicle.GetInfo()} -> {msg}");
            };

            // إنشاء المركبات
            var car = new Car("Toyota", "Camry", 2022, 220, 5);
            var truck = new Truck("Volvo", "FH16", 2020, 500, 18);
            var bike = new Motorbike("Yamaha", "R1", 2023, 150, 1000);

            // إضافة المركبات المنشأة للوكالة
            agency.AddVehicle(car);
            agency.AddVehicle(truck);
            agency.AddVehicle(bike);

            // عرض المركبات
            agency.ShowAllVehicles();

            Console.WriteLine("\n--- Renting Car ---");
            agency.RentVehicle(car.Id, "Alice");

            Console.WriteLine("\n--- Returning Car ---");
            agency.ReturnVehicle(car.Id);

            Console.WriteLine($"\nTotal Vehicles in System: {RentalAgency.TotalVehiclesInSystem}");
        }
    }
}
