using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using SpinnerWallArt_FEBE.Server.Models;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class OrderItems
    {
        public int ItemsID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public decimal Discount { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
//ItemsID int AI PK 
//OrderID int 
//ProductID int 
//Price decimal(18,2) 
//Size varchar(100) 
//Discount decimal(18,2) 
//Quantity int 
//TotalPrice decimal(18,