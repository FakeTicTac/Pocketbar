using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Ingredient In Cocktail Data Access Layer Repository Design: Basic and Custom Ingredient In Cocktail Repository Methods.
/// </summary>
public interface IIngredientInCocktailRepository : IEntityRepository<IngredientInCocktail>, 
    IIngredientInCocktailRepositoryCustom<IngredientInCocktail> { }


/// <summary>
/// Ingredient In Cocktail Data Access Layer Repository Design: Custom Ingredient In Cocktail Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IIngredientInCocktailRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Ingredient In Cocktail.
    
    
    /// <summary>
    /// Method Gets Ingredient In Cocktail By Given ID With Ingredient, Cocktail and Amount Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines Ingredient In Cocktail ID To Search For Ingredient In Cocktail.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultDetailedAsync(Guid id, bool noTracking = true);
    
}