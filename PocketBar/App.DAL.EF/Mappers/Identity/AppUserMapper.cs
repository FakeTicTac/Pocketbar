using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain.Identity;
using DalAppDTO = App.DAL.DTO.Identity;


namespace App.DAL.EF.Mappers.Identity;


/// <summary>
/// App User Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class AppUserMapper : BaseMapper<DalAppDTO.AppUser, DomainApp.AppUser>
{
    
    /// <summary>
    /// Basic App User Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppUserMapper(IMapper mapper) : base(mapper) { }


    /// <summary>
    /// Method Maps Database Layer User Object Into Data Access Layer Object With Rated Cocktails Counter.
    /// </summary>
    /// <param name="appUser">Defines Database Layer User Object.</param>
    /// <returns>Data Access Layer User Object.</returns>
    public DalAppDTO.AppUser? MapperWithCounter(DomainApp.AppUser appUser)
    {
        var baseMapped = base.Map(appUser);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.CocktailsCount = appUser.UserCocktails!.Count;

        return baseMapped;
    }
}