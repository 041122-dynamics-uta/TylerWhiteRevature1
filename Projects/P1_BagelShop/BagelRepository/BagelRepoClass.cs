using BagelModels;
using System.Data.SqlClient;
using System.Data;

namespace BagelRepository;
public class BagelRepoClass
{
    public CustomerMapperClass cMap { get; set; } = new CustomerMapperClass();
    public ProductMapperClass pMap { get; set; } = new ProductMapperClass();
    public StoreMapperClass sMap { get; set; } = new StoreMapperClass();
    public OrderMapperClass oMap { get; set; } = new OrderMapperClass();
    string connectionString = "Server=tcp:tylerwhiteserver.database.windows.net,1433;Initial Catalog=TylerWhiteDB;Persist Security Info=False;User ID=TylerWhiteDB;Password=Jackjack8;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    //Returns customers based on parameters or all
    public List<BagelCustomers> CustomerList(string customerUsername = null, string customerPass = null) //the "= null" sets the default values so these parameters are made optional. If this is the case, the parameterized SELECT statement below never runs
    {
        string custQuery;
        //The if statement checks that the customer does not exist yet in the dB
        //The condition also checks that the user doesn't enter null values for their first and last name (when registering)
        if (!string.IsNullOrEmpty(customerUsername) && !string.IsNullOrEmpty(customerPass))
        {
            //This is for logging in, checking to verify username and password do not already exist
            custQuery = $"SELECT * FROM BagelShop.Customers WHERE CustomerUsername='{customerUsername}' AND CustomerPassword='{customerPass}';";
        }
        else{
            custQuery = "SELECT * FROM BagelShop.Customers;";
        }
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(custQuery, connection);
            command.Connection.Open();
            SqlDataReader results = command.ExecuteReader();

            List<BagelCustomers> customer = new List<BagelCustomers>();
            while (results.Read())
            {
                customer.Add(this.cMap.DboToMember(results));
            }

            connection.Close();
            return customer;
        }
    }

    //Registers a new customer
    public BagelCustomers NewCustomer(string custFName, string custLName, string custUsername, string custPass)
    {
        string custInsert = "INSERT INTO BagelShop.Customers (CustomerFName, CustomerLName, CustomerUsername, CustomerPassword) VALUES (@f, @l, @u, @p);";

        using (SqlConnection query = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(custInsert, query);
            command.Parameters.AddWithValue("@f", custFName);
            command.Parameters.AddWithValue("@l", custLName);
            command.Parameters.AddWithValue("@u", custUsername);
            command.Parameters.AddWithValue("@p", custPass);
            query.Open();
            int results = command.ExecuteNonQuery();
            query.Close();

            if (results == 1)
            {
                BagelCustomers c = new BagelCustomers
                {
                    CustomerFName = custFName,
                    CustomerLName = custLName,
                    CustomerUsername = custUsername,
                    CustomerPassword = custPass
                };
                return c;
            }
            return null;
        }
    }

    //Returns all stores
    public List<BagelStores> StoreList()
    {
        string StoreQuery1 = "SELECT * FROM BagelShop.Stores;";
        using (SqlConnection query = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(StoreQuery1, query);
            command.Connection.Open();
            SqlDataReader results = command.ExecuteReader();

            List<BagelStores> store = new List<BagelStores>();
            while (results.Read())
            {
                store.Add(this.sMap.DboToMember(results));
            }

            query.Close();
            return store;
        }
    }

    //Returns all products, not needed
    public List<BagelProducts> ProductList()
    {
        string ProdQuery1 = "SELECT * FROM BagelShop.Products;";
        using (SqlConnection query = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(ProdQuery1, query);
            command.Connection.Open();
            SqlDataReader results = command.ExecuteReader();

            List<BagelProducts> product = new List<BagelProducts>();
            while (results.Read())
            {
                product.Add(this.pMap.DboToMember(results));
            }

            query.Close();
            return product;
        }
    }

    //Returns all products in a given store
    public List<BagelProducts> ProductsByStore(int storeID)
    {
        string ProdQuery1 = $"SELECT [BagelShop].[Products].ProductName,"
        +"[BagelShop].[Products].ProductDescription,"
        +"[BagelShop].[Products].ProductPrice,"
        +"[BagelShop].[Stores].StoreName,"
        +"[BagelShop].[Stores].StoreLocation,"
        +"[BagelShop].[Inventory].StoreID,"
        +"[BagelShop].[Inventory].ProductID,"
        +"[BagelShop].[Inventory].InventoryQuantity"
        +" FROM [BagelShop].[Products]"
        +" INNER JOIN [BagelShop].[Inventory]"
        +" ON [BagelShop].[Products].ProductID = [BagelShop].[Inventory].ProductID"
        +" INNER JOIN [BagelShop].[Stores]"
        +" ON [BagelShop].[Stores].StoreID = [BagelShop].[Inventory].StoreID"
        +$" WHERE [BagelShop].[Inventory].StoreID = {storeID} ORDER BY StoreID, ProductID;";

        using (SqlConnection query = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(ProdQuery1, query);
            command.Connection.Open();
            SqlDataReader results = command.ExecuteReader();

            List<BagelProducts> product = new List<BagelProducts>();
            while (results.Read())
            {
                product.Add(this.pMap.DboToMember(results));
            }

            query.Close();
            return product;
        }
    }

    public List<BagelOrderView> ViewPastOrders(BagelCustomers loggedInCustomer) 
    {
        string orderQuery = $"SELECT "
+"		o.OrderId as [OrderID],"
+"		s.StoreName as [StoreName],"
+"		s.StoreLocation as [StoreLocation],"
+"		p.ProductName as [ProductName],"
+"		p.ProductPrice as [ProductPrice],"
+"		o.ProductTotalCost as [ProductTotalCost],"
+"		o.ProductQuantity as [ProductQuantity],"
+"		Cast(0.0 as decimal) [TotalOrderSum]"
+"	FROM [BagelShop].[Orders] as [o]"
+"		inner join [BagelShop].[Products] as [p]"
+"			on p.ProductId = o.ProductId"
+"		inner join [BagelShop].[Stores] as [s]"
+"			on s.StoreId = o.StoreId"
+"		inner join [BagelShop].[Customers] as [c]"
+"			on c.CustomerId = o.CustomerId"
+$"	WHERE [c].CustomerID = {loggedInCustomer.CustomerID};";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(orderQuery, connection);
            command.Connection.Open();
            SqlDataReader results = command.ExecuteReader();

            List<BagelOrderView> pastOrders = new List<BagelOrderView>();
            while (results.Read())
            {
                pastOrders.Add(this.oMap.DboToMember(results));
            }

            connection.Close();
            return pastOrders;
        }
    }

    //This is a method to create a new order
    public void CreateOrder(BagelOrders orders)
    {
        string newOrder = "INSERT INTO BagelShop.Orders (OrderID, StoreID, ProductID, CustomerID, ProductQuantity, ProductTotalCost) VALUES (@oID, @sID, @pID, @cID, @pQuantity, @pTotalCost);";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            foreach(var products in orders.GetBagelProducts())
            {
                SqlCommand command = new SqlCommand(newOrder, connection);
                command.Parameters.AddWithValue("@oID", orders.OrderID);
                command.Parameters.AddWithValue("@sID", orders.Store.StoreID);
                command.Parameters.AddWithValue("cID", orders.Customer.CustomerID);
                command.Parameters.AddWithValue("@pQuantity", products.Value);
                command.Parameters.AddWithValue("@pID", products.Key.ProductID);
                command.Parameters.AddWithValue("@pTotalCost", orders.TotalOrderSum);
                int results = command.ExecuteNonQuery();
            }
                connection.Close();
        }
    }

    public void UpdateInventory(BagelOrders orders)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            foreach(var product in orders.GetBagelProducts())
            {
                // Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "BagelShop.UpdateInventory";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameters and set its properties.
                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@StoreID";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = orders.Store.StoreID;
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@ProductID";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = product.Key.ProductID;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@QuantityUpdate";
                parameter3.SqlDbType = SqlDbType.SmallInt;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = product.Value;
                command.Parameters.Add(parameter3);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
