using System.Data;
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
        public Response OrderList(Users users)
        {            
            List<Orders> OrdersList = new List<Orders>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            var sql = "SELECT * FROM spinnerprints.orders Where @ID=ID;";
            adapter.SelectCommand = new MySqlCommand(sql, _conn);
            adapter.SelectCommand.Parameters.AddWithValue("@ID", users.ID); //Work out getting orders to user id 

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.ID = Convert.ToInt32(dataTable.Rows[i]["ID"]);
                    order.OrderNumber = Convert.ToInt32(dataTable.Rows[i]["OrderNumber"]);
                    order.OrderTotal = Convert.ToDecimal(dataTable.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dataTable.Rows[i]["OrderStatus"]);
                    OrdersList.Add(order);
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
    }
}
