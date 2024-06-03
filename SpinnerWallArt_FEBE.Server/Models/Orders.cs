
namespace SpinnerWallArt_FEBE.Server.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int ID { get; set; }
        public int OrderNumber { get; set; }        
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public string UserID { get; set; }
        public DateTime OrderCreated { get; set; }
    }
}
//UserID int 
//OrderNumber int 
//OrderTotal decimal(18,2) 
//OrderStatus varchar(100) 
//ID int 
//OrderID int AI PK