using product_catalog.Domain.Exceptionsl;

namespace product_catalog.NBRB;

public class NBRBRequestException : ProductCatalogException
{
    public NBRBRequestException(string message) : base(message) { }
}
