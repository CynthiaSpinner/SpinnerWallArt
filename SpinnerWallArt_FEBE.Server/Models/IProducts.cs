using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using SpinnerWallArt_FEBE.Server.Models;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public interface IProducts
    {
        public IEnumerable<Products> GetAllProducts();
        public Products GetProduct(int productId);
        //put update product in admin
        //put delete product in admin
    }
}
