namespace GLW_LAB1.Models.ViewModel
{
    public class TruckRouteViewModel
    {
        public Truck Truck { get; set; }
        public IEnumerable<Truck> Trucks { get; set; }
        public Route Route { get; set; }
        public IEnumerable<Route> Routes { get; set; }

        public string name { get; set; }
        public string email {  get; set; }
    }
}
