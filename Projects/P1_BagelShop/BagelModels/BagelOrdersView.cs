namespace BagelModels
{
    public class BagelOrderView
    {
        public Guid OrderID { get; set; }
        public string? StoreName { get; set; }
        public string? StoreLocation { get; set; }
        public string? ProductName { get; set; } 
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductTotalCost { get; set; }
        public decimal TotalOrderSum { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}