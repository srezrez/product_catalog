namespace product_catalog.API.Requests;

public record CreateProductRequest(string Title,
                                string Description,
                                decimal Price,
                                string GeneralNote,
                                string SpecialNote,
                                int CategoryId);
