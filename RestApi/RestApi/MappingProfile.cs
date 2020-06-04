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
            CreateMap<Recipe, RecipeDto>()
                .ForMember(
                    dest => dest.LikesNumber,
                    opt => opt.MapFrom(src => src.LikedRecipes.Count));
            CreateMap<Recipe, RecipesDto>()
                .ForMember(
                    dest => dest.LikesNumber,
                    opt => opt.MapFrom(src => src.LikedRecipes.Count));
            CreateMap<Recipe, RecipesWithLikedRecipeIdDto>()
                .ForMember(
                    dest => dest.LikesNumber,
                    opt => opt.MapFrom(src => src.LikedRecipes.Count));
            CreateMap<RecipeForUpdateDto, Recipe>();

            CreateMap<DietForCreationDto, Diet>();
            CreateMap<Diet, DietDto>();

            CreateMap<Rate, RateDto>();
            CreateMap<RateForCreationDto, Rate>();

            CreateMap<LikedRecipeForCreationDto, LikedRecipe>();
            CreateMap<LikedRecipe, LikedRecipeDto>();
        }
    }
}
