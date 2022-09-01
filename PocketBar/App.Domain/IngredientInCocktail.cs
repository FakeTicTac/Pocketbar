using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Ingredient In Cocktail Implementation. Defines Specific Entity Rows for Ingredient In Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class IngredientInCocktail : DomainEntityMetaId
{
    
    /// <summary>
    /// Defines Ingredient In Cocktail Amount Value Entity Row.
    /// </summary>
    public float Amount { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Cocktail ID.
    /// </summary>
    public Guid CocktailId { get; set; }
    
    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Cocktail.
    /// </summary>
    public Cocktail? Cocktail { get; set; } 

    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Amount Unit ID.
    /// </summary>
    public Guid AmountUnitId { get; set; }
    
    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Amount Unit.
    /// </summary>
    public AmountUnit? AmountUnit { get; set; }
    
    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Ingredient ID.
    /// </summary>
    public Guid IngredientId { get; set; }
    
    /// <summary>
    /// Defines Ingredient In Cocktail Belonging To The Ingredient.
    /// </summary>
    public Ingredient? Ingredient { get; set; }
    
}