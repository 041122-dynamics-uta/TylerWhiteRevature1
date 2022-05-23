using BagelModels;
using System.Data.SqlClient;

namespace BagelRepository
{
    public class CustomerMapperClass
    {
        public BagelCustomers DboToMember(SqlDataReader reader)
        {
            BagelCustomers bagelCustomer = new BagelCustomers
            {
            CustomerID = (int)reader[0],
            CustomerFName = (string)reader[1],
            CustomerLName = (string)reader[2],
            CustomerUsername = (string)reader[3],
            CustomerPassword = (string)reader[4]
            };
            return bagelCustomer;
        }
    }
}