using Microsoft.IdentityModel.Tokens;
using product_catalog.API.Services.Contracts;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace product_catalog.API.Services;

public class JwtTokenBuilder : IJwtTokenBuilder
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _key;
    private readonly List<Claim> _claims;

    public JwtTokenBuilder(string issuer, string audience, string key)
    {
        _issuer = issuer;
        _audience = audience;
        _key = key;
        _claims = new List<Claim>();
    }

    public IJwtTokenBuilder AddRoleClaim(string role)
    {
        _claims.Add(new Claim(ClaimTypes.Role, role));
        return this;
    }

    public IJwtTokenBuilder AddUserIdClaim(string id)
    {
        _claims.Add(new Claim("UserId", id));
        return this;
    }

    public string Build()
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _issuer,
            Audience = _audience,
            Subject = new ClaimsIdentity(_claims),
            Expires = DateTime.Now.AddMinutes(60),
            SigningCredentials = credentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
