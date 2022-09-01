using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Ingredient Implementation. Defines Specific Entity Rows for Ingredient.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Ingredient : DomainEntityMetaId
{
    
    /// <summary>
    /// Defines Ingredient Name Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Ingredient Description Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines Ingredient Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? CoverImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To Ingredient Ingredient In Cocktails.
    /// </summary>
    public ICollection<IngredientInCocktail>? IngredientInCocktails { get; set; }

}