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
/// Drink Type Business Logic Layer Service Design Implementation.
/// </summary>
public class DrinkTypeService : BaseEntityService<BllAppDTO.DrinkType, DalAppDTO.DrinkType, IAppUnitOfWork, IDrinkTypeRepository>, 
    IDrinkTypeService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkTypeService(IAppUnitOfWork serviceUow, IDrinkTypeRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new DrinkTypeMapper(mapper)) { }


    /// <summary>
    /// Method Gets All Drink Types With Counters Of Drinks Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.DrinkType>> GetAllWithDrinksCountAsync(bool noTracking = true) =>
        (await ServiceRepository.GetAllWithDrinksCountAsync(noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Drink Type By Given ID With Counters Of Drinks Asynchronously.
    /// </summary>
    /// <param name="id">Defines Drink Type ID To Search For Drink Type.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.DrinkType?> FirstOrDefaultWithDrinksCountAsync(Guid id, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultWithDrinksCountAsync(id, noTracking));

}