using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class UsersRepository 
    {

        
        public Response Login(Users users)
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string s = "select ID, FirstName, LastName, Email, Type from spinnerprints.users where Email=@Email and  Password=@Password";
            adapter.SelectCommand = new MySqlCommand(s, conn);

            adapter.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            adapter.SelectCommand.Parameters.AddWithValue("@Password", users.Password);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
           
            Users user = new Users();
            if (dataTable.Rows.Count > 0)
            {
                user.ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dataTable.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                user.Type = Convert.ToString(dataTable.Rows[0]["Type"]);

                response.StatusCode = 200;
                response.StatusMessage = "Validated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Not validated in The System";
                response.User = null;
            }
            return response;
        }

        
        public Response Register(Users users)
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("spi_register", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // add to stored procedure if name and email are a match return 100
            //cmd.Parameters.AddWithValue("@ID", );
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@TotalAmount", 0);
            cmd.Parameters.AddWithValue("@Type", "Users");
            cmd.Parameters.AddWithValue("@Status", 2); //change status to string and set default to pending, in sql then update here and user class
            //work on getting date and time working
            conn.Open();

            int i = cmd.ExecuteNonQuery();

            conn.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Registered Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registraion Failed";
            }
            return response;
        }

        public Response UserView(Users users)
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            MySqlDataAdapter adapter = new MySqlDataAdapter("c_userView", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Response response = new Response();
            Users user = new Users();
            if (dataTable.Rows.Count > 0)
            {
                user.ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dataTable.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                user.Type = Convert.ToString(dataTable.Rows[0]["Type"]);
                user.TotalAmount = Convert.ToDecimal(dataTable.Rows[0]["TotalAmount"]);
                user.Created = Convert.ToDateTime(dataTable.Rows[0]["Created"]);
                user.Password = Convert.ToString(dataTable.Rows[0]["Password"]);

                response.StatusCode = 200;
                response.StatusMessage = "Existing user";
                response.User = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User does NOT exist";
                response.User = user;
            }
            return response;
        }

        public Response ProfileUpdate(Users users)
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("spi_profileUpdate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@FirstName", users.LastName);
            cmd.Parameters.AddWithValue("@FirstName", users.Password);
            cmd.Parameters.AddWithValue("@FirstName", users.Email);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Profile updated successfuly";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Error occured, try again later";
            }

            return response;
        }
    }
}
