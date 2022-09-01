using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Amount Unit Data Access Layer Repository Design: Basic and Custom Amount Unit Repository Methods.
/// </summary>
public interface IAmountUnitRepository : IEntityRepository<AmountUnit>, 
    IAmountUnitRepositoryCustom<AmountUnit> { }


/// <summary>
/// Amount Unit Data Access Layer Repository Design: Custom Amount Unit Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IAmountUnitRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Amount Unit.
    
    
    /// <summary>
    /// Method Gets All Amount Units With Counters Of Drink And Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<IEnumerable<TEntity>> GetAllWithUsageCountsAsync(bool noTracking = true);
    
    /// <summary>
    /// Method Gets Amount Unit By Given ID With Counters Of Drink And Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines Amount Unit ID To Search For Amount Unit.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultWithUsageCountsAsync(Guid id, bool noTracking = true);
    
}