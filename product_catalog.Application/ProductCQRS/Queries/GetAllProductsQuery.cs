using MediatR;
using product_catalog.Domain.Models;

namespace product_catalog.Application.ProductCQRS.Queries;

public record GetAllProductsQuery(string? Title, int? CategoryId) : IRequest<IReadOnlyCollection<Product>>;
