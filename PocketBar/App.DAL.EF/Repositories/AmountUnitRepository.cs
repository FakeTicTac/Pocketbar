using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Amount Unit Data Access Layer Repository Design Implementation.  
/// </summary>
public class AmountUnitRepository : BaseEntityRepository<DalAppDTO.AmountUnit, DomainApp.AmountUnit, DomainApp.Identity.AppUser, AppDbContext>, 
    IAmountUnitRepository
{
    
    /// <summary>
    /// Data Access Layer Amount Unit Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AmountUnitRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new AmountUnitMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All Amount Units With Counters Of Drink And Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.AmountUnit>> GetAllWithUsageCountsAsync(bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.IngredientInCocktails)
            .Include(x => x.DrinkInCocktails);
        
        return (await query.ToListAsync()).Select(x => (Mapper as AmountUnitMapper)!.MapperWithCounter(x))!;
    }

    /// <summary>
    /// Method Gets Amount Unit By Given ID With Counters Of Drink And Ingredient In Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines Amount Unit ID To Search For Amount Unit.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.AmountUnit?> FirstOrDefaultWithUsageCountsAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.IngredientInCocktails)
            .Include(x => x.DrinkInCocktails);

        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as AmountUnitMapper)!.MapperWithCounter(result);
    }
}