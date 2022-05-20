using BagelModels;
using System.Data.SqlClient;

namespace BagelRepository
{
    public class StoreMapperClass
    {
        public BagelStores DboToMember(SqlDataReader reader)
        {
            BagelStores bagelStore = new BagelStores
            {
            StoreID = (int)reader[0],
            StoreName = (string)reader[1],
            StoreLocation = (string)reader[2],
            };
            return bagelStore;
        }
    }
}