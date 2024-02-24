using AutoMapper;
using RoleplayApp.API.Response;
using RoleplayApp.Infrastructure.Models;

namespace RoleplayApp.API.Mapper
{
    public class ModelToResponse : AutoMapper.Profile
    {
        public ModelToResponse()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<Infrastructure.Models.Profile, ProfileResponse>()
                .ForMember(dest => dest.First_name, opt => opt.MapFrom(src => src.First_name))
                .ForMember(dest => dest.Last_name, opt => opt.MapFrom(src => src.Last_name))
                .ForMember(dest => dest.Birth_date, opt => opt.MapFrom(src => src.Birth_date))
                .ForMember(dest => dest.Created_at, opt => opt.MapFrom(src => src.Created_at))
                .ForMember(dest => dest.Profile_picture, opt => opt.MapFrom(src => src.Profile_picture))
                .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography));
            CreateMap<Biography, BiographyResponse>()
                .ForMember(dest=>dest.Biography_script, opt=>opt.MapFrom(src=>src.Biography_script))
                .ForMember(dest=>dest.Biography_updated_at, opt=>opt.MapFrom(src=>src.Biography_updated_at));
            CreateMap<WallComments, WallCommentsResponse>()
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.Created_at, opt => opt.MapFrom(src => src.Created_at))
                .ForMember(dest => dest.Sender_id, opt => opt.MapFrom(src => src.Sender_id))
                .ForMember(dest => dest.Receiver_id, opt => opt.MapFrom(src => src.Receiver_id));

        }   
    }
}
