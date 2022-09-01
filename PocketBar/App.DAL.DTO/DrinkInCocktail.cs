using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.DAL.DTO;


/// <summary>
/// Application Drink In Cocktail Implementation. Defines Specific Entity Rows for Drink In Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class DrinkInCocktail : DomainEntityId
{
    
    /// <summary>
    /// Defines Drink In Cocktail Amount Value Entity Row.
    /// </summary>
    public float Amount { get; set; }

    /// <summary>
    /// Defines Drink In Cocktail Detailed Info Field - Drink Name Value Entity Row.
    /// </summary>
    public LanguageString DrinkName { get; set; } = new();

    /// <summary>
    /// Defines Drink In Cocktail Detailed Info Field - Amount Unit Name Value Entity Row.
    /// </summary>
    public LanguageString? AmountUnitName { get; set; } = new();

    /// <summary>
    /// Defines Drink In Cocktail Detailed Info Field - Cocktail Name Value Entity Row.
    /// </summary>
    public LanguageString CocktailName { get; set; } = new();
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Drink In Cocktail Belonging To The Cocktail ID.
    /// </summary>
    public Guid CocktailId { get; set; }
    
    /// <summary>
    /// Defines Drink In Cocktail Belonging To The Amount Unit ID.
    /// </summary>
    public Guid AmountUnitId { get; set; }
    
    /// <summary>
    /// Defines IDrink In Cocktail Belonging To The Drink ID.
    /// </summary>
    public Guid DrinkId{ get; set; }
    
}