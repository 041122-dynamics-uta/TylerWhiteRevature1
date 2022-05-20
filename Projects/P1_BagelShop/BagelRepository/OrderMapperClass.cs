using BagelModels;
using System.Data.SqlClient;

namespace BagelRepository
{
    public class OrderMapperClass
    {
        public BagelOrders DboToMember(SqlDataReader reader)
        {
            BagelOrders bagelOrder = new BagelOrders
            {
            OrderID = (Guid)reader["OrderID"],
		    StoreName = (string)reader["StoreName"],
		    StoreLocation = (string)reader["StoreLocation"],
            ProductName = (string)reader["ProductName"],
            ProductPrice = (decimal)reader["ProductPrice"],
            ProductTotalCost = (decimal)reader["ProductTotalCost"],
            ProductQuantity = (int)reader["ProductQuantity"],
            TotalOrderSum = (decimal)reader["TotalOrderSum"]
            };
            return bagelOrder;
        }
    }
}