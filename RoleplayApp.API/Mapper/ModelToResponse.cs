using AutoMapper;
using RoleplayApp.API.Response;
using RoleplayApp.Infrastructure.Models;

namespace RoleplayApp.API.Mapper
{
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }   
    }
}
