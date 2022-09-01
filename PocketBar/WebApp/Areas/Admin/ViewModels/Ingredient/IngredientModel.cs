using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.Ingredient;


/// <summary>
/// Application Ingredient Implementation. Defines Specific Entity Rows for Ingredient. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class IngredientModel : DomainEntityId
{
    
    /// <summary>
    /// Defines Ingredient Name Value Entity Row. 
    /// </summary>
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Ingredient Description Value Entity Row.
    /// </summary>
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines Ingredient Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    public string? CoverImagePath { get; set; }
    
    /// <summary>
    /// Defines All Ingredients Related Ingredient In Cocktails Count.
    /// </summary>
    public int IngredientInCocktailsCount { get; set; }

}