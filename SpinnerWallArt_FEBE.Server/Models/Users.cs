﻿using System;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;


namespace SpinnerWallArt_FEBE.Server.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Type { get; set; } = string.Empty;    
        public int Status { get; set; }
        public DateTime Created { get; set; }
    }
}
