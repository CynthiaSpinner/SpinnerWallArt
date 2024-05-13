using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace SpinnerWallArt_FEBE.Server.Models
{
    public class ProductsRepository 
    {
        //private readonly IDbConnection _conn;

        //public ProductsRepository(IDbConnection conn)
        //{
        //    _conn = conn;
        //}

        public Response GetAllProducts(Products products)
        {
            var conn = new MySqlConnection("Server=localhost;Database=spinnerprints;uid=root;Pwd=password;Port=3306;");
            List<Products> ListProducts = new List<Products>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            var sql = "SELECT * FROM spinnerprints.products;";
            //var users = conn.Query(sql);
            adapter.SelectCommand = new MySqlCommand(sql, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);





            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Products product = new Products();
                    product.ProductID = Convert.ToInt32(dataTable.Rows[i]["ProductId"]);
                    product.ProductName = Convert.ToString(dataTable.Rows[i]["ProductName"]);
                    product.Price1 = Convert.ToInt32(dataTable.Rows[i]["Price1"]);
                    product.Price2 = Convert.ToInt32(dataTable.Rows[i]["Price2"]);
                    product.Price3 = Convert.ToInt32(dataTable.Rows[i]["Price3"]);
                    product.Size1 = Convert.ToString(dataTable.Rows[i]["Size1"]);
                    product.Size2 = Convert.ToString(dataTable.Rows[i]["Size2"]);
                    product.Size3 = Convert.ToString(dataTable.Rows[i]["Size3"]);
                    product.Quantity = Convert.ToInt32(dataTable.Rows[i]["Quantity"]);
                    product.Available = Convert.ToInt32(dataTable.Rows[i]["Available"]);//change to string here and sql
                    product.Discount = Convert.ToInt32(dataTable.Rows[i]["Discount"]);
                    product.ImageUrl = Convert.ToString(dataTable.Rows[i]["ImageUrl"]);
                    //user.Created = Convert.ToDateTime(dataTable.Rows[i]["Created"]);
                    ListProducts.Add(product);
                }
                if (ListProducts.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Users details found";
                    response.ListProducts = ListProducts;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Users details NOT found";
                    response.ListProducts = ListProducts;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Users details NOT found";
                response.ListProducts = ListProducts;
            }
            return response;
        }

        //public Products GetProduct(int productId)
        //{
        //    return _conn.QuerySingle<Products>("SELECT * FROM spinnerprints.Products WHERE ProductID = @ProductID", new { productid = productId });
        //}

        
    }
}
