namespace product_catalog.API.Options;

public class ApiOptions
{
    public const string SectionName = "ApiOptions";
    public const string NBRBHttpClientName = "NBRB_API";
    public string Name { get; set; }
    public string Uri { get; set; }
}