using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// User Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class UserCocktailMapper : BaseMapper<DalAppDTO.UserCocktail, DomainApp.UserCocktail>
{
    
    /// <summary>
    /// Basic User Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserCocktailMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer User Cocktail Object Into Data Access Layer Object With Detailed Info.
    /// </summary>
    /// <param name="userCocktail">Defines Database Layer User Cocktail Object.</param>
    /// <returns>Data Access Layer User Cocktail Object.</returns>
    public DalAppDTO.UserCocktail? MapperDetailed(DomainApp.UserCocktail userCocktail)
    {
        var baseMapped = base.Map(userCocktail);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.CocktailName = userCocktail.Cocktail!.Name;
        baseMapped.RatingValue = userCocktail.Rating!.GradeValue;
        baseMapped.CoverImagePath = userCocktail.Cocktail!.CoverImagePath;

        return baseMapped;
    }
}