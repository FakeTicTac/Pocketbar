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
/// Rating Business Logic Layer Service Design Implementation.
/// </summary>
public class RatingService : BaseEntityService<BllAppDTO.Rating, DalAppDTO.Rating, IAppUnitOfWork, IRatingRepository>, 
    IRatingService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RatingService(IAppUnitOfWork serviceUow, IRatingRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new RatingMapper(mapper)) { }


    /// <summary>
    /// Method Gets All Ratings With Counters Of Usage Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.Rating>> GetAllWithUsageCountAsync(bool noTracking = true) =>
        (await ServiceRepository.GetAllWithUsageCountAsync(noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Rating By Given ID With Counters Of Usage Asynchronously.
    /// </summary>
    /// <param name="id">Defines Rating ID To Search For ARating.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.Rating?> FirstOrDefaultWithUsageCountAsync(Guid id, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultWithUsageCountAsync(id, noTracking));
    
}