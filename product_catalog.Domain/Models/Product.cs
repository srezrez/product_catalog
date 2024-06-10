namespace product_catalog.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string GeneralNote { get; set; }
    public string SpecialNote { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
