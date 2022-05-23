namespace BagelModels
{
    public class BagelOrders
    {
        Guid _orderId;
        public BagelOrders()
        {
            this._orderId = Guid.NewGuid();
        }

        public Guid OrderID { get {return _orderId;} }
        public BagelStores? Store { get; set; }
        public BagelCustomers? Customer { get; set; }
        private decimal _totalOrderSum = 0;
        public decimal TotalOrderSum { get {return _totalOrderSum;} }
        private Dictionary<BagelProducts, int> _bagelProducts  = new Dictionary<BagelProducts,int>();
        public void AddBagelProduct(BagelProducts product, int quantity)
        {
            _bagelProducts.Add(product, quantity);
            _totalOrderSum += product.ProductPrice * quantity;
        }
        
        public Dictionary<BagelProducts, int> GetBagelProducts()
        {
            return _bagelProducts;
        }
    }
}