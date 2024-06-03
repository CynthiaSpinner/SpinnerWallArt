namespace SpinnerWallArt_FEBE.Server.Models
{
    public interface ICart
    {
        //TODO
        //for cart and placing orders
        //implement from repository
        public Response AddToCart(Cart cart);
        public Response PlaceOrder(Orders order);
        
    }
}
