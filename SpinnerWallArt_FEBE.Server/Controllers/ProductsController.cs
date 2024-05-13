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

        [HttpPost]
        [Route("AddToCart")]

        public Response AddToCart(Cart cart)
        {
            CartRepository cartRepo = new CartRepository();
            Response response = new Response();
            response = cartRepo.AddToCart(cart);
            return response;
        }

        [HttpPost]
        [Route("PlaceOrder")]

        public Response PlaceOrder(Users users)
        {
            CartRepository cartRepo = new CartRepository();
            Response response = new Response();
            response = cartRepo.PlaceOrder(users);
            return response;
        }

        [HttpPost]
        [Route("OrderList")]
        public Response OrderList(Users users)
        {
            OrdersRepository ordersRepo = new OrdersRepository();
            Response response = new Response();
            response = ordersRepo.OrderList(users);
            return response;
        }
    }
}
