using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Cocktail Data Access Layer Repository Design Implementation.  
/// </summary>
public class CocktailRepository : BaseEntityRepository<DalAppDTO.Cocktail, DomainApp.Cocktail, DomainApp.Identity.AppUser, AppDbContext>, 
    ICocktailRepository
{
    
    /// <summary>
    /// Data Access Layer Cocktail Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CocktailRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new CocktailMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All Cocktails With Counters Collections Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.Cocktail>> GetAllWithCountersAsync(bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.IngredientInCocktails)
            .Include(x => x.DrinkInCocktails)
            .Include(x => x.Steps)
            .Include(x => x.UserCocktails);

        return (await query.ToListAsync()).Select(x => (Mapper as CocktailMapper)!.MapperWithCounters(x))!;
    }

    /// <summary>
    /// Method Gets Cocktail By Given ID With Collection Fulled With Data Asynchronously.
    /// </summary>
    /// <param name="id">Defines Cocktail ID To Search For Cocktail.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.Cocktail?> FirstOrDefaultDetailedAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.IngredientInCocktails)
            .Include(x => x.DrinkInCocktails)
            .Include(x => x.Steps)
            .Include(x => x.UserCocktails);
        
        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as CocktailMapper)!.MapperDetailed(result);
    }
}