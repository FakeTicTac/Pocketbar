using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Ingredient Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class IngredientMapper : BaseMapper<DalAppDTO.Ingredient, DomainApp.Ingredient>
{
    
    /// <summary>
    /// Basic Ingredient Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer Ingredient Object Into Data Access Layer Object With Collection Counters.
    /// </summary>
    /// <param name="ingredient">Defines Database Layer Ingredient Object.</param>
    /// <returns>Data Access Layer Ingredient Object.</returns>
    public DalAppDTO.Ingredient? MapperWithCounter(DomainApp.Ingredient ingredient)
    {
        var baseMapped = base.Map(ingredient);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.IngredientInCocktailsCount = ingredient.IngredientInCocktails!.Count;

        return baseMapped;
    }
}