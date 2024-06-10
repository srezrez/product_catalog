namespace product_catalog.Domain.Exceptionsl;

public class ProductCatalogException : Exception
{
    public ProductCatalogException(string message) : base(message) { }
}
