using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Drink Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkTypeMapper : BaseMapper<DalAppDTO.DrinkType, DomainApp.DrinkType>
{
    
    /// <summary>
    /// Basic Drink Type Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkTypeMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer Drink Type Object Into Data Access Layer Object With Collection Counters.
    /// </summary>
    /// <param name="drinkType">Defines Database Layer Drink Type Object.</param>
    /// <returns>Data Access Layer  Drink Type Object.</returns>
    public DalAppDTO.DrinkType? MapperWithCounter(DomainApp.DrinkType drinkType)
    {
        var baseMapped = base.Map(drinkType);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.DrinksCount = drinkType.Drinks!.Count;

        return baseMapped;
    }
}