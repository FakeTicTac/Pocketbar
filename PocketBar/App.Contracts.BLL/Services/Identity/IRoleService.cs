using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories.Identity;


using BllAppDTO = App.BLL.DTO.Identity;
using DalAppDTO = App.DAL.DTO.Identity;


namespace App.Contracts.BLL.Services.Identity;


/// <summary>
/// Role Business Logic Layer Service Design: Basic and Custom Role Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IRoleService : IEntityService<BllAppDTO.AppRole, DalAppDTO.AppRole>,
    IRoleServiceCustom<BllAppDTO.AppRole, DalAppDTO.AppRole>,
    IRoleRepositoryCustom<BllAppDTO.AppRole> { }


/// <summary>
/// Role Business Logic Layer Service Design: Custom Role Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IRoleServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Role Service.
    
}