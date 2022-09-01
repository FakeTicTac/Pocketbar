using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Drink Data Access Layer Repository Design: Basic and Custom Drink Repository Methods.
/// </summary>
public interface IDrinkRepository : IEntityRepository<Drink>, 
    IDrinkRepositoryCustom<Drink> { }


/// <summary>
/// Drink Data Access Layer Repository Design: Custom Drink Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IDrinkRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Drink.
    
    
    /// <summary>
    /// Method Gets All Drinks With Counters Of Drink In Cocktails and Drink Type Name Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<IEnumerable<TEntity>> GetAllWithDrinkTypeAndCocktailsCountAsync(bool noTracking = true);
    
    /// <summary>
    /// Method Gets Drink By Given ID With Counters Of Drink In Cocktails and Drink Type Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines Drink ID To Search For Drink.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultWithDrinkTypeAndCocktailsCountAsync(Guid id, bool noTracking = true);

}