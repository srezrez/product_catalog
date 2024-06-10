using AutoMapper;
using product_catalog.DataAccess.Entities;
using product_catalog.Domain.Models;

namespace product_catalog.DataAccess.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserEntity>().ReverseMap();
        CreateMap<Category, CategoryEntity>().ReverseMap();
        CreateMap<Product, ProductEntity>().ReverseMap();
    }
}
