using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using SpinnerWallArt_FEBE.Server.Controllers;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class AdminRepository 
    {
        //private readonly IDbConnection _conn;
        //public AdminRepository(IDbConnection conn)
        //{
        //    _conn = conn;
        //}

        
        
        
        public Response GetAllUsers()
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            List<Users> UsersList = new List<Users>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            var sql = "SELECT * FROM spinnerprints.users;";
            //var users = conn.Query(sql);
            adapter.SelectCommand = new MySqlCommand(sql, conn);
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
                    //user.Created = Convert.ToDateTime(dataTable.Rows[i]["Created"]);
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
    }
}
