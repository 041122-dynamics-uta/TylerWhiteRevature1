using System.Data.SqlClient;
using BagelModels;

namespace BagelRepository

{
    public class ProductMapperClass
    {
        public BagelProducts DboToMember(SqlDataReader reader)
        {
            BagelProducts bagelProduct = new BagelProducts
            {
            ProductID = (int)reader["ProductId"],
            ProductName = (string)reader["ProductName"],
            ProductDescription = (string)reader["ProductDescription"],
            ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
            };
            return bagelProduct;
        }
    }
}