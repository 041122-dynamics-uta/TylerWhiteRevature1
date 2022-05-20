namespace BagelModels
{
    public class BagelProducts
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

/*         public BagelProducts(string ProductName, string Description, decimal ProductPrice)
        {
            this.ProductID = -1;
            this.ProductName = ProductName;
            this.ProductDescription = ProductDescription;
            this.ProductPrice = ProductPrice;
        } */

    }
}