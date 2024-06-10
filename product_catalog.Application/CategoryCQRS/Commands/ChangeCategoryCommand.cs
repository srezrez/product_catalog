using MediatR;

namespace product_catalog.Application.CategoryCQRS.Commands;

public record ChangeCategoryCommand(int CategoryId, string Title) : IRequest<bool>;
