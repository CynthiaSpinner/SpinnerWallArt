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
    public class AdminController(IAdmin AdminRepository, IWebHostEnvironment _eve) : ControllerBase
    {
        

     

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

        [HttpGet]
        [Route("GetAllOrders")]

        public Response GetAllOrders()
        {
            Response response = new Response();

            response = AdminRepository.GetAllOrders();
            return response;
        }

        [HttpPost]
        [Route("SaveFile")]

        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _eve.ContentRootPath + "/Models/Photos/" + filename;
                using(var stream = new FileStream(physicalPath,FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.jpg");
            }
        }
    }
}
