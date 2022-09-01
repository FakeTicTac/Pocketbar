using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Ingredient Business Logic Layer Service Design: Basic and Custom Ingredient Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IIngredientService : IEntityService<BllAppDTO.Ingredient, DalAppDTO.Ingredient>,
    IIngredientServiceCustom<BllAppDTO.Ingredient, DalAppDTO.Ingredient>,
    IIngredientRepositoryCustom<BllAppDTO.Ingredient> { }


/// <summary>
/// Ingredient Business Logic Layer Service Design: Custom Ingredient Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IIngredientServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Ingredient Service.
    
}