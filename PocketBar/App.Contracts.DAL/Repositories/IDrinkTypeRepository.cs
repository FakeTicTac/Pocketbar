using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Drink Type Data Access Layer Repository Design: Basic and Custom Drink Type Repository Methods.
/// </summary>
public interface IDrinkTypeRepository : IEntityRepository<DrinkType>, 
    IDrinkTypeRepositoryCustom<DrinkType> { }


/// <summary>
/// Drink Type Data Access Layer Repository Design: Custom Drink Type Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IDrinkTypeRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Drink Type.
    
    
    /// <summary>
    /// Method Gets All Drink Types With Counters Of Drinks Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<IEnumerable<TEntity>> GetAllWithDrinksCountAsync(bool noTracking = true);
    
    /// <summary>
    /// Method Gets Drink Type By Given ID With Counters Of Drinks Asynchronously.
    /// </summary>
    /// <param name="id">Defines Drink Type ID To Search For Drink Type.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultWithDrinksCountAsync(Guid id, bool noTracking = true);

}