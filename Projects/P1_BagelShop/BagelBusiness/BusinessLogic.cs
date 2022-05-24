using BagelModels;
using BagelRepository;

namespace BagelBusiness
{
    public class BusinessLogic
    {
        //Creates a new repo object only for this class
        private BagelRepoClass _repo = new BagelRepoClass();
        //Order object only for this class
        private BagelOrders _order = new BagelOrders();
        //Logged in Customer object only for this 

        private BagelCustomers _loggedInCustomer = new BagelCustomers();
        public BagelCustomers LoggedInCustomer
        {
            get
            {
                return _loggedInCustomer;
            }
        }
       
        //Get first time customer's registration
        public BagelCustomers CustomerRegister(string custFName, string custLName, string custUsername, string custPass){
            BagelCustomers customer = _repo.NewCustomer(custFName, custLName, custUsername, custPass);
            _loggedInCustomer = customer;
            return _loggedInCustomer;
        }

        //Customer login
        public BagelCustomers CustomerLogin(string custUsername, string custPass){
            List<BagelCustomers> customer = _repo.CustomerList(custUsername, custPass);
            if (customer.Count == 1)
            {
                _loggedInCustomer = customer.First(); //need .First() because customer is a list and we only need one
                return _loggedInCustomer;
            }
            return null;
        }

        //Allows customer to view their past purchases from a store
        public List<BagelOrderView> GetPastOrders(BagelCustomers loggedInCustomer){
            List<BagelOrderView> pastOrders = _repo.ViewPastOrders(loggedInCustomer);
            return pastOrders;
        }

        public List<BagelStores> GetAllStores()
        {
            List<BagelStores> bagelStores = new List<BagelStores>();
            return _repo.StoreList();         
        }

        //Not needed, but to fetch all the products
        public List<BagelProducts> GetAllProducts()
        {
            List<BagelProducts> bagelProducts = new List<BagelProducts>();
            return _repo.ProductList();         
        }

        //Method to get all products by store ID
        public List<BagelProducts> GetProductsByStore(int storeID)
        {
            List<BagelProducts> bagelProducts = new List<BagelProducts>();
            return _repo.ProductsByStore(storeID);         
        }

        //This method adds productID and quantity to your pending order
        //"Products" is a Dictionary with the key = productID and the value = productQuantity
        public void AddProductToOrder(BagelProducts product, int productQuantity)
        {
            _order.AddBagelProduct(product, productQuantity);
        }

        //PlaceOrder takes in storeID and customerID and adds that to the pending order
        //Then we add the order to the Db
        public void PlaceOrder(BagelStores store)
        {
            _order.Store = store;
            _order.Customer = _loggedInCustomer;
            _repo.CreateOrder(_order);
            _repo.UpdateInventory(_order);
        }        
    }
}