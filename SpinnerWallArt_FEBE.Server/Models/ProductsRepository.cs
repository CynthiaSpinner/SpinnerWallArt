using System.Data;
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
        public Response GetAllProducts(Products products)
        {          
            List<Products> ListProducts = new List<Products>();
            Response response = new Response();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            var sql = "SELECT * FROM spinnerprints.products;";
            adapter.SelectCommand = new MySqlCommand(sql, _conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {

                    Products product = new Products();
                    
                    product.ProductID = Convert.ToInt32(dataTable.Rows[i]["ProductId"]);
                    product.ProductName = Convert.ToString(dataTable.Rows[i]["ProductName"]);
                    product.Price1 = Convert.ToDecimal(dataTable.Rows[i]["Price1"]);
                    product.Price2 = Convert.ToDecimal(dataTable.Rows[i]["Price2"]);
                    product.Price3 = Convert.ToDecimal(dataTable.Rows[i]["Price3"]);
                    product.Size1 = Convert.ToString(dataTable.Rows[i]["Size1"]);
                    product.Size2 = Convert.ToString(dataTable.Rows[i]["Size2"]);
                    product.Size3 = Convert.ToString(dataTable.Rows[i]["Size3"]);
                    product.Quantity = Convert.ToInt32(dataTable.Rows[i]["Quantity"]);
                    product.Available = Convert.ToInt32(dataTable.Rows[i]["Available"]);//change to string here and sql
                    product.Discount = Convert.ToDecimal(dataTable.Rows[i]["Discount"]);
                    product.ImageUrl = Convert.ToString(dataTable.Rows[i]["ImageUrl"]);

                    ListProducts.Add(product);
                }
                if (ListProducts.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "products details found";
                    response.ListProducts = ListProducts;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "products details NOT found";
                    response.ListProducts = ListProducts;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "products details NOT found";
                response.ListProducts = ListProducts;
            }            
            return response;
        } 
    }
}
