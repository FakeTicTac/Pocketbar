using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.DAL.DTO;


/// <summary>
/// Application Drink Implementation. Defines Specific Entity Rows for Drink.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Drink : DomainEntityId
{
    
    /// <summary>
    /// Defines Drink Name Value Entity Row.
    /// </summary>
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Drink Description Value Entity Row.
    /// </summary>
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines Drink Alcohol By Volume Value Entity Row.
    /// </summary>
    public float AlcoholByVolume { get; set; }
    
    /// <summary>
    /// Defines Drink Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? CoverImagePath { get; set; }

    /// <summary>
    /// Defines Drink Detailed Info Field - Drink Type Name Value Entity Row.
    /// </summary>
    public LanguageString DrinkTypeName { get; set; } = new();
    
    /// <summary>
    /// Defines All Drink Related Drink In Cocktails Count.
    /// </summary>
    public int DrinkInCocktailsCount { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Drink Belonging To The Drink Type ID.
    /// </summary>
    public Guid DrinkTypeId{ get; set; }
    
}