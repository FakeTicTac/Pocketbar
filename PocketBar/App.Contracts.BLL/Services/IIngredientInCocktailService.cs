using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Ingredient In Cocktail Business Logic Layer Service Design: Basic and Custom Ingredient In Cocktail Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IIngredientInCocktailService : IEntityService<BllAppDTO.IngredientInCocktail, DalAppDTO.IngredientInCocktail>,
    IIngredientInCocktailServiceCustom<BllAppDTO.IngredientInCocktail, DalAppDTO.IngredientInCocktail>,
    IIngredientInCocktailRepositoryCustom<BllAppDTO.IngredientInCocktail> { }


/// <summary>
/// Ingredient In Cocktail Business Logic Layer Service Design: Custom Ingredient In Cocktail Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IIngredientInCocktailServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Ingredient In Cocktail Service.
    
}