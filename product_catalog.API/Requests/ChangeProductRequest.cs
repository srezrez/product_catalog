namespace product_catalog.API.Requests;

public record ChangeProductRequest(int Id,
                                   string Title,
                                   string Description,
                                   decimal Price,
                                   string GeneralNote,
                                   string SpecialNote,
                                   int CategoryId);
