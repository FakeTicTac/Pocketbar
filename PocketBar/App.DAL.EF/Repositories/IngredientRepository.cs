using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Ingredient Data Access Layer Repository Design Implementation.  
/// </summary>
public class IngredientRepository : BaseEntityRepository<DalAppDTO.Ingredient, DomainApp.Ingredient, DomainApp.Identity.AppUser, AppDbContext>, 
    IIngredientRepository
{
    
    /// <summary>
    /// Data Access Layer Ingredient Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new IngredientMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All Ingredients With Counters Of Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.Ingredient>> GetAllWithCocktailsCountAsync(bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.IngredientInCocktails);

        return (await query.ToListAsync()).Select(x => (Mapper as IngredientMapper)!.MapperWithCounter(x))!;
    }

    /// <summary>
    /// Method Gets Ingredient By Given ID With Counters Of Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines Ingredient ID To Search ForIngredient.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.Ingredient?> FirstOrDefaultWithCocktailsCountAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.IngredientInCocktails);
        
        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as IngredientMapper)!.MapperWithCounter(result);
    }
}