using product_catalog.Domain.Exceptionsl;

namespace product_catalog.Domain.Exceptions;

public class IncorrectLoginOrPasswordException : ProductCatalogException
{
    public IncorrectLoginOrPasswordException() : base("Incorrect login or password") { }
}
