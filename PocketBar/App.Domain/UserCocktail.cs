using Base.Domain;
using App.Domain.Identity;
using Base.Contracts.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application User Cocktail Implementation. Defines Specific Entity Rows for User Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class UserCocktail : DomainEntityUser<AppUser>, IDomainEntityId
{
    
    /// <summary>
    /// Defines User Cocktail Comment Value Entity Row.
    /// </summary>
    [MaxLength(255)] 
    public string? Comment { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines User Cocktail Belonging To The Cocktail ID.
    /// </summary>
    public Guid CocktailId { get; set; }
    
    /// <summary>
    /// Defines User Cocktail Belonging To The Cocktail.
    /// </summary>
    public Cocktail? Cocktail { get; set; }

    /// <summary>
    /// Defines User Cocktail Belonging To The Rating ID.
    /// </summary>
    public Guid RatingId { get; set; }
    
    /// <summary>
    /// Defines User Cocktail Belonging To The Rating.
    /// </summary>
    public Rating? Rating { get; set; } 
    
}