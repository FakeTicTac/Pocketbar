using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Amount Unit Business Logic Layer Service Design: Basic and Custom Amount Unit Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IAmountUnitService : IEntityService<BllAppDTO.AmountUnit, DalAppDTO.AmountUnit>,
    IAmountUnitServiceCustom<BllAppDTO.AmountUnit, DalAppDTO.AmountUnit>,
    IAmountUnitRepositoryCustom<BllAppDTO.AmountUnit> { }


/// <summary>
/// Amount Unit Business Logic Layer Service Design: Custom Amount Unit Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IAmountUnitServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Amount Unit Service.
    
}