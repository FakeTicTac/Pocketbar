using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Amount Unit Implementation. Defines Specific Entity Rows for Amount Unit.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class AmountUnit : DomainEntityMetaId
{
    
    /// <summary>
    /// Defines Amount Unit Name Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Name { get; set; } = new();
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To Amount Unit Drink In Cocktails.
    /// </summary>
    public ICollection<DrinkInCocktail>? DrinkInCocktails { get; set; }

    /// <summary>
    /// Defines All Related To Amount Unit Ingredient In Cocktails.
    /// </summary>
    public ICollection<IngredientInCocktail>? IngredientInCocktails { get; set; }

}