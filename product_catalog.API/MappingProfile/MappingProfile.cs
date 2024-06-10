using AutoMapper;
using product_catalog.API.Helpers;
using product_catalog.API.Requests;
using product_catalog.API.Responses;
using product_catalog.Application.ProductCQRS.Commands;
using product_catalog.Application.UserCQRS.Commands;
using product_catalog.Domain.Enums;
using product_catalog.Domain.Models;

namespace product_catalog.API.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<ChangeProductRequest, ChangeProductCommand>();
        CreateMap<User, UserResponse>();
        CreateMap<CreateUserRequest, CreateUserCommand>()
            .ForCtorParam(nameof(CreateUserCommand.Role),
            options => options.MapFrom(request => EnumHelper.GetEnumFromString(typeof(UserRole), request.Role)));
        CreateMap<ChangePasswordRequest, ChangePasswordCommand>();
        CreateMap<LoginRequest, AuthenticateUserCommand>();
    }
}
