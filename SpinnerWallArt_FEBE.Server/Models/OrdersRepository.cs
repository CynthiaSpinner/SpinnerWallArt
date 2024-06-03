using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class OrdersRepository : IOrders
    {
        private readonly MySqlConnection _conn;
        public OrdersRepository(MySqlConnection conn)
        {
            _conn = conn;

        }
        public Response OrderList(Orders order)
        {            
            List<Orders> OrdersList = new List<Orders>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            var sql = "SELECT * FROM spinnerprints.orders Where @ID=ID;";
            adapter.SelectCommand = new MySqlCommand(sql, _conn);
            adapter.SelectCommand.Parameters.AddWithValue("@ID", order.ID); //Work out getting orders to user id 

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Orders orders = new Orders();
                    orders.ID = Convert.ToInt32(dataTable.Rows[i]["ID"]);
                    orders.OrderNumber = Convert.ToInt32(dataTable.Rows[i]["OrderNumber"]);
                    orders.OrderTotal = Convert.ToDecimal(dataTable.Rows[i]["OrderTotal"]);
                    orders.OrderStatus = Convert.ToString(dataTable.Rows[i]["OrderStatus"]);
                    orders.OrderCreated = Convert.ToDateTime(dataTable.Rows[i]["OrderCreated"]);
                    OrdersList.Add(orders);
                }
                if (OrdersList.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Order details found";
                    response.ListOrders = OrdersList;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details NOT found";
                    response.ListOrders = OrdersList;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order details NOT found";
                response.ListOrders = OrdersList;
            }
            return response;
        }

        public Response DeleteOrder(Orders order)
        {
            Response response = new Response();

            _conn.Open();
            int i = _conn.Execute("DELETE FROM spinnerprints.orders WHERE @OrderID = OrderID;", new { OrderID = order.OrderID });
            _conn.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order deleted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order NOT deleted! Try again";
            }
            return response;
        }

        public Response AddAndUpdateOrder(Orders order)
        {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("Spi_AddAndUpdateOrder", _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", order.UserID);
            cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
            cmd.Parameters.AddWithValue("@OrderTotal", order.OrderTotal);
            cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
            cmd.Parameters.AddWithValue("@ID", order.ID);
            cmd.Parameters.AddWithValue("@OrderCreated", order.OrderCreated);
    

            _conn.Open();
            int i = cmd.ExecuteNonQuery();
            _conn.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order Added successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order NOT saved! Try again";
            }

            return response;
        }
    }
}
