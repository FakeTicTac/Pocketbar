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
/// Drink Business Logic Layer Service Design Implementation.
/// </summary>
public class DrinkService : BaseEntityService<BllAppDTO.Drink, DalAppDTO.Drink, IAppUnitOfWork, IDrinkRepository>, 
    IDrinkService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkService(IAppUnitOfWork serviceUow, IDrinkRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new DrinkMapper(mapper)) { }


    /// <summary>
    /// Method Gets All Drinks With Counters Of Drink In Cocktails and Drink Type Name Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.Drink>> GetAllWithDrinkTypeAndCocktailsCountAsync(bool noTracking = true) =>
        (await ServiceRepository.GetAllWithDrinkTypeAndCocktailsCountAsync(noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Drink By Given ID With Counters Of Drink In Cocktails and Drink Type Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines Drink ID To Search For Drink.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.Drink?> FirstOrDefaultWithDrinkTypeAndCocktailsCountAsync(Guid id, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultWithDrinkTypeAndCocktailsCountAsync(id, noTracking));
    
}