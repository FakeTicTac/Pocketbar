using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Drink In Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkInCocktailMapper : BaseMapper<DalAppDTO.DrinkInCocktail, DomainApp.DrinkInCocktail>
{
    
    /// <summary>
    /// Basic Drink In Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkInCocktailMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer Drink In Cocktail Object Into Data Access Layer Object With Detailed Info.
    /// </summary>
    /// <param name="drinkInCocktail">Defines Database Layer Drink In Cocktail Object.</param>
    /// <returns>Data Access Layer Drink In Cocktail Object.</returns>
    public DalAppDTO.DrinkInCocktail? MapperDetailed(DomainApp.DrinkInCocktail drinkInCocktail)
    {
        var baseMapped = base.Map(drinkInCocktail);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.CocktailName = drinkInCocktail.Cocktail!.Name;
        baseMapped.DrinkName = drinkInCocktail.Drink!.Name;
        baseMapped.AmountUnitName = drinkInCocktail.AmountUnit!.Name;
        
        return baseMapped;
    }
}