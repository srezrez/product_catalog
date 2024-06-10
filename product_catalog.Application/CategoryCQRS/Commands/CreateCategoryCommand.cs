using MediatR;

namespace product_catalog.Application.CategoryCQRS.Commands;

public record CreateCategoryCommand(string Title) : IRequest<int>;
