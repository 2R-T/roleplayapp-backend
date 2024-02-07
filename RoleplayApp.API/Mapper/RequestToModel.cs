using AutoMapper;
using RoleplayApp.API.Request;
using RoleplayApp.Infrastructure.Models;

namespace RoleplayApp.API.Mapper
{
    public class RequestToModel: AutoMapper.Profile
    {
        public RequestToModel()
        {
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<ProfileRequest, Infrastructure.Models.Profile>()
                .ForMember(dest => dest.First_name, opt => opt.MapFrom(src => src.First_name))
                .ForMember(dest => dest.Last_name, opt => opt.MapFrom(src => src.Last_name))
                .ForMember(dest => dest.Birth_date, opt => opt.MapFrom(src => src.Birth_date))
                .ForMember(dest => dest.Profile_picture, opt => opt.MapFrom(src => src.Profile_picture));
            CreateMap<BiographyRequest, Biography>()
                .ForMember(dest => dest.Biography_script, opt => opt.MapFrom(src => src.Biography_script));
            CreateMap<WallCommentsRequest, WallComments>()
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.Sender_id, opt => opt.MapFrom(src => src.Sender_id))
                .ForMember(dest => dest.Receiver_id, opt => opt.MapFrom(src => src.Receiver_id));
        }
    }
}
