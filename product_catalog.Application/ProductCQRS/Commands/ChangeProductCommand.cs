using MediatR;

namespace product_catalog.Application.ProductCQRS.Commands;

public record ChangeProductCommand(int Id,
                                   string Title,
                                   string Description,
                                   decimal Price,
                                   string GeneralNote,
                                   string SpecialNote,
                                   int CategoryId) : IRequest<bool>;
