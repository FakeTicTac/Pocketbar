using App.DAL.DTO.Identity;
using Base.Contracts.DAL.Repositories;


namespace App.Contracts.DAL.Repositories.Identity;


/// <summary>
/// App Role Data Access Layer Repository Design: Basic and Custom App Role Repository Methods.
/// </summary>
public interface IRoleRepository : IEntityRepository<AppRole>, 
    IRoleRepositoryCustom<AppRole> { }


/// <summary>
/// App Role Data Access Layer Repository Design: Custom App Role Repository Methods. 
/// </summary>
/// <typeparam name="TEntity">Defines Type Of Entity To Work With.</typeparam>
// ReSharper disable once UnusedTypeParameter
public interface IRoleRepositoryCustom<TEntity>
{
    
    // App Specific Custom Method For App Role.
    
}