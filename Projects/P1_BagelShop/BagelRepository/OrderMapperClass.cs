using BagelModels;
using System.Data.SqlClient;

namespace BagelRepository
{
    public class OrderMapperClass
    {
        public BagelOrderView DboToMember(SqlDataReader reader)
        {
            BagelOrderView bagelOrder = new BagelOrderView
            {
            OrderID = (Guid)reader["OrderID"],
		    StoreName = (string)reader["StoreName"],
		    StoreLocation = (string)reader["StoreLocation"],
            ProductName = (string)reader["ProductName"],
            ProductPrice = (decimal)reader["ProductPrice"],
            ProductQuantity = (int)reader["ProductQuantity"],
            TotalOrderSum = (decimal)reader["ProductTotalCost"],
            DateCreated = DateTime.Now //DateTime.Parse(reader["DateCreated"].ToString())
            };
            return bagelOrder;
        }
    }
}