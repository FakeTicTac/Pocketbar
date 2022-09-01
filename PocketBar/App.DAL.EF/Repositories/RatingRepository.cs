using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Rating Data Access Layer Repository Design Implementation.  
/// </summary>
public class RatingRepository : BaseEntityRepository<DalAppDTO.Rating, DomainApp.Rating, DomainApp.Identity.AppUser, AppDbContext>, 
    IRatingRepository
{
    
    /// <summary>
    /// Data Access Layer Rating Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RatingRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new RatingMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All Ratings With Counters Of Usage Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.Rating>> GetAllWithUsageCountAsync(bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.UserCocktails);

        return (await query.ToListAsync()).Select(x => (Mapper as RatingMapper)!.MapperWithCounter(x))!;
    }

    /// <summary>
    /// Method Gets Rating By Given ID With Counters Of Usage Asynchronously.
    /// </summary>
    /// <param name="id">Defines Rating ID To Search For ARating.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.Rating?> FirstOrDefaultWithUsageCountAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.UserCocktails);
        
        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as RatingMapper)!.MapperWithCounter(result);
    }
}