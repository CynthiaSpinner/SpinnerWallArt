using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using SpinnerWallArt_FEBE.Server.Models;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public DateTime Created { get; set; }
    }
}
