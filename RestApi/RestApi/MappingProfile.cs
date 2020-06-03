using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace RestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(dest =>
                    dest.UserName,
                    opt => opt.MapFrom(src => src.Email));

            CreateMap<UserForUpdateDto, User>().ReverseMap();
            CreateMap<User, UserDto>();

            CreateMap<RecipeForCreationDto, Recipe>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Recipe, RecipesDto>();
            CreateMap<RecipeForUpdateDto, Recipe>();

            CreateMap<DietForCreationDto, Diet>();
            CreateMap<Diet, DietDto>();
            CreateMap<DietForUpdateDto, Diet>();

            CreateMap<Rate, RateDto>();
            CreateMap<RateForCreationDto, Rate>();
        }
    }
}
