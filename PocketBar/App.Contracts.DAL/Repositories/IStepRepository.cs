using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories;


/// <summary>
/// Step Data Access Layer Repository Design: Basic and Custom Step Repository Methods.
/// </summary>
public interface IStepRepository : IEntityRepository<Step>, 
    IStepRepositoryCustom<Step> { }


/// <summary>
/// Step Data Access Layer Repository Design: Custom Step Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IStepRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For Step.

    
    /// <summary>
    /// Method Gets Step By Given ID With Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines User Step ID To Search For Step.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    Task<TEntity?> FirstOrDefaultWithCocktailNameAsync(Guid id, bool noTracking = true);
    
}