using BusinessObject;
using DataAccess.DAO;
using eBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserDAO _userDAO;
        private readonly RoleDAO _roleDAO;
        private readonly Random _random;

        public HomeController(ILogger<HomeController> logger, UserDAO userDAO, RoleDAO roleDAO)
        {
            _logger = logger;
            _userDAO = userDAO;
            _roleDAO = roleDAO;
            _random = new Random();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _userDAO.GetUsers().FirstOrDefault(u => u.EmailAddress == username);

            if (user == null || !VerifyPassword(user.Password, password))
            {
                ViewData["loginErr"] = "Invalid Login Attempt";
                return View();
            }

            HttpContext.Session.SetString("UserRole", user.RoleId == 1 ? "Admin" : "User");
            HttpContext.Session.SetString("UserName", user.FirstName); // Example for user's first name

            return RedirectToAction("Index");
        }
        private bool VerifyPassword(string storedPassword, string enteredPassword)
        {
            // Implement password verification logic here
            return storedPassword == enteredPassword;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear the session
            return RedirectToAction("Login", "Home"); // Redirect to login page
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string email, string password, string confirmPassword, string firstName, string lastName)
        {
            if (ModelState.IsValid)
            {
                if (password != confirmPassword)
                {
                    ViewData["registerErr"] = "Passwords do not match.";
                    return View();
                }

                var existingUser = _userDAO.GetUsers().FirstOrDefault(u => u.EmailAddress == email);
                if (existingUser != null)
                {
                    ViewData["registerErr"] = "Email is already registered.";
                    return View();
                }

                var newUser = new User
                {
                    EmailAddress = email,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    RoleId = 1,
                    PubId = _random.Next(1, 3),
                    HireDate = DateTime.Now
                };

                _userDAO.SaveUser(newUser);
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}
