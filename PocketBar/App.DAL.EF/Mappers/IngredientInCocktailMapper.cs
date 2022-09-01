using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Ingredient In Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class IngredientInCocktailMapper : BaseMapper<DalAppDTO.IngredientInCocktail, DomainApp.IngredientInCocktail>
{
    
    /// <summary>
    /// Basic Ingredient In Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientInCocktailMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer Ingredient In Cocktail Object Into Data Access Layer Object With Detailed Info.
    /// </summary>
    /// <param name="ingredientInCocktail">Defines Database Layer Ingredient In Cocktail Object.</param>
    /// <returns>Data Access Layer Ingredient In Cocktail Object.</returns>
    public DalAppDTO.IngredientInCocktail? MapperDetailed(DomainApp.IngredientInCocktail ingredientInCocktail)
    {
        var baseMapped = base.Map(ingredientInCocktail);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.CocktailName = ingredientInCocktail.Cocktail!.Name;
        baseMapped.IngredientName = ingredientInCocktail.Ingredient!.Name;
        baseMapped.AmountUnitName = ingredientInCocktail.AmountUnit!.Name;
        
        return baseMapped;
    }
}