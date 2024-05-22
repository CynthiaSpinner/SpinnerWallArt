
namespace SpinnerWallArt_FEBE.Server.Models
{
    public interface IUsers
    {
        public Response Register(Users users);
        public Response Login(Users users);
        public Response UserView(Users users); //might take this out
        public Response ProfileUpdate(Users users);
    }
}
