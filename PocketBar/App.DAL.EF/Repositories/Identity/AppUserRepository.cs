using AutoMapper;
using Base.DAL.EF.Repositories;
using App.DAL.EF.Mappers.Identity;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories.Identity;

using DomainApp = App.Domain.Identity;
using DalAppDTO = App.DAL.DTO.Identity;


namespace App.DAL.EF.Repositories.Identity;


/// <summary>
/// App User Data Access Layer Repository Design Implementation.  
/// </summary>
public class AppUserRepository : BaseEntityRepository<DalAppDTO.AppUser, DomainApp.AppUser, DomainApp.AppUser, AppDbContext>, 
    IAppUserRepository
{
    
    /// <summary>
    /// Data Access Layer App User Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppUserRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new AppUserMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All Users With Counter of Rated Cocktails Asynchronously.
    /// </summary>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.AppUser>> GetAllWithCocktailsCountAsync(bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.UserCocktails);

        return (await query.ToListAsync()).Select(x => (Mapper as AppUserMapper)!.MapperWithCounter(x))!;
    }

    /// <summary>
    /// Method Gets User By Given ID With Counter of Rated Cocktails Asynchronously.
    /// </summary>
    /// <param name="id">Defines User ID To Search For User.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.AppUser?> FirstOrDefaultWithCocktailsCountAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.UserCocktails);

        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as AppUserMapper)!.MapperWithCounter(result);
    }
}