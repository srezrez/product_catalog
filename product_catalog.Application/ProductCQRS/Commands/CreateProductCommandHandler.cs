using MediatR;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using product_catalog.Domain.Exceptions;
using product_catalog.Domain.Models;

namespace product_catalog.Application.ProductCQRS.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public CreateProductCommandHandler(ICategoryReadRepository categoryReadRepository, IProductWriteRepository productWriteRepository)
    {
        _categoryReadRepository = categoryReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
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

        return await _productWriteRepository.CreateAsync(product);
    }
}
