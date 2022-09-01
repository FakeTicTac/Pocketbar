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
/// Amount Unit Business Logic Layer Service Design Implementation.
/// </summary>
public class AmountUnitService : BaseEntityService<BllAppDTO.AmountUnit, DalAppDTO.AmountUnit, IAppUnitOfWork, IAmountUnitRepository>, 
    IAmountUnitService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AmountUnitService(IAppUnitOfWork serviceUow, IAmountUnitRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new AmountUnitMapper(mapper)) { }


    /// <summary>
    /// Method Gets All Amount Units With Counters Of Drink And Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.AmountUnit>> GetAllWithUsageCountsAsync(bool noTracking = true) =>
        (await ServiceRepository.GetAllWithUsageCountsAsync(noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Amount Unit By Given ID With Counters Of Drink And Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines Amount Unit ID To Search For Amount Unit.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.AmountUnit?> FirstOrDefaultWithUsageCountsAsync(Guid id, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultWithUsageCountsAsync(id, noTracking));
    
}