using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Step Business Logic Layer Service Design: Basic and Custom Step Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IStepService : IEntityService<BllAppDTO.Step, DalAppDTO.Step>,
    IStepServiceCustom<BllAppDTO.Step, DalAppDTO.Step>,
    IStepRepositoryCustom<BllAppDTO.Step> { }


/// <summary>
/// Step Business Logic Layer Service Design: Custom Step Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IStepServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Step Service.
    
}