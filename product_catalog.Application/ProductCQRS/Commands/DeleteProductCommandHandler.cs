using MediatR;
using product_catalog.DataAccess.WriteRepositories.Contracts;

namespace product_catalog.Application.ProductCQRS.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.DeleteByIdAsync(request.ProductId);
        return true;
    }
}
