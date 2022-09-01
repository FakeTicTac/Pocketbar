using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.Drink;


/// <summary>
/// Application Drink Implementation. Defines Specific Entity Rows for Drink. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class DrinkModel : DomainEntityId
{
    
    /// <summary>
    /// Defines Drink Value Entity Row.
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
    public string? CoverImagePath { get; set; }
    
    /// <summary>
    /// Defines Drink Detailed Info Field - Drink Type Name Value Entity Row.
    /// </summary>
    public LanguageString DrinkTypeName { get; set; } = new();
    
    /// <summary>
    /// Defines All Drink Related Drink In Cocktails Count.
    /// </summary>
    public int DrinkInCocktailsCount { get; set; }

}