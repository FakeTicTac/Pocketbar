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
/// Cocktail Business Logic Layer Service Design Implementation.
/// </summary>
public class CocktailService : BaseEntityService<BllAppDTO.Cocktail, DalAppDTO.Cocktail, IAppUnitOfWork, ICocktailRepository>, 
    ICocktailService
{
    
    /// <summary>
    /// Basis Business Logic Layer Constructor Defines Connection With Repository And Unit Of Work. 
    /// </summary>
    /// <param name="serviceUow">Data Access Layer Unit of Work Connection Definition.</param>
    /// <param name="serviceRepository">Data Access Layer Specific Repository Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CocktailService(IAppUnitOfWork serviceUow, ICocktailRepository serviceRepository, IMapper mapper) 
        : base(serviceUow, serviceRepository, new CocktailMapper(mapper)) { }


    /// <summary>
    /// Method Gets All Cocktails With Counters Collections Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<BllAppDTO.Cocktail>> GetAllWithCountersAsync(bool noTracking = true) =>
        (await ServiceRepository.GetAllWithCountersAsync(noTracking)).Select(x => Mapper.Map(x))!;

    /// <summary>
    /// Method Gets Cocktail By Given ID With Collection Fulled With Data Asynchronously.
    /// </summary>
    /// <param name="id">Defines Cocktail ID To Search For Cocktail.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<BllAppDTO.Cocktail?> FirstOrDefaultDetailedAsync(Guid id, bool noTracking = true)
    {
        
        var cocktail = await ServiceRepository.FirstOrDefaultDetailedAsync(id, noTracking);

        // Cocktail Not Found
        if (cocktail == null) return Mapper.Map(cocktail);
        
        var drinkInCocktails = new List<DalAppDTO.DrinkInCocktail>();
        var ingredientInCocktails = new List<DalAppDTO.IngredientInCocktail>();
        
        // Include Data To List Of Drinks In Cocktail
        if (cocktail.DrinksInCocktails != null)
        {
            foreach (var x in cocktail.DrinksInCocktails!) 
                drinkInCocktails.Add((await ServiceUow.DrinkInCocktails.FirstOrDefaultDetailedAsync(x.Id))!);
        }
        
        // Include Data To List Of Ingredients In Cocktail
        if (cocktail.IngredientInCocktails != null)
        {
            foreach (var x in cocktail.IngredientInCocktails!)
                ingredientInCocktails.Add((await ServiceUow.IngredientInCocktails.FirstOrDefaultDetailedAsync(x.Id))!);
        }
        
        cocktail.DrinksInCocktails = drinkInCocktails;
        cocktail.IngredientInCocktails = ingredientInCocktails;

        return Mapper.Map(cocktail);
    }
}