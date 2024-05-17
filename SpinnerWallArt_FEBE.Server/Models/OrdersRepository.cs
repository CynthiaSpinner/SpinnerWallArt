using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class OrdersRepository
    {
        public Response OrderList(Users users)
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            List<Orders> OrdersList = new List<Orders>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            var sql = "SELECT * FROM spinnerprints.orders Where @ID=ID;";
            //var users = conn.Query(sql);
            adapter.SelectCommand = new MySqlCommand(sql, conn);
            //adapter.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
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
                    response.OrdersList = OrdersList;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details NOT found";
                    response.OrdersList = OrdersList;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order details NOT found";
                response.OrdersList = OrdersList;
            }
            return response;
        }
    }
}
