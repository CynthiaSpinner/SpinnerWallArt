using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using SpinnerWallArt_FEBE.Server.Models;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Size { get; set; }
        public decimal Discount { get; set; }
    }
}
//CartID int AI PK 
//UserID int 
//ProductID int 
//Price decimal(18,2) 
//Quantity int 
//TotalPrice decimal(18,2) 
//Size varchar(100) 
//Discount decimal(18,2)