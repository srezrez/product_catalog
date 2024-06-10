namespace product_catalog.API.Requests;

public record GetAllProductsRequest(string? Title, int? CategoryId);
