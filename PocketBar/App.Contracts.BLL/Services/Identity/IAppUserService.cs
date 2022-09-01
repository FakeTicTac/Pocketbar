using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories.Identity;


using BllAppDTO = App.BLL.DTO.Identity;
using DalAppDTO = App.DAL.DTO.Identity;


namespace App.Contracts.BLL.Services.Identity;


/// <summary>
/// App User Business Logic Layer Service Design: Basic and Custom App User Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IAppUserService : IEntityService<BllAppDTO.AppUser, DalAppDTO.AppUser>,
    IAppUserServiceCustom<BllAppDTO.AppUser, DalAppDTO.AppUser>,
    IAppUserRepositoryCustom<BllAppDTO.AppUser> { }


/// <summary>
/// App User Business Logic Layer Service Design: Custom App User Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IAppUserServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For App User Service.
    
}