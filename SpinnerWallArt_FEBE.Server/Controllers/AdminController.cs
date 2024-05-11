using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using SpinnerWallArt_FEBE.Server.Models;


namespace SpinnerWallArt_FEBE.Server.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin admin;
        Response response = new Response();
        
        public AdminController(IAdmin admin)
        {
            this.admin = admin;
        }

        [HttpGet]
        [Route("GetAllUsers")]        
        public IEnumerable<Users> GetAllUsers()
        {
            MySqlConnection connection = new MySqlConnection("spinner");
            
            return admin.GetAllUsers();
        }
    }
}
