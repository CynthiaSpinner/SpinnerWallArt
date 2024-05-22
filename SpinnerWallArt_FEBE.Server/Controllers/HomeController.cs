using Microsoft.AspNetCore.Mvc;
using SpinnerWallArt_FEBE.Server.Models;

namespace SpinnerWallArt_FEBE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(IUsers UsersRepository) : Controller
    {
    
        [HttpPost]
        [Route("Register")]
        public Response Register(Users users)
        {
            
            Response response = new Response();
            response = UsersRepository.Register(users);
            return response;
        }

        [HttpPost]
        [Route("Login")]
        public Response Login(Users users)
        {
            Response response = new Response();
            response = UsersRepository.Login(users);
            return response;
        }

        //TODO:
        //public Response UserView(Users users); <---- might not use
        //public Response ProfileUpdate(Users users);
    }
}
