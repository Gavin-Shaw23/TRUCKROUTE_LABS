namespace GLW_LAB1.Models
{
    public class RouteRepository
    {
        public static List<Route> _routes = new List<Route>();
        public static void addRoute(Route route)
        {
            _routes.Add(route);
        }
        public static IEnumerable<Route> Routes => _routes;
    }
}
