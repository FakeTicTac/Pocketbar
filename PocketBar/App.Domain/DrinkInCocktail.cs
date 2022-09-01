using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Drink In Cocktail Implementation. Defines Specific Entity Rows for Drink In Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class DrinkInCocktail : DomainEntityMetaId
{
    
    /// <summary>
    /// Defines Drink In Cocktail Amount Value Entity Row.
    /// </summary>
    public float Amount { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Drink In Cocktail Belonging To The Cocktail ID.
    /// </summary>
    public Guid CocktailId { get; set; }
    
    /// <summary>
    /// Defines Drink In Cocktail Belonging To The Cocktail.
    /// </summary>
    public Cocktail? Cocktail { get; set; } 

    /// <summary>
    /// Defines Drink In Cocktail Belonging To The Amount Unit ID.
    /// </summary>
    public Guid AmountUnitId { get; set; }
    
    /// <summary>
    /// Defines Drink In Cocktail Belonging To The Amount Unit.
    /// </summary>
    public AmountUnit? AmountUnit { get; set; }
    
    /// <summary>
    /// Defines IDrink In Cocktail Belonging To The Drink ID.
    /// </summary>
    public Guid DrinkId{ get; set; }
    
    /// <summary>
    /// Defines IDrink In Cocktail Belonging To The Drink.
    /// </summary>
    public Drink? Drink { get; set; }
    
}