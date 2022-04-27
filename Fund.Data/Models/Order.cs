public class Order : IIdentifiable
{
    public Order() { }
    public Order(List<StoreItem> storeItems)
    {
        StoreItems = storeItems;
    }

    public int ID { get; set; }
    public List<StoreItem> StoreItems { get; set; } = new List<StoreItem>();
    public decimal TotalCost
    {
        get
        {
            return ComputeTotal();
        }
    }

    private decimal ComputeTotal()
    {
        //mr. compiler, please go into the StoreItems list and add all of the items by their price!!!
        return StoreItems.Sum(x => x.Price);
    }
}