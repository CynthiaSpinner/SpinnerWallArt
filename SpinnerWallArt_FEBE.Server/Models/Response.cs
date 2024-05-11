﻿using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using SpinnerWallArt_FEBE.Server.Models;

namespace SpinnerWallArt_FEBE.Server.Models
{   
        public class Response
        {
            public int StatusCode { get; set; }
            public string StatusMessage { get; set; }
            public List<Users> ListUsers { get; set; }
            public Users User { get; set; }
            public List<Products> ListProducts { get; set; }
            public Products Product { get; set; }
            public List<Cart> ListCart { get; set; }
            public List<Orders> OrdersList { get; set; }
            public Orders Order { get; set; }
            public List<OrderItems> ListItems { get; set; }
            public OrderItems OrderItem { get; set; }

        }
    
}