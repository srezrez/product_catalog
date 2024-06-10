namespace product_catalog.DataAccess.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public virtual ICollection<ProductEntity> Products { get; set; }
}
