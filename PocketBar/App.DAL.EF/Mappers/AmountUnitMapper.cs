using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Amount Unit Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class AmountUnitMapper : BaseMapper<DalAppDTO.AmountUnit, DomainApp.AmountUnit>
{
    
    /// <summary>
    /// Basic Amount Unit Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AmountUnitMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer Amount Unit Object Into Data Access Layer Object With Collection Counter.
    /// </summary>
    /// <param name="amountUnit">Defines Database Layer Amount Unit Object.</param>
    /// <returns>Data Access Layer User Object.</returns>
    public DalAppDTO.AmountUnit? MapperWithCounter(DomainApp.AmountUnit amountUnit)
    {
        var baseMapped = base.Map(amountUnit);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.UsageWithDrinksCount = amountUnit.DrinkInCocktails!.Count;
        baseMapped.UsageWithIngredientsCount = amountUnit.IngredientInCocktails!.Count;

        return baseMapped;
    }
}