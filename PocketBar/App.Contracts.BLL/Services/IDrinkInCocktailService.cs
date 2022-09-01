using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Drink In Cocktail Business Logic Layer Service Design: Basic and Custom Drink In Cocktail Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IDrinkInCocktailService : IEntityService<BllAppDTO.DrinkInCocktail, DalAppDTO.DrinkInCocktail>,
    IDrinkInCocktailServiceCustom<BllAppDTO.DrinkInCocktail, DalAppDTO.DrinkInCocktail>,
    IDrinkInCocktailRepositoryCustom<BllAppDTO.DrinkInCocktail> { }


/// <summary>
/// Drink In Cocktail Business Logic Layer Service Design: Custom Drink In Cocktail Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IDrinkInCocktailServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Drink In Cocktail Service.
    
}