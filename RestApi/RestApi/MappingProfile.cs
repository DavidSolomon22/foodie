using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace RestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, AuthUser>()
                .ForMember(dest =>
                    dest.UserName,
                    opt => opt.MapFrom(src => src.Email));
        }
    }
}