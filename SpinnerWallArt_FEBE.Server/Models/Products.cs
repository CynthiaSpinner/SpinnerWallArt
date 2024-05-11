using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using SpinnerWallArt_FEBE.Server.Models;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public string Size1 { get; set; }
        public string Size2 { get; set; }
        public string Size3 { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int Available { get; set; }

    }
}
//Table: products
//Columns:
//ProductID int AI PK 
//ProductName varchar(100) 
//Price1 decimal(18,2) 
//Price2 decimal(18,2) 
//Price3 decimal(18,2) 
//Size1 varchar(100) 
//Size2 varchar(100) 
//Size3 varchar(100) 
//Discount decimal(18,2) 
//Quantity int 
//ImageUrl varchar(100) 
//Available int