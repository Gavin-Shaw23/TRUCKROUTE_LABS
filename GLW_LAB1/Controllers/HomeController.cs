using GLW_LAB1.Models;
using GLW_LAB1.Views.Home;
using GLW_LAB1.Models.ViewModel;
using GLW_LAB1.Views.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using Route = GLW_LAB1.Models.Route;

namespace GLW_LAB1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (null != _httpContextAccessor.HttpContext.Session.GetString("CurrentUser"))
                return View(JsonSerializer.Deserialize<User>(_httpContextAccessor.HttpContext.Session.GetString("CurrentUser")));
            return View(null);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            var existingUser = UserRepository.Users.FirstOrDefault(u => u.Email_address == user.Email_address);
            if (existingUser != null)
            {
                ViewBag.Message = ("A user with this email address already exists. Do you want to <a href='/Home/Login'>Login</a>?");
                return View("Index");
            }

            if (user.Password != user.ConfirmPassword)
            {
                ViewBag.Message = ("Password and its confirmation do not match.");
                return View("Index");
            }

            UserRepository.addUser(user);
            ViewBag.Message = ("Account creation successful. Please log in.");
            return View("Login");
        }

        public IActionResult LoginPage()
        {
            var currentUser = _httpContextAccessor.HttpContext.Session.GetString("CurrentUser");
            if (currentUser == null)
                return View("Login");

            User item = JsonSerializer.Deserialize<User>(_httpContextAccessor.HttpContext.Session.GetString("CurrentUser"));
            var viewModel = new TruckRouteViewModel
            {
                Trucks = TruckRepository.Trucks,
                Truck = new Truck(),
                Routes = RouteRepository.Routes,
                Route = new Models.Route(),
                email = item.Email_address,
                name = (item.First_name + " " + item.Last_name)
            };
            return View("Dashboard", viewModel);
        }

        public IActionResult Dashboard
            ()
        {
            var currentUser = _httpContextAccessor.HttpContext.Session.GetString("CurrentUser");
            if (currentUser == null)
                return View("Login");

            User item = JsonSerializer.Deserialize<User>(_httpContextAccessor.HttpContext.Session.GetString("CurrentUser"));
            var viewModel = new TruckRouteViewModel
            {
                Trucks = TruckRepository.Trucks,
                Truck = new Truck(),
                Routes = RouteRepository.Routes,
                Route = new Models.Route(),
                email = item.Email_address,
                name = (item.First_name + " " + item.Last_name)
            };

            return View("Dashboard", viewModel);
        }

        [HttpPost]
        public IActionResult Dashboard(User user)
        {
            var currentUser = _httpContextAccessor.HttpContext.Session.GetString("CurrentUser");
            if (currentUser != null)
                return View("Dashboard");

            if (UserRepository.Users != null && UserRepository.Users.Any())
            {
                foreach (var item in UserRepository.Users)
                {
                    if (string.Equals(item.Email_address, user.Email_address, StringComparison.OrdinalIgnoreCase) && item.Password == user.Password)
                    {
                        var userJson = JsonSerializer.Serialize(item);
                        _httpContextAccessor.HttpContext.Session.SetString("CurrentUser", userJson);
                        var viewModel = new TruckRouteViewModel
                        {
                            Trucks = TruckRepository.Trucks,
                            Truck = new Truck(),
                            Routes = RouteRepository.Routes,
                            Route = new Models.Route(),
                            email = item.Email_address,
                            name = (item.First_name + " " + item.Last_name)
                        };
                        return View("Dashboard", viewModel);
                    }
                }
                ViewBag.Message = ("Your email or password is incorrect.");
                return View("Login");
            }
            else
            {
                ViewBag.Message = ("Please create an account before logging in.");
                return View("Index");
            }
        }

        public IActionResult TruckPage(Truck truck)
        {
            if (ModelState.IsValid)
                TruckRepository.addTruck(truck);

            var truckViewModel = new TruckRouteViewModel
            {
                Trucks = TruckRepository.Trucks,
                Truck = new Truck()
            };
            return View("Truck", truckViewModel);
        }

        public IActionResult RoutePage(Route route)
        {
            if (ModelState.IsValid)
                RouteRepository.addRoute(route);

            var routeViewModel = new TruckRouteViewModel
            {
                Routes = RouteRepository.Routes,
                Route = new Models.Route()
            };
            return View("Route", routeViewModel);
        }

        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Session.Remove("CurrentUser");
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
