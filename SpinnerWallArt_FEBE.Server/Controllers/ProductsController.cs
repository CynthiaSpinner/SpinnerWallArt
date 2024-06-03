using Microsoft.AspNetCore.Mvc;
using SpinnerWallArt_FEBE.Server.Models;



namespace SpinnerWallArt_FEBE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ICart CartRepository, IOrders OrdersRepository) : ControllerBase
    {
        

        //TODO:

        // add in later:
        // add ICart CartRepository and IOrders OrderRepository
        // to arguments in controller

        [HttpPost]
        [Route("AddToCart")]

        public Response AddToCart(Cart cart)
        {
            Response response = new Response();
            response = CartRepository.AddToCart(cart);
            return response;
        }

        [HttpPost]
        [Route("PlaceOrder")]

        public Response PlaceOrder(Orders order)
        {
            Response response = new Response();
            response = CartRepository.PlaceOrder(order);
            return response;
        }

        [HttpPost]
        [Route("OrderList")]

        public Response OrderList(Orders order)
        {
            Response response = new Response();
            response = OrdersRepository.OrderList(order);
            return response;
        }
    }
}
