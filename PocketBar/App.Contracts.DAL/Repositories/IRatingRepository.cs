using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Rating Data Access Layer Repository Design: Basic and Custom Rating Repository Methods.
/// </summary>
public interface IRatingRepository : IEntityRepository<Rating>, 
    IRatingRepositoryCustom<Rating> { }


/// <summary>
/// Rating Data Access Layer Repository Design: Custom Rating Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IRatingRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Rating.
    
    
    /// <summary>
    /// Method Gets All Ratings With Counters Of Usage Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<IEnumerable<TEntity>> GetAllWithUsageCountAsync(bool noTracking = true);
    
    /// <summary>
    /// Method Gets Rating By Given ID With Counters Of Usage Asynchronously.
    /// </summary>
    /// <param name="id">Defines Rating ID To Search For ARating.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultWithUsageCountAsync(Guid id, bool noTracking = true);

}