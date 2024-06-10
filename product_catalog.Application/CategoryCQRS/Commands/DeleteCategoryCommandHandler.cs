using MediatR;
using product_catalog.DataAccess.WriteRepositories.Contracts;

namespace product_catalog.Application.CategoryCQRS.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryWriteRepository.DeleteByIdAsync(request.CategoryId);
        return true;
    }
}
