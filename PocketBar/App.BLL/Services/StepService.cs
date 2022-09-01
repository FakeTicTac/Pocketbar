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
/// Step Business Logic Layer Service Design Implementation.
/// </summary>
public class StepService : BaseEntityService<BllAppDTO.Step, DalAppDTO.Step, IAppUnitOfWork, IStepRepository>, 
    IStepService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public StepService(IAppUnitOfWork serviceUow, IStepRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new StepMapper(mapper)) { }


    /// <summary>
    /// Method Gets Step By Given ID With Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines User Step ID To Search For Step.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.Step?> FirstOrDefaultWithCocktailNameAsync(Guid id, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultWithCocktailNameAsync(id, noTracking));

}