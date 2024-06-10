using MediatR;

namespace product_catalog.Application.ProductCQRS.Commands;

public record DeleteProductCommand(int ProductId) : IRequest<bool>;
