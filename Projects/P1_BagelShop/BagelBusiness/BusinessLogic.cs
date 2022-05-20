using BagelModels;
using BagelRepository;

namespace BagelBusiness
{
    public class BusinessLogic
    {
        //Creates a new repo object only for this class
        private BagelRepoClass _repo = new BagelRepoClass();
        //Creates a new order (object only for this class)
        private BagelOrders _order = new BagelOrders();
        
        //Get first time customer's registration (NEED TO CHECK IF THAT REGISTRATION IS ALREADY IN THE DB)
        public BagelCustomers CustomerRegister(string custFName, string custLName, string custUsername, string custPass){
            BagelCustomers c = _repo.NewCustomer(custFName, custLName, custUsername, custPass);
            return c;
        }

        //Customer login
        public BagelCustomers CustomerLogin(string custUsername, string custPass){
            List<BagelCustomers> c = _repo.CustomerList(custUsername, custPass);
            if (c.Count == 1)
            {
               return c.First();
            }
            return null;
        }

        //Allows customer to view their past purchases from a store
        public List<BagelOrders> GetPastOrders(BagelCustomers loggedInCustomer){
            List<BagelOrders> pastOrders = _repo.ViewPastOrders(loggedInCustomer);
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
        public void AddProductToOrder(int productID, int productQuantity)
        {
            //_order.Products.Add(productID, productQuantity);
        }

        //PlaceOrder takes in storeID and customerID and adds that to the pending order
        //Then we add the total cost of all products/quantities to the pending order
        //Then we add the order to the Db
        public void PlaceOrder(int storeID, int customerID)
        {
/*             _order.StoreID = storeID;
            _order.CustomerID = customerID;
            _order.DateCreated = DateTime.Now;
        
            _order.ProductTotalCost = GetTotalCostofOrder(storeID);
            _repo.CreateOrder(_order);
            //TODO Remove order products from inventory
 */
        }

        //This method returns the total order cost
        //Private access modifier as only this class needs to see it
        private decimal GetTotalCostofOrder(int storeID)
        {
           decimal currentTotalCost = 0;
 /*           //Fetches all products from a specific store (by ID)
            List<BagelProducts> allProducts = GetProductsByStore(storeID);
            
            //Iterating over the products in the pending order.
            foreach(var productInOrder in _order.Products)
            {
                //quantityPerProduct is the product count of one product in the pending order (Value is quantity)
                int quantityPerProduct = productInOrder.Value;

                //Iterating over all the products from the chosen specific store
                foreach(BagelProducts inventoriedProduct in allProducts)
                {
                    //If the Product PK in the pending order lines up with a corresponding product pk at that store
                    if (inventoriedProduct.ProductID == productInOrder.Key)
                    {
                       currentTotalCost += inventoriedProduct.ProductPrice + quantityPerProduct;
                    }
                }
            }*/
            return currentTotalCost; 
        }
        
    }
}