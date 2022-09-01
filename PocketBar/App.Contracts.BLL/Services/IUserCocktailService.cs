using Base.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using BllAppDTO = App.BLL.DTO;
using DalAppDTO = App.DAL.DTO;


namespace App.Contracts.BLL.Services;


/// <summary>
/// User Cocktail Business Logic Layer Service Design: Basic and Custom User Cocktail Service Methods. 
/// </summary>
// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IUserCocktailService : IEntityService<BllAppDTO.UserCocktail, DalAppDTO.UserCocktail>,
    IUserCocktailServiceCustom<BllAppDTO.UserCocktail, DalAppDTO.UserCocktail>,
    IUserCocktailRepositoryCustom<BllAppDTO.UserCocktail> { }


/// <summary>
/// User Cocktail Business Logic Layer Service Design: Custom User Cocktail Service Methods. 
/// </summary>
// ReSharper disable UnusedTypeParameter
public interface IUserCocktailServiceCustom<TBllEntity, TDalEntity>
{
    
    // App Specific Custom Method For User Cocktail Service.
    
}