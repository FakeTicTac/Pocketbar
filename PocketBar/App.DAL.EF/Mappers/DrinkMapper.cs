using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Drink Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkMapper : BaseMapper<DalAppDTO.Drink, DomainApp.Drink>
{
    
    /// <summary>
    /// Basic Drink Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer Drink Object Into Data Access Layer Object With Collection Counters.
    /// </summary>
    /// <param name="drink">Defines Database Layer Drink Object.</param>
    /// <returns>Data Access Layer Drink Object.</returns>
    public DalAppDTO.Drink? MapperWithDrinkTypeAndCocktailsCount(DomainApp.Drink drink)
    {
        var baseMapped = base.Map(drink);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.DrinkTypeName = drink.DrinkType!.Name;
        baseMapped.DrinkInCocktailsCount = drink.DrinkInCocktails!.Count;

        return baseMapped;
    }
}