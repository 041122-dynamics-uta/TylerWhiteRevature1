namespace BagelModels
{
    public class BagelCustomers
    {
        public int CustomerID { get; set; }
        public string? CustomerFName { get; set; }
        public string? CustomerLName { get; set; }
        public string? CustomerUsername { get; set; }
        public string? CustomerPassword { get; set; }

/*         public BagelCustomers(string CustomerFName, string CustomerLName, string CustomerUsername, string CustomerPassword)
        {
            this.CustomerID = -1;
            this.CustomerFName = CustomerFName;
            this.CustomerLName = CustomerLName;
            this.CustomerUsername = CustomerUsername;
            this.CustomerPassword = CustomerPassword;
        } */
    }
}