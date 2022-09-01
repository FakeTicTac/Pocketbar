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
/// Ingredient Business Logic Layer Service Design Implementation.
/// </summary>
public class IngredientService : BaseEntityService<BllAppDTO.Ingredient, DalAppDTO.Ingredient, IAppUnitOfWork, IIngredientRepository>, 
    IIngredientService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientService(IAppUnitOfWork serviceUow, IIngredientRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new IngredientMapper(mapper)) { }


    /// <summary>
    /// Method Gets All Ingredients With Counters Of Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.Ingredient>> GetAllWithCocktailsCountAsync(bool noTracking = true) =>
        (await ServiceRepository.GetAllWithCocktailsCountAsync(noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Ingredient By Given ID With Counters Of Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines Ingredient ID To Search ForIngredient.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.Ingredient?> FirstOrDefaultWithCocktailsCountAsync(Guid id, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultWithCocktailsCountAsync(id, noTracking));
    
}