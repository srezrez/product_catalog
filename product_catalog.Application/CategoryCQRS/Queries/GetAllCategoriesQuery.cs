using MediatR;
using product_catalog.Domain.Models;

namespace product_catalog.Application.CategoryCQRS.Queries;

public record GetAllCategoriesQuery() : IRequest<IReadOnlyCollection<Category>>;
