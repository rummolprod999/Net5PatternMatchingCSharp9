using System;

namespace Net5PatternMatchingCSharp9
{
    class Program
    {
        static void Main()
        {
            Car car = new Car();
            Console.WriteLine($"{CalculateToll(car)}");
        }
        
        public static decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Car c => c.Passengers switch
                {
                    0 => 2.00m + 0.5m,
                    1 => 2.0m,
                    2 => 2.0m - 0.5m,
                    _ => 2.00m - 1.0m
                },

                Taxi t => t.Fares switch
                {
                    0 => 3.50m + 1.00m,
                    1 => 3.50m,
                    2 => 3.50m - 0.50m,
                    _ => 3.50m - 1.00m
                },

                Bus b when (b.Riders / b.Capacity) < 0.50 => 5.00m + 2.00m,
                Bus b when (b.Riders / b.Capacity) > 0.90 => 5.00m - 1.00m,
                Bus => 5.00m,

                DeliveryTruck t when (t.GrossWeightClass >= 5000) => 10.00m + 5.00m,
                DeliveryTruck t when (t.GrossWeightClass >= 3000 && t.GrossWeightClass < 5000) => 10.00m,
                DeliveryTruck => 8.00m,

                null => throw new ArgumentNullException(nameof(vehicle)),
                _ => throw new ArgumentException(nameof(vehicle))
            };
    }
}