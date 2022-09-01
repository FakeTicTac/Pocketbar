using Base.Domain;
using System.ComponentModel.DataAnnotations;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application User Cocktail Implementation. Defines Specific Entity Rows for User Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class UserCocktail : DomainEntityId
{
    
    /// <summary>
    /// Defines User Cocktail Comment Value Entity Row.
    /// </summary>
    [MaxLength(255)] 
    public string? Comment { get; set; }

    /// <summary>
    /// Defines User Cocktail Detailed Info Field - Cocktail Name Value Entity Row.
    /// </summary>
    public LanguageString CocktailName { get; set; } = new();
    
    /// <summary>
    /// Defines User Cocktail Detailed Info Field - Rating Value Entity Row.
    /// </summary>
    public string? RatingValue { get; set; } 
    
    /// <summary>
    /// Defines Drink Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? CoverImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines User Cocktail Belonging To The User ID.
    /// </summary>
    public Guid? AppUserId { get; set; }
    
    /// <summary>
    /// Defines User Cocktail Belonging To The Cocktail ID.
    /// </summary>
    public Guid CocktailId { get; set; }
    
    /// <summary>
    /// Defines User Cocktail Belonging To The Rating ID.
    /// </summary>
    public Guid RatingId { get; set; }
    
}