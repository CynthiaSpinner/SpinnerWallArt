using MySql.Data.MySqlClient;
using System.Data;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class CartRepository
    {
        public Response AddToCart(Cart cart)
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("Spi_AddToCart", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CartId", cart.CartID);
            cmd.Parameters.AddWithValue("@Price", cart.Price);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity); //get ID for users
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            cmd.Parameters.AddWithValue("@ProductID", cart.ProductID);
            cmd.Parameters.AddWithValue("@Size", cart.Size);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Item added";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Item was NOT added";
            }
            return response;
        }

        public Response PlaceOrder(Users users)
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("Spi_placeOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", users.ID);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Ordered Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order failed";
            }
            return response;
        }
    }
}
