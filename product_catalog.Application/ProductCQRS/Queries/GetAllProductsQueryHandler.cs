using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.Domain.Models;

namespace product_catalog.Application.ProductCQRS.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyCollection<Product>>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetAllProductsQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<IReadOnlyCollection<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productReadRepository.GetAllFilteredAsync(request.Title, request.CategoryId);
    }
}
