using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Cocktail Implementation. Defines Specific Entity Rows for Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Cocktail : DomainEntityMetaId
{
    
    /// <summary>
    /// Defines Cocktail Name Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Cocktail Description Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines Cocktail Alcohol Containing. 
    /// </summary>
    public bool IsAlcoholic { get; set; }
    
    /// <summary>
    /// Defines Cocktail Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? CoverImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To Cocktail User Cocktails.
    /// </summary>
    public ICollection<UserCocktail>? UserCocktails { get; set; }

    /// <summary>
    /// Defines All Related To Cocktail Drink In Cocktails.
    /// </summary>
    public ICollection<DrinkInCocktail>? DrinkInCocktails { get; set; }

    /// <summary>
    /// Defines All Related To Cocktail Ingredient In Cocktails.
    /// </summary>
    public ICollection<IngredientInCocktail>? IngredientInCocktails { get; set; }

    /// <summary>
    /// Defines All Related To Cocktail Steps.
    /// </summary>
    public ICollection<Step>? Steps { get; set; }
    
}