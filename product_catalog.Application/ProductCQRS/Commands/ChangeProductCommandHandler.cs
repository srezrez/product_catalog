using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Exceptions;
using product_catalog.Domain.Models;

namespace product_catalog.Application.ProductCQRS.Commands;

public class ChangeProductCommandHandler : IRequestHandler<ChangeProductCommand, bool>
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ChangeProductCommandHandler(ICategoryReadRepository categoryReadRepository, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _categoryReadRepository = categoryReadRepository;
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    public async Task<bool> Handle(ChangeProductCommand request, CancellationToken cancellationToken)
    {
        var categoryExists = await _categoryReadRepository.CheckIfExistsByIdAsync(request.CategoryId);
        if (!categoryExists) throw new ModelNotFoundException(typeof(Category), nameof(request.CategoryId), request.CategoryId);

        var product = new Product
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            GeneralNote = request.GeneralNote,
            SpecialNote = request.SpecialNote,
            CategoryId = request.CategoryId
        };

        await _productWriteRepository.UpdateAsync(request.Id, product);

        return true;
    }
}
