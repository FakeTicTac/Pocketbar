using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO;


/// <summary>
/// Application Cocktail Implementation. Defines Specific Entity Rows for Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Cocktail : DomainEntityId
{
    
    /// <summary>
    /// Defines Cocktail Name Value Entity Row.
    /// </summary>
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Cocktail Description Value Entity Row.
    /// </summary>
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
    
    /// <summary>
    /// Defines All Cocktail Related Users Count (Rated And Commented).
    /// </summary>
    public int UsersCount { get; set; }
        
    /// <summary>
    /// Defines All Cocktail Related Drink In Cocktails Count.
    /// </summary>
    public int DrinkInCocktailsCount { get; set; }

    /// <summary>
    /// Defines All Cocktail Related Ingredient In Cocktails Count.
    /// </summary>
    public int IngredientInCocktailsCount { get; set; }
    
    /// <summary>
    /// Defines All Cocktail Related Steps Count.
    /// </summary>
    public int StepsCount { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To Cocktail Drink In Cocktails.
    /// </summary>
    public ICollection<DrinkInCocktail>? DrinksInCocktails { get; set; }

    /// <summary>
    /// Defines All Related To Cocktail Ingredient In Cocktails.
    /// </summary>
    public ICollection<IngredientInCocktail>? IngredientInCocktails { get; set; }

    /// <summary>
    /// Defines All Related To Cocktail Steps.
    /// </summary>
    public ICollection<Step>? Steps { get; set; }
    
}