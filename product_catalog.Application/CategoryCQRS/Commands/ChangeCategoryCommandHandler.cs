using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Exceptions;
using product_catalog.Domain.Models;

namespace product_catalog.Application.CategoryCQRS.Commands;

public class ChangeCategoryCommandHandler : IRequestHandler<ChangeCategoryCommand, bool>
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public ChangeCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
    }

    public async Task<bool> Handle(ChangeCategoryCommand request, CancellationToken cancellationToken)
    {
        //TODO: а надо ли проверять или с неправильным id exception-а не будет?
        //var categoryExists = await _categoryReadRepository.CheckIfExistsByIdAsync(request.CategoryId);
        //if (!categoryExists) throw new ModelNotFoundException(typeof(Category), nameof(request.CategoryId), request.CategoryId);

        await _categoryWriteRepository.UpdateAsync(request.CategoryId, new Category { Title = request.Title} );

        return true;
    }
}
