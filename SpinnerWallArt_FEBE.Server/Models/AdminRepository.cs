using System.Data;
using Dapper;
using MySql.Data.MySqlClient;


namespace SpinnerWallArt_FEBE.Server.Models
{
    public class AdminRepository : IAdmin
    {
        private readonly MySqlConnection _conn;

        private readonly IWebHostEnvironment _eve;
        public AdminRepository(MySqlConnection conn, IWebHostEnvironment eve)
        {
            _conn = conn;
            _eve = eve;
        }        
        public Response GetAllUsers()
        {
            
            List<Users> UsersList = new List<Users>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            var sql = "SELECT * FROM spinnerprints.users;";            
            adapter.SelectCommand = new MySqlCommand(sql, _conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Users user = new Users();

                    user.ID = Convert.ToInt32(dataTable.Rows[i]["ID"]);
                    user.FirstName = Convert.ToString(dataTable.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dataTable.Rows[i]["LastName"]);
                    user.Email = Convert.ToString(dataTable.Rows[i]["Email"]);
                    user.Password = Convert.ToString(dataTable.Rows[i]["Password"]);
                    user.TotalAmount = Convert.ToDecimal(dataTable.Rows[i]["TotalAmount"]);
                    user.Status = Convert.ToInt32(dataTable.Rows[i]["Status"]);
                    user.Created = Convert.ToDateTime(dataTable.Rows[i]["Created"]);
                    
                    UsersList.Add(user);
                }
                if (UsersList.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Users details found";
                    response.ListUsers = UsersList;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Users details NOT found";
                    response.ListUsers = UsersList;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Users details NOT found";
                response.ListUsers = UsersList;
            }
            return response;
        }

        public Response GetAllProducts()
        {

            List<Products> ListProducts = new List<Products>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            var sql = "SELECT * FROM spinnerprints.products;";
            adapter.SelectCommand = new MySqlCommand(sql, _conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Products product = new Products();

                    product.ProductID = Convert.ToInt32(dataTable.Rows[i]["ProductId"]);
                    product.ProductName = Convert.ToString(dataTable.Rows[i]["ProductName"]);
                    product.Price1 = Convert.ToDecimal(dataTable.Rows[i]["Price1"]);
                    product.Price2 = Convert.ToDecimal(dataTable.Rows[i]["Price2"]);
                    product.Price3 = Convert.ToDecimal(dataTable.Rows[i]["Price3"]);
                    product.Size1 = Convert.ToString(dataTable.Rows[i]["Size1"]);
                    product.Size2 = Convert.ToString(dataTable.Rows[i]["Size2"]);
                    product.Size3 = Convert.ToString(dataTable.Rows[i]["Size3"]);
                    product.Quantity = Convert.ToInt32(dataTable.Rows[i]["Quantity"]);
                    product.Available = Convert.ToInt32(dataTable.Rows[i]["Available"]);//change to string here and sql
                    product.Discount = Convert.ToDecimal(dataTable.Rows[i]["Discount"]);
                    product.ImageUrl = Convert.ToString(dataTable.Rows[i]["ImageUrl"]);

                    ListProducts.Add(product);
                }
                if (ListProducts.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "products details found";
                    response.ListProducts = ListProducts;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "products details NOT found";
                    response.ListProducts = ListProducts;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "products details NOT found";
                response.ListProducts = ListProducts;
            }
            return response;
        }

        public Response AddAndUpdateProd(Products products)
        {            
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("Spi_AddAndUpdateProd", _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductName", products.ProductName);
            cmd.Parameters.AddWithValue("@Price1", products.Price1);
            cmd.Parameters.AddWithValue("@Price2", products.Price2);
            cmd.Parameters.AddWithValue("@Price3", products.Price3);
            cmd.Parameters.AddWithValue("@Size1", products.Size1);
            cmd.Parameters.AddWithValue("@Size2", products.Size2);
            cmd.Parameters.AddWithValue("@Size3", products.Size3);
            cmd.Parameters.AddWithValue("@Quantity", products.Quantity);
            cmd.Parameters.AddWithValue("@Discount", products.Discount);
            cmd.Parameters.AddWithValue("@Available", products.Available);
            cmd.Parameters.AddWithValue("@ImageUrl", products.ImageUrl);            

            _conn.Open();
            int i = cmd.ExecuteNonQuery();
            _conn.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Added successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product NOT saved! Try again";
            }

            return response;
        }
        public Response DeleteProduct(Products products)
        {
            Response response = new Response();
    
            _conn.Open();
            int i = _conn.Execute("DELETE FROM spinnerprints.products WHERE @ProductName = ProductName;", new { productName = products.ProductName });
            _conn.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product deleted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product NOT deleted! Try again";
            }
            return response;
        }

        public Response GetAllOrders()
        {
            List<Orders> OrdersList = new List<Orders>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            var sql = "SELECT * FROM spinnerprints.orders;";            
            adapter.SelectCommand = new MySqlCommand(sql, _conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.OrderID = Convert.ToInt32(dataTable.Rows[i]["OrderID"]);
                    order.OrderNumber = Convert.ToInt32(dataTable.Rows[i]["OrderNumber"]);
                    order.ID = Convert.ToInt32(dataTable.Rows[i]["ID"]);
                    order.OrderTotal = Convert.ToDecimal(dataTable.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dataTable.Rows[i]["OrderStatus"]);

                    OrdersList.Add(order);
                }
                if (OrdersList.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Displaying All Orders";
                    response.ListOrders = OrdersList;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Orders NOT found";
                    response.ListOrders = OrdersList;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Orders NOT found";
                response.ListOrders = OrdersList;
            }
            return response;
        }

    }
}
