using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Ingredient Data Access Layer Repository Design: Basic and Custom Ingredient Repository Methods.
/// </summary>
public interface IIngredientRepository : IEntityRepository<Ingredient>, 
    IIngredientRepositoryCustom<Ingredient> { }


/// <summary>
/// Ingredient Data Access Layer Repository Design: Custom Ingredient Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IIngredientRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Ingredient.
    
    
    /// <summary>
    /// Method Gets All Ingredients With Counters Of Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<IEnumerable<TEntity>> GetAllWithCocktailsCountAsync(bool noTracking = true);
    
    /// <summary>
    /// Method Gets Ingredient By Given ID With Counters Of Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines Ingredient ID To Search ForIngredient.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultWithCocktailsCountAsync(Guid id, bool noTracking = true);

}