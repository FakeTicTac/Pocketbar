using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Rating Business Logic Layer Service Design: Basic and Custom Rating Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IRatingService : IEntityService<BllAppDTO.Rating, DalAppDTO.Rating>,
    IRatingServiceCustom<BllAppDTO.Rating, DalAppDTO.Rating>,
    IRatingRepositoryCustom<BllAppDTO.Rating> { }


/// <summary>
/// Rating Business Logic Layer Service Design: Custom Rating Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IRatingServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Rating Service.
    
}