namespace product_catalog.DataAccess.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string GeneralNote { get; set; }
    public string SpecialNote { get; set; }
    public int CategoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }
}
