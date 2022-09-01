using AutoMapper;
using Api.DTO.v1.Identity;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.MappingProfiles;


/// <summary>
/// Class Defines AutoMapper Configuration. Defines Business Logic Layer Object Mappings To Data Access Layer And Reverse.
/// </summary>
public class AutoMapperProfile : Profile
{
    
    /// <summary>
    /// Basic AutoMapper Configuration Constructor. Configures All Mapping Profiles.
    /// </summary>
    public AutoMapperProfile()
    {
        
        /*
         * Defining Mapping For Each Business Logic Layer Data Transfer Object.
         */
        
        CreateMap<AmountUnit, BllAppDTO.AmountUnit>().ReverseMap();
        
        CreateMap<Cocktail, BllAppDTO.Cocktail>().ReverseMap();
        
        CreateMap<Drink, BllAppDTO.Drink>().ReverseMap();
        
        CreateMap<DrinkInCocktail, BllAppDTO.DrinkInCocktail>().ReverseMap();
        
        CreateMap<DrinkType, BllAppDTO.DrinkType>().ReverseMap();
        
        CreateMap<Ingredient, BllAppDTO.Ingredient>().ReverseMap();
        
        CreateMap<IngredientInCocktail, BllAppDTO.IngredientInCocktail>().ReverseMap();
        
        CreateMap<Rating, BllAppDTO.Rating>().ReverseMap();
        
        CreateMap<Step, BllAppDTO.Step>().ReverseMap();
        
        CreateMap<UserCocktail, BllAppDTO.UserCocktail>().ReverseMap();
        
        
        // Identity Related Mappings
        
        
        CreateMap<RefreshToken, BllAppDTO.Identity.RefreshToken>().ReverseMap();
        
        CreateMap<AppUser, BllAppDTO.Identity.AppUser>().ReverseMap();
        
        CreateMap<AppRole, BllAppDTO.Identity.AppRole>().ReverseMap();
        
    }
}