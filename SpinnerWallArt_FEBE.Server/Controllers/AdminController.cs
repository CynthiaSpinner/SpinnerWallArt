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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Configuration;


namespace SpinnerWallArt_FEBE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAdmin AdminRepository) : ControllerBase
    {
        //private readonly IDbConnection _conn;
        //public AdminController(IDbConnection conn)
        //{
        //    _conn = conn;
        //}
        //private readonly AdminRepository admin;
        //Response response = new Response();

        //public AdminController(AdminRepository admin)
        //{
        //    this.admin = admin;
        //}

        [HttpGet]
        [Route("GetAllUsers")]        
        public Response GetAllUsers()
        {
            Response response = new Response();
             
            response = AdminRepository.GetAllUsers();
            return response;
        }


        [HttpPost]
        [Route("AddAndUpdateProd")]

        public Response AddAndUpdateProd(Products products)
        {


            Response response = new Response();
            
            response = AdminRepository.AddAndUpdateProd(products);
            return response;
        }

        [HttpPost]
        [Route("DeleteProduct")]

        public Response DeleteProduct(Products products) 
        {
            Response response = new Response();
            
            response = AdminRepository.DeleteProduct(products);
            return response;
        }
    }
}
