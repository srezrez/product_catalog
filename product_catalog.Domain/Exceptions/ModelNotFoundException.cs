using product_catalog.Domain.Exceptionsl;

namespace product_catalog.Domain.Exceptions;

public class ModelNotFoundException : ProductCatalogException
{
    public ModelNotFoundException(Type modelType, string fieldName, object fieldValue)
        : base($"Model of type: '{modelType}' with {fieldName}: '{fieldValue}' not found") { }
}
