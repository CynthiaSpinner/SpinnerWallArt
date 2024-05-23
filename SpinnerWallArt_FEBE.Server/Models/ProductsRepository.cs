using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class ProductsRepository : IProducts
    {
        private readonly MySqlConnection _conn;
        
        public ProductsRepository(MySqlConnection conn)
        {
            _conn = conn;           
        }
        
    }
}
