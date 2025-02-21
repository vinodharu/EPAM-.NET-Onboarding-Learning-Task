using System;

namespace Interitence
{
    public interface IVehicleOperations
    {
        void RentVehicle(int days);
        void ReturnVehicle();
        void CalculateRentalFee();
    }

    public abstract class VehicleBase : IVehicleOperations
    {
        public string VehicleType { get; set; }
        public int RentalDays { get; set; }
        public decimal RentalFee { get; set; }

        public VehicleBase(string vehicleType)
        {
            VehicleType = vehicleType;
        }

        public void RentVehicle(int days)
        {
            RentalDays = days;
            Console.WriteLine($"Vehicle rented: {VehicleType} for {days} days.");
        }

        public void ReturnVehicle()
        {
            Console.WriteLine($"Returning {VehicleType}.");
        }

        public abstract void CalculateRentalFee();
    }

    public class Car : VehicleBase
    {
        public Car() : base("Car") { }

        public override void CalculateRentalFee()
        {
            RentalFee = RentalDays * 30.00m;
            Console.WriteLine($"Total rental fee for Car: {RentalFee:C}");
        }
    }

    public class Bike : VehicleBase
    {
        public Bike() : base("Bike") { }

        public override void CalculateRentalFee()
        {
            RentalFee = RentalDays * 15.00m;
            Console.WriteLine($"Total rental fee for Bike: {RentalFee:C}");
        }
    }

    class Program
    {
        static void Main()
        {
            IVehicleOperations car = new Car();
            IVehicleOperations bike = new Bike();
            IVehicleOperations car1 = new Bike();

            car.RentVehicle(5); 
            car.CalculateRentalFee(); 
            car.ReturnVehicle(); 

            Console.WriteLine();

            bike.RentVehicle(3); 
            bike.CalculateRentalFee();
            bike.ReturnVehicle();

            car1.RentVehicle(1);
            car1.CalculateRentalFee();

            Console.WriteLine(); 

            Console.WriteLine("\nVehicle Rental Process Completed");
        }
    }
}