using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Refresh Token Data Access Layer Repository Design Implementation.  
/// </summary>
public class UserCocktailRepository : BaseEntityRepository<DalAppDTO.UserCocktail, DomainApp.UserCocktail, DomainApp.Identity.AppUser, AppDbContext>, 
    IUserCocktailRepository
{
    
    /// <summary>
    /// Data Access Layer Refresh Token Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserCocktailRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new UserCocktailMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets All User Cocktails With Rating Value And Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="userId">Defines User ID To Search For User Cocktails.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<IEnumerable<DalAppDTO.UserCocktail>> GetAllDetailedAsync(Guid userId = default, bool noTracking = true)
    {
        var query = CreateQuery(userId, noTracking)
            .Include(x => x.Cocktail)
            .Include(x => x.Rating);

        return (await query.ToListAsync()).Select(x => (Mapper as UserCocktailMapper)!.MapperDetailed(x))!;
    }
    
    /// <summary>
    /// Method Gets User Cocktail By Given ID With Rating Value And Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines User Cocktail ID To Search For User Cocktail.</param>
    /// <param name="userId">Defines User Id To Search For User Cocktail</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.UserCocktail?> FirstOrDefaultDetailedAsync(Guid id, Guid userId = default, bool noTracking = true)
    {
        var query = CreateQuery(userId, noTracking)
            .Include(x => x.Cocktail)
            .Include(x => x.Rating);
        
        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as UserCocktailMapper)!.MapperDetailed(result);
    }
}