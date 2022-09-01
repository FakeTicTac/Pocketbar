using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Cocktail Data Access Layer Repository Design: Basic and Custom Cocktail Repository Methods.
/// </summary>
public interface ICocktailRepository : IEntityRepository<Cocktail>, 
    ICocktailRepositoryCustom<Cocktail> { }


/// <summary>
/// Cocktail Data Access Layer Repository Design: Custom Cocktail Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface ICocktailRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Cocktail.
    
    
    /// <summary>
    /// Method Gets All Cocktails With Counters Collections Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<IEnumerable<TEntity>> GetAllWithCountersAsync(bool noTracking = true);
    
    /// <summary>
    /// Method Gets Cocktail By Given ID With Collection Fulled With Data Asynchronously.
    /// </summary>
    /// <param name="id">Defines Cocktail ID To Search For Cocktail.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultDetailedAsync(Guid id, bool noTracking = true);

}