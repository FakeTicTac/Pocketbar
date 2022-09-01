using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Ingredient Implementation. Defines Specific Entity Rows for Ingredient.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Ingredient : DomainEntityId
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
    [MaxLength(2048)]
    public string? CoverImagePath { get; set; }
    
    /// <summary>
    /// Defines All Ingredients Related Ingredient In Cocktails Count.
    /// </summary>
    public int IngredientInCocktailsCount { get; set; }
    
}