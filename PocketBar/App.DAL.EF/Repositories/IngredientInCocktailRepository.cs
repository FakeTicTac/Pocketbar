using AutoMapper;
using App.DAL.EF.Mappers;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Contracts.DAL.Repositories;


using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Repositories;


/// <summary>
/// Ingredient In Cocktail Data Access Layer Repository Design Implementation.  
/// </summary>
public class IngredientInCocktailRepository : BaseEntityRepository<DalAppDTO.IngredientInCocktail, DomainApp.IngredientInCocktail, DomainApp.Identity.AppUser, AppDbContext>, 
    IIngredientInCocktailRepository
{
    
    /// <summary>
    /// Data Access Layer Ingredient In Cocktail Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientInCocktailRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new IngredientInCocktailMapper(mapper)) { }

    
    /// <summary>
    /// Method Gets Ingredient In Cocktail By Given ID With Ingredient, Cocktail and Amount Name Asynchronously.
    /// </summary>
    /// <param name="id">Defines Ingredient In Cocktail ID To Search For Ingredient In Cocktail.</param>
    /// <param name="noTracking">Defines Tracking Options.</param>
    /// <returns>Asynchronous Operation That Returns The Value of Enumerable of Entities.</returns>
    public async Task<DalAppDTO.IngredientInCocktail?> FirstOrDefaultDetailedAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(noTracking)
            .Include(x => x.Cocktail)
            .Include(x => x.Ingredient)
            .Include(x => x.AmountUnit);
        
        var result = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        // Check If Result Exist In Database.
        return result == null ? null : (Mapper as IngredientInCocktailMapper)!.MapperDetailed(result);
    }
}