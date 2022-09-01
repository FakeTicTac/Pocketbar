using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local


namespace App.DAL.EF.Mappers;


/// <summary>
/// Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class CocktailMapper : BaseMapper<DalAppDTO.Cocktail, DomainApp.Cocktail>
{
    
    /// <summary>
    /// Defines Drink In Cocktail Mapper Connection.
    /// </summary>
    private DrinkInCocktailMapper DrinkInCocktailMapper { get; set; }
    
    /// <summary>
    /// Defines Ingredient In Cocktail Mapper Connection.
    /// </summary>
    private IngredientInCocktailMapper IngredientInCocktailMapper { get; set; }
    
    /// <summary>
    /// Defines Step Mapper Connection.
    /// </summary>
    private StepMapper StepMapper { get; set; }


    /// <summary>
    /// Basic Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CocktailMapper(IMapper mapper) : base(mapper)
    {
        DrinkInCocktailMapper = new DrinkInCocktailMapper(mapper);
        IngredientInCocktailMapper = new IngredientInCocktailMapper(mapper);
        StepMapper = new StepMapper(mapper);
    }
    
    
    /// <summary>
    /// Method Maps Database Layer Cocktail Object Into Data Access Layer Object With Detailed Info.
    /// </summary>
    /// <param name="cocktail">Defines Database Layer Cocktail Object.</param>
    /// <returns>Data Access Layer Cocktail Object.</returns>
    public DalAppDTO.Cocktail? MapperWithCounters(DomainApp.Cocktail cocktail)
    {
        var baseMapped = base.Map(cocktail);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.StepsCount = cocktail.Steps!.Count;
        baseMapped.UsersCount = cocktail.UserCocktails!.Count;
        baseMapped.DrinkInCocktailsCount = cocktail.DrinkInCocktails!.Count;
        baseMapped.IngredientInCocktailsCount = cocktail.IngredientInCocktails!.Count;
        
        return baseMapped;
    }
    
    
    /// <summary>
    /// Method Maps Database Layer Cocktail Object Into Data Access Layer Object With Detailed Info.
    /// </summary>
    /// <param name="cocktail">Defines Database Layer Cocktail Object.</param>
    /// <returns>Data Access Layer Cocktail Object.</returns>
    public DalAppDTO.Cocktail? MapperDetailed(DomainApp.Cocktail cocktail)
    {
        var baseMapped = base.Map(cocktail);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.DrinksInCocktails = cocktail.DrinkInCocktails!
            .Select(x => DrinkInCocktailMapper.Map(x)).ToList()!;
        baseMapped.IngredientInCocktails = cocktail.IngredientInCocktails!
            .Select(x => IngredientInCocktailMapper.Map(x)).ToList()!;
        baseMapped.Steps = cocktail.Steps!
            .Select(x => StepMapper.Map(x)).ToList()!;
        
        return baseMapped;
    }
}