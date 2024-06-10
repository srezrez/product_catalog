using Microsoft.EntityFrameworkCore;
using product_catalog.API.Services.Contracts;
using product_catalog.API.Services;
using product_catalog.DataAccess;
using product_catalog.DataAccess.ReadRepositories;
using product_catalog.DataAccess.ReadRepositories.Contracts;
using product_catalog.DataAccess.WriteRepositories;
using product_catalog.DataAccess.WriteRepositories.Contracts;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using product_catalog.API.Options;
using FluentValidation.AspNetCore;
using product_catalog.API.Filters;
using product_catalog.API.ExceptionHandling.Contracts;
using product_catalog.API.ExceptionHandling;
using product_catalog.Domain.Enums;
using Microsoft.OpenApi.Models;
using product_catalog.NBRB.Contracts;
using product_catalog.NBRB;

var builder = WebApplication.CreateBuilder(args);

#region HttpClient configuration
var apiOptions = builder.Configuration.GetSection(ApiOptions.SectionName).Get<List<ApiOptions>>();
builder.Services.AddHttpClient<IRateProvider, RateProvider>(client =>
{
    var addressProviderApiOptions = apiOptions!.FirstOrDefault(options =>
        options.Name == ApiOptions.NBRBHttpClientName);
    client.BaseAddress = new Uri(addressProviderApiOptions!.Uri);
});
#endregion

#region Mediatr configuration
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(product_catalog.Application.CategoryCQRS.Commands.ChangeCategoryCommand))));
#endregion

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

#region Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
            },
            new string[] {}
        }
    });
});
#endregion

#region DB configuration
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region AutoMapper configuration
var profileAssemblies = new[]
{
    Assembly.GetAssembly(typeof(product_catalog.DataAccess.MappingProfile.MappingProfile)),
    Assembly.GetAssembly(typeof(product_catalog.API.MappingProfile.MappingProfile)),
};
builder.Services.AddAutoMapper(profileAssemblies);
#endregion

#region DB repositories
builder.Services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
builder.Services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();
builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
builder.Services.AddScoped<IUserReadRepository, UserReadRepository>();
builder.Services.AddScoped<IUserWriteRepository, UserWriteRepository>();
#endregion

#region Jwt configuration
var jwtSection = builder.Configuration.GetSection(JwtOptions.SectionName);
builder.Services.Configure<JwtOptions>(jwtSection);

var jwtOptions = jwtSection.Get<JwtOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtOptions.ValidateIssuer,
            ValidateAudience = jwtOptions.ValidateAudience,
            ValidateLifetime = jwtOptions.ValidateLifetime,
            ValidateIssuerSigningKey = jwtOptions.ValidateIssuerSigningKey,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());
    options.AddPolicy("Admin", policy => policy.RequireRole(UserRole.Admin.ToString()));
    options.AddPolicy("User and advanced user", policy => policy.RequireRole(new[] { UserRole.User.ToString(), UserRole.AdvancedUser.ToString() }));
    options.AddPolicy("Advanced user", policy => policy.RequireRole(UserRole.AdvancedUser.ToString()));
});
#endregion

#region JWT builder
builder.Services.AddScoped<IJwtTokenBuilder>(provider =>
{
    return new JwtTokenBuilder(jwtOptions.Issuer, jwtOptions.Audience, jwtOptions.Key);
});
#endregion

#region Exception resolvers
builder.Services.AddScoped<IExceptionResolver, GlobalExceptionResolver>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
