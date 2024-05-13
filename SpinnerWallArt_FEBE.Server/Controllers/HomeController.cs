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
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //Response response = new Response();

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [HttpPost]
        [Route("Register")]
        public Response Register(Users users)
        {
            UsersRepository usersrepo = new UsersRepository();
            Response response = new Response();
            response = usersrepo.Register(users);
            return response;
        }

        //private object GetConnectionString(string v)
        //{
        //    throw new NotImplementedException();
        //}


        [HttpPost]
        [Route("Login")]
        public Response Login(Users users)
        {
            UsersRepository usersrepo = new UsersRepository();
            Response response = new Response();
            response = usersrepo.Login(users);
            return response;
        }

        //public IActionResult UserView(Users users)
        //{
        //    return View(users);
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
