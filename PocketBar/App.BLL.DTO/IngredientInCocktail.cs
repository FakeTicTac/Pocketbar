using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Ingredient In Cocktail Implementation. Defines Specific Entity Rows for Ingredient In Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class IngredientInCocktail : DomainEntityId
{
    
    /// <summary>
    /// Defines Ingredient In Cocktail Amount Value Entity Row.
    /// </summary>
    public float Amount { get; set; }
    
    /// <summary>
    /// Defines Ingredient In Cocktail Detailed Info Field - Cocktail Name Value Entity Row.
    /// </summary>
    public LanguageString CocktailName { get; set; } = new();
    
    /// <summary>
    /// Defines Ingredient In Cocktail Detailed Info Field - Amount Unit Name Value Entity Row.
    /// </summary>
    public LanguageString AmountUnitName { get; set; } = new();
    
    /// <summary>
    /// Defines Ingredient In Cocktail Detailed Info Field - Ingredient Name Value Entity Row.
    /// </summary>
    public LanguageString IngredientName { get; set; } = new();
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Cocktail ID.
    /// </summary>
    public Guid CocktailId { get; set; }

    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Amount Unit ID.
    /// </summary>
    public Guid AmountUnitId { get; set; }

    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Ingredient ID.
    /// </summary>
    public Guid IngredientId { get; set; }

}