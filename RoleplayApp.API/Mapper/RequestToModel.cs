using AutoMapper;
using RoleplayApp.API.Request;
using RoleplayApp.Infrastructure.Models;

namespace RoleplayApp.API.Mapper
{
    public class RequestToModel: Profile
    {
        public RequestToModel()
        {
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}
