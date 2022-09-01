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
/// Ingredient In Cocktail Business Logic Layer Service Design Implementation.
/// </summary>
public class IngredientInCocktailService : BaseEntityService<BllAppDTO.IngredientInCocktail, DalAppDTO.IngredientInCocktail, IAppUnitOfWork, IIngredientInCocktailRepository>, 
    IIngredientInCocktailService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientInCocktailService(IAppUnitOfWork serviceUow, IIngredientInCocktailRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new IngredientInCocktailMapper(mapper)) { }


    /// <summary>
    /// Method Gets Ingredient In Cocktail By Given ID With Ingredient, Cocktail and Amount Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines Ingredient In Cocktail ID To Search For Ingredient In Cocktail.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.IngredientInCocktail?> FirstOrDefaultDetailedAsync(Guid id, bool noTracking = true) =>
        Mapper.Map(await ServiceRepository.FirstOrDefaultDetailedAsync(id, noTracking));
    
}