using AutoMapper;
using App.DAL.DTO.Identity;

using DomainApp = App.Domain;


namespace App.DAL.DTO.MappingProfiles;


/// <summary>
/// Class Defines AutoMapper Configuration. Defines Data Access Layer Object Mappings To Entity And Reverse.
/// </summary>
public class AutoMapperProfile : Profile
{
    
    /// <summary>
    /// Basic AutoMapper Configuration Constructor. Configures All Mapping Profiles.
    /// </summary>
    public AutoMapperProfile()
    {
        
        /*
         * Defining Mapping For Each Data Access Layer Data Transfer Object.
         */
        
        CreateMap<AmountUnit, DomainApp.AmountUnit>().ReverseMap();
        
        CreateMap<Cocktail, DomainApp.Cocktail>().ReverseMap();
        
        CreateMap<Drink, DomainApp.Drink>().ReverseMap();
        
        CreateMap<DrinkInCocktail, DomainApp.DrinkInCocktail>().ReverseMap();
        
        CreateMap<DrinkType, DomainApp.DrinkType>().ReverseMap();
        
        CreateMap<Ingredient, DomainApp.Ingredient>().ReverseMap();
        
        CreateMap<IngredientInCocktail, DomainApp.IngredientInCocktail>().ReverseMap();
        
        CreateMap<Rating, DomainApp.Rating>().ReverseMap();
        
        CreateMap<Step, DomainApp.Step>().ReverseMap();
        
        CreateMap<UserCocktail, DomainApp.UserCocktail>().ReverseMap();
        
        
        // Identity Related Mappings
        
        
        CreateMap<RefreshToken, DomainApp.Identity.RefreshToken>().ReverseMap();
        
        CreateMap<AppUser, DomainApp.Identity.AppUser>().ReverseMap();
        
        CreateMap<AppRole, DomainApp.Identity.AppRole>().ReverseMap();
        
    }
}