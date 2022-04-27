public class StoreItem : IIdentifiable
{
    public StoreItem() { }
    public StoreItem(string name, decimal Price)
    {
        Name = name;
        this.Price = Price;
    }
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}