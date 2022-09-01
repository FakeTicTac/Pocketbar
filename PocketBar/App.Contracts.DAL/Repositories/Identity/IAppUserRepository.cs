using App.DAL.DTO.Identity;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories.Identity;


/// <summary>
/// App User Data Access Layer Repository Design: Basic and Custom App User Repository Methods.
/// </summary>
public interface IAppUserRepository : IEntityRepository<AppUser>, 
    IAppUserRepositoryCustom<AppUser> { }


/// <summary>
/// App User Data Access Layer Repository Design: Custom App User Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IAppUserRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For App User.
    
    
    /// <summary>
    /// Method Gets All Users With Counter of Rated Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<IEnumerable<TEntity>> GetAllWithCocktailsCountAsync(bool noTracking = true);
    
    /// <summary>
    /// Method Gets User By Given ID With Counter of Rated Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines User ID To Search For User.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultWithCocktailsCountAsync(Guid id, bool noTracking = true);

}