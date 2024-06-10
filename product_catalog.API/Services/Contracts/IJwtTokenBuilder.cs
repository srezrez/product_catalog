namespace product_catalog.API.Services.Contracts;

public interface IJwtTokenBuilder
{
    IJwtTokenBuilder AddUserIdClaim(string id);
    IJwtTokenBuilder AddRoleClaim(string role);

    string Build();
}
