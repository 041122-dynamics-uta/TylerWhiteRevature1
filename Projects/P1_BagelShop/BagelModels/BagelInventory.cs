namespace BagelModels
{
    public class BagelInventory
    {
        public Dictionary<int, int> Products { get; set; } = new Dictionary<int, int>();
        public BagelStores? Store { get; set;}
    }
}