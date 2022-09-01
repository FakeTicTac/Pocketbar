using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// Cocktail Business Logic Layer Service Design: Basic and Custom Cocktail Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface ICocktailService : IEntityService<BllAppDTO.Cocktail, DalAppDTO.Cocktail>,
    ICocktailServiceCustom<BllAppDTO.Cocktail, DalAppDTO.Cocktail>,
    ICocktailRepositoryCustom<BllAppDTO.Cocktail> { }


/// <summary>
/// Cocktail Business Logic Layer Service Design: Custom Cocktail Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface ICocktailServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For Cocktail Service.
    
}