using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// User Cocktail Data Access Layer Repository Design: Basic and Custom User Cocktail Repository Methods.
/// </summary>
public interface IUserCocktailRepository : IEntityRepository<UserCocktail>, 
    IUserCocktailRepositoryCustom<UserCocktail> { }


/// <summary>
/// User Cocktail Data Access Layer Repository Design: Custom User Cocktail Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IUserCocktailRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For User Cocktail.

    
    /// <summary>
    /// Method Gets All User Cocktails With Rating Value And Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="userId">Defines User ID To Search For User Cocktails.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<IEnumerable<TEntity>> GetAllDetailedAsync(Guid userId = default, bool noTracking = true);

    /// <summary>
    /// Method Gets User Cocktail By Given ID With Rating Value And Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines User Cocktail ID To Search For User Cocktail.</param>
    /// <param name="userId">Defines User Id To Search For User Cocktail</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultDetailedAsync(Guid id, Guid userId = default, bool noTracking = true);

}