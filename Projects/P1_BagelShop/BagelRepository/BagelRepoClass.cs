using BagelModels;
using System.Data.SqlClient;

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
        if (!string.IsNullOrEmpty(customerUsername) && !string.IsNullOrEmpty(customerPass))
        {
            //This is for logging in, checking to verify username and password do not already exist
            custQuery = $"SELECT * FROM BagelShop.Customers WHERE CustomerUsername={customerUsername} AND CustomerPassword={customerPass};";
        }
        else{
            custQuery = "SELECT * FROM BagelShop.Customers;";
        }
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            //The if statement checks that the customer does not exist yet in the dB
            //The condition also checks that the user doesn't enter null values for their first and last name (when registering)
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

    //Returns all products (not needed)
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
        +$" WHERE [BagelShop].[Inventory].StoreID = {storeID};";

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

    public List<BagelOrders> ViewPastOrders(BagelCustomers loggedInCustomer) 
    {
        string orderQuery = $"SELECT "
+"		o.OrderId as [OrderID],"
+"		s.StoreName as [StoreName],"
+"		s.StoreLocation as [StoreLocation],"
+"		p.ProductName as [ProductName],"
+"		p.ProductPrice as [ProductPrice],"
+"		o.ProductTotalCost as [ProductTotalCost],"
+"		o.ProductQuantity as [ProductQuantity],"
+"		0 [TotalOrderSum]"
+"	FROM [BagelShop].[Orders] as [o]"
+"		inner join [BagelShop].[Products] as [p]"
+"			on p.ProductId = o.ProductId"
+"		inner join [BagelShop].[Stores] as [s]"
+"			on s.StoreId = o.StoreId"
+"		inner join [BagelShop].[Customers] as [c]"
+"			on c.CustomerId = o.CustomerId"
+$"	WHERE [c].CustomerID = {loggedInCustomer};";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(orderQuery, connection);
            command.Connection.Open();
            SqlDataReader results = command.ExecuteReader();

            List<BagelOrders> pastOrders = new List<BagelOrders>();
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
        string ProdQuery1 = $"INSERT INTO BagelShop.ProductOrders (ProductID, OrderID, ProductQuantity) VALUES(2, 102, 2);";
        string ProdQuery2 = $"INSERT INTO BagelShop.Orders (StoreID, CustomerID, ProductTotalCost, DateCreated) VALUES(5, 1, 10, GetDate());";

        using (SqlConnection query = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(ProdQuery1, query);
            command.Connection.Open();
            int results = command.ExecuteNonQuery();
            
            query.Close();
        }
    }
}
