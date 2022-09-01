using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Drink Business Logic Layer Service Design: Basic and Custom Drink Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IDrinkService : IEntityService<BllAppDTO.Drink, DalAppDTO.Drink>,
    IDrinkServiceCustom<BllAppDTO.Drink, DalAppDTO.Drink>,
    IDrinkRepositoryCustom<BllAppDTO.Drink> { }


/// <summary>
/// Drink Business Logic Layer Service Design: Custom Drink Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IDrinkServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Drink Service.
    
}