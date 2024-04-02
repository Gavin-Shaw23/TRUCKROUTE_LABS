using GLW_LAB1.Models;

namespace GLW_LAB1.Views.Home
{
    public class TruckRepository
    {
        public static List<Truck> _trucks = new List<Truck>();
        public static void addTruck(Truck truck)
        {
            _trucks.Add(truck);
        }
        public static IEnumerable<Truck> Trucks => _trucks;
    }
}
