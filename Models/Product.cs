

public class Product
{
    public int id;
    public string title { get; set; }
    public double price { get; set; }
    public string description { get; set; }
    public Category category { get; set; }
    public int categoryId { get; set; }
    public string[] images { get; set; }
    public string imagesText { get; set; }
}
