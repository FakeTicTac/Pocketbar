using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Drink Type Business Logic Layer Service Design: Basic and Custom Drink Type Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IDrinkTypeService : IEntityService<BllAppDTO.DrinkType, DalAppDTO.DrinkType>,
    IDrinkTypeServiceCustom<BllAppDTO.DrinkType, DalAppDTO.DrinkType>,
    IDrinkTypeRepositoryCustom<BllAppDTO.DrinkType> { }


/// <summary>
/// Drink Type Business Logic Layer Service Design: Custom Drink Type Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IDrinkTypeServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Drink Type Service.
    
}