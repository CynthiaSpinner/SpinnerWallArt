using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;


namespace SpinnerWallArt_FEBE.Server.Models
{
    public class AdminRepository : IAdmin
    {
        private readonly MySqlConnection _conn;
        public AdminRepository(MySqlConnection conn)
        {
            _conn = conn;
        }

        
        
        
        public Response GetAllUsers()
        {
            
            List<Users> UsersList = new List<Users>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            var sql = "SELECT * FROM spinnerprints.users;";
            //var users = conn.Query(sql);
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

    }
}
