using AutoMapper;
using TakeLeaveMngSystem.Application.DTOs.User.Responses;
using TakeLeaveMngSystem.Domains.Models;

namespace TakeLeaveMngSystem.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
            //CreateMap<UserDto, User>();
        }
    }
}
