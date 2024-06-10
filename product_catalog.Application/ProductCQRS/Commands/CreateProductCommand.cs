using MediatR;

namespace product_catalog.Application.ProductCQRS.Commands;

public record CreateProductCommand(string Title,
                                   string Description,
                                   decimal Price,
                                   string GeneralNote,
                                   string SpecialNote,
                                   int CategoryId) : IRequest<int>;
