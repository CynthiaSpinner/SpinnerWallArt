using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class ProductsRepository : IProducts
    {
        private readonly IDbConnection _conn;

        public ProductsRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _conn.Query<Products>("SELECT * FROM spinnerprints.Products;");
        }

        public Products GetProduct(int productId)
        {
            return _conn.QuerySingle<Products>("SELECT * FROM spinnerprints.Products WHERE ProductID = @ProductID", new { productid = productId });
        }
    }
}
