using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Authorized.ViewModels.Cocktail;


/// <summary>
/// Application Cocktail Implementation. Defines Specific Entity Rows for Amount Unit. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class CocktailModel : DomainEntityId
{
    
    /// <summary>
    /// Defines Cocktail Name Value Entity Row.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Defines Cocktail Description Value Entity Row.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Defines Cocktail Alcohol Containing. 
    /// </summary>
    public bool IsAlcoholic { get; set; }
    
    /// <summary>
    /// Defines Cocktail Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    public string? CoverImagePath { get; set; }
    
}