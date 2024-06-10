using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.Domain.Models;

namespace product_catalog.Application.CategoryCQRS.Queries;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IReadOnlyCollection<Category>>
{
    private readonly ICategoryReadRepository _categoryReadRepository;

    public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
    }

    public async Task<IReadOnlyCollection<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryReadRepository.GetAllAsync();
    }
}
