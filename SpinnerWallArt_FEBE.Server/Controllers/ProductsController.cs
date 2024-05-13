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
    public class ProductsController : Controller
    {
        [HttpPost]
        [Route("GetAllProducts")]
        public Response GetAllProducts(Products products)
        {
            ProductsRepository prodRepo = new ProductsRepository();   
            Response response = new Response();
            response = prodRepo.GetAllProducts(products);
            return response;
        }
    }
}
