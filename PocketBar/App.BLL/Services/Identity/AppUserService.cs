using AutoMapper;
using App.Contracts.DAL;
using Base.BLL.Services;
using App.BLL.Mappers.Identity;
using App.Contracts.BLL.Services.Identity;
using App.Contracts.DAL.Repositories.Identity;


using DalAppDTO = App.DAL.DTO.Identity;
using BllAppDTO = App.BLL.DTO.Identity;


namespace App.BLL.Services.Identity;


/// <summary>
/// App User Business Logic Layer Service Design Implementation.
/// </summary>
public class AppUserService : BaseEntityService<BllAppDTO.AppUser, DalAppDTO.AppUser, IAppUnitOfWork, IAppUserRepository>, 
    IAppUserService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppUserService(IAppUnitOfWork serviceUow, IAppUserRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new AppUserMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All Users With Counter of Rated Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.AppUser>> GetAllWithCocktailsCountAsync(bool noTracking = true) =>
        (await ServiceRepository.GetAllWithCocktailsCountAsync(noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets User By Given ID With Counter of Rated Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines User ID To Search For User.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.AppUser?> FirstOrDefaultWithCocktailsCountAsync(Guid id, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultWithCocktailsCountAsync(id, noTracking));
    
}