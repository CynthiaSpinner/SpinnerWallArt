using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using SpinnerWallArt_FEBE.Server.Models;
using Dapper;

namespace SpinnerWallArt_FEBE.Server.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Response response = new Response();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        //[HttpPost]
        //[Route("Register")]
        //public IActionResult Register(Users users)
        //{
        //    MySqlConnection connection = new MySqlConnection(GetConnectionString("spinner").ToString());
        //    response = UsersRepository.Register(users, connection);
        //    return View();
        //}

        private object GetConnectionString(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult Login(string email, string password)
        {
            return View();
        }

        public IActionResult UserView(Users users)
        {
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
