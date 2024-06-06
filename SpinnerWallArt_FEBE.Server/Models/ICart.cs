namespace SpinnerWallArt_FEBE.Server.Models
{
    public interface ICart
    {
        
        public Response AddToCart(Cart cart);
        public Response PlaceOrder(Orders order);
        
    }
}
