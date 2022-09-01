using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Drink Type Data Access Layer Repository Design Implementation.  
/// </summary>
public class DrinkTypeRepository : BaseEntityRepository<DalAppDTO.DrinkType, DomainApp.DrinkType, DomainApp.Identity.AppUser, AppDbContext>, 
    IDrinkTypeRepository
{
    
    /// <summary>
    /// Data Access Layer Drink TypeRepository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkTypeRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new DrinkTypeMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All Drink Types With Counters Of Drinks Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.DrinkType>> GetAllWithDrinksCountAsync(bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.Drinks);

        return (await query.ToListAsync()).Select(x => (Mapper as DrinkTypeMapper)!.MapperWithCounter(x))!;
    }

    /// <summary>
    /// Method Gets Drink Type By Given ID With Counters Of Drinks Asynchronously.
    /// </summary>
    /// <param name="id">Defines Drink Type ID To Search For Drink Type.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.DrinkType?> FirstOrDefaultWithDrinksCountAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.Drinks);
        
        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as DrinkTypeMapper)!.MapperWithCounter(result);
    }
}