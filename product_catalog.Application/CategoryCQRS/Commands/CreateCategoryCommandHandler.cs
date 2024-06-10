using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Exceptions;
using product_catalog.Domain.Models;

namespace product_catalog.Application.CategoryCQRS.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly ICategoryReadRepository _categoryReadRepository;

    public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
        _categoryReadRepository = categoryReadRepository;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existsByTitle = await _categoryReadRepository.CheckIfExistsByTitleAsync(request.Title);
        if (existsByTitle) throw new ModelAlreadyExistsException(typeof(Category), nameof(request.Title), request.Title);

        var category = new Category { Title = request.Title };

        return await _categoryWriteRepository.CreateAsync(category);
    }
}
