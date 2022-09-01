using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Drink Data Access Layer Repository Design Implementation.  
/// </summary>
public class DrinkRepository : BaseEntityRepository<DalAppDTO.Drink, DomainApp.Drink, DomainApp.Identity.AppUser, AppDbContext>, 
    IDrinkRepository
{
    
    /// <summary>
    /// Data Access Layer Drink Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new DrinkMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All Drinks With Counters Of Drink In Cocktails and Drink Type Name Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.Drink>> GetAllWithDrinkTypeAndCocktailsCountAsync(bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.DrinkType)
            .Include(x => x.DrinkInCocktails);

        return (await query.ToListAsync()).Select(x => (Mapper as DrinkMapper)!.MapperWithDrinkTypeAndCocktailsCount(x))!;
    }

    /// <summary>
    /// Method Gets Drink By Given ID With Counters Of Drink In Cocktails and Drink Type Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines Drink ID To Search For Drink.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.Drink?> FirstOrDefaultWithDrinkTypeAndCocktailsCountAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.DrinkType)
            .Include(x => x.DrinkInCocktails);
        
        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as DrinkMapper)!.MapperWithDrinkTypeAndCocktailsCount(result);
    }
}