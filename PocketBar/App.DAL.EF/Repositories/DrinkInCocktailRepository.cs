using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Drink In Cocktail Data Access Layer Repository Design Implementation.  
/// </summary>
public class DrinkInCocktailRepository : BaseEntityRepository<DalAppDTO.DrinkInCocktail, DomainApp.DrinkInCocktail, DomainApp.Identity.AppUser, AppDbContext>, 
    IDrinkInCocktailRepository
{
    
    /// <summary>
    /// Data Access Layer Drink In Cocktail Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkInCocktailRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new DrinkInCocktailMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets Drink In Cocktail By Given ID With Amount Unit, Cocktail and Drink Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines Drink In Cocktail ID To Search For Drink In Cocktail.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.DrinkInCocktail?> FirstOrDefaultDetailedAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.Cocktail)
            .Include(x => x.Drink)
            .Include(x => x.AmountUnit);
        
        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as DrinkInCocktailMapper)!.MapperDetailed(result);
    }
}