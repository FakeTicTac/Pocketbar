using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Drink In Cocktail Data Access Layer Repository Design: Basic and Custom Drink In Cocktail Repository Methods.
/// </summary>
public interface IDrinkInCocktailRepository : IEntityRepository<DrinkInCocktail>, 
    IDrinkInCocktailRepositoryCustom<DrinkInCocktail> { }


/// <summary>
/// Drink In Cocktail Data Access Layer Repository Design: Custom Drink In Cocktail Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IDrinkInCocktailRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Drink In Cocktail.
    
    
    /// <summary>
    /// Method Gets Drink In Cocktail By Given ID With Amount Unit, Cocktail and Drink Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines Drink In Cocktail ID To Search For Drink In Cocktail.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultDetailedAsync(Guid id, bool noTracking = true);
    
}