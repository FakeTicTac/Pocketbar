using AutoMapper;
using App.BLL.DTO.Identity;

using DalAppDTO = App.DAL.DTO;


namespace App.BLL.DTO.MappingProfiles;


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
        
        CreateMap<AmountUnit, DalAppDTO.AmountUnit>().ReverseMap();
        
        CreateMap<Cocktail, DalAppDTO.Cocktail>().ReverseMap();
        
        CreateMap<Drink, DalAppDTO.Drink>().ReverseMap();
        
        CreateMap<DrinkInCocktail, DalAppDTO.DrinkInCocktail>().ReverseMap();
        
        CreateMap<DrinkType, DalAppDTO.DrinkType>().ReverseMap();
        
        CreateMap<Ingredient, DalAppDTO.Ingredient>().ReverseMap();
        
        CreateMap<IngredientInCocktail, DalAppDTO.IngredientInCocktail>().ReverseMap();
        
        CreateMap<Rating, DalAppDTO.Rating>().ReverseMap();
        
        CreateMap<Step, DalAppDTO.Step>().ReverseMap();
        
        CreateMap<UserCocktail, DalAppDTO.UserCocktail>().ReverseMap();
        
        
        // Identity Related Mappings
        
        
        CreateMap<RefreshToken, DalAppDTO.Identity.RefreshToken>().ReverseMap();
        
        CreateMap<AppUser, DalAppDTO.Identity.AppUser>().ReverseMap();
        
        CreateMap<AppRole, DalAppDTO.Identity.AppRole>().ReverseMap();
        
    }
}