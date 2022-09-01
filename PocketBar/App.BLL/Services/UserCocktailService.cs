using AutoMapper;
using App.BLL.Mappers;
using App.Contracts.DAL;
using Base.BLL.Services;
using App.Contracts.BLL.Services;
using App.Contracts.DAL.Repositories;


using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Services;


/// <summary>
/// User Cocktail Business Logic Layer Service Design Implementation.
/// </summary>
public class UserCocktailService : BaseEntityService<BllAppDTO.UserCocktail, DalAppDTO.UserCocktail, IAppUnitOfWork, IUserCocktailRepository>, 
    IUserCocktailService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserCocktailService(IAppUnitOfWork serviceUow, IUserCocktailRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new UserCocktailMapper(mapper)) { }


    /// <summary>
    /// Method Gets All User Cocktails With Rating Value And Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="userId">Defines User ID To Search For User Cocktails.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.UserCocktail>> GetAllDetailedAsync(Guid userId = default, bool noTracking = true) =>
        (await ServiceRepository.GetAllDetailedAsync(userId, noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets User Cocktail By Given ID With Rating Value And Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines User Cocktail ID To Search For User Cocktail.</param>
    /// <param name="userId">Defines User Id To Search For User Cocktail</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.UserCocktail?> FirstOrDefaultDetailedAsync(Guid id, Guid userId = default, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultDetailedAsync(id, userId, noTracking));
    
}