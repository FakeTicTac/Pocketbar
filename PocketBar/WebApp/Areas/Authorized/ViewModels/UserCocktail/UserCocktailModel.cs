using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Authorized.ViewModels.UserCocktail;


/// <summary>
/// Application User Cocktail Implementation. Defines Specific Entity Rows for User Cocktail. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class UserCocktailModel : DomainEntityId
{
    
    /// <summary>
    /// Defines User Cocktail Comment Value Entity Row.
    /// </summary>
    public string? Comment { get; set; }
    
    /// <summary>
    /// Defines User Cocktail Detailed Info Field - Cocktail Name Value Entity Row.
    /// </summary>
    public string? CocktailName { get; set; }
    
    /// <summary>
    /// Defines User Cocktail Detailed Info Field - Rating Value Entity Row.
    /// </summary>
    public string? RatingValue { get; set; } 
    
    /// <summary>
    /// Defines Drink Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    public string? CoverImagePath { get; set; }
    
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