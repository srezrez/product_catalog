using MediatR;

namespace product_catalog.Application.CategoryCQRS.Commands;

public record DeleteCategoryCommand(int CategoryId) : IRequest<bool>;
