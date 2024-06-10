using product_catalog.Domain.Exceptionsl;

namespace product_catalog.Domain.Exceptions;

public class ModelAlreadyExistsException : ProductCatalogException
{
    public ModelAlreadyExistsException(Type modelType, string fieldName, object fieldValue)
        : base($"Model of type: '{modelType}' with {fieldName}: '{fieldValue}' already exists") { }
}
