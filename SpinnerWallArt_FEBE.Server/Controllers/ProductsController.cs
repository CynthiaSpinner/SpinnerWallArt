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
    public class ProductsController() : ControllerBase
    {
        

        //TODO:

        // add in later:
        // add ICart CartRepository and IOrders OrderRepository
        // to arguments in controller

        //[HttpPost]
        //[Route("AddToCart")]

        //public Response AddToCart(Cart cart)
        //{
        //    Response response = new Response();
        //    response = CartRepository.AddToCart(cart);
        //    return response;
        //}

        //[HttpPost]
        //[Route("PlaceOrder")]

        //public Response PlaceOrder(Users users)
        //{
        //    Response response = new Response();
        //    response = CartRepository.PlaceOrder(users);
        //    return response;
        //}

        //[HttpPost]
        //[Route("OrderList")]

        //public Response OrderList(Users users)
        //{
        //    Response response = new Response();
        //    response = OrdersRepository.OrderList(users);
        //    return response;
        //}
    }
}
