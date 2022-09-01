using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Step Data Access Layer Repository Design Implementation.  
/// </summary>
public class StepRepository : BaseEntityRepository<DalAppDTO.Step, DomainApp.Step, DomainApp.Identity.AppUser, AppDbContext>, 
    IStepRepository
{
    
    /// <summary>
    /// Data Access Layer Step Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public StepRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new StepMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets Step By Given ID With Cocktail Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines User Step ID To Search For Step.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.Step?> FirstOrDefaultWithCocktailNameAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.Cocktail);

        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as StepMapper)!.MapperDetailed(result);
    }
}