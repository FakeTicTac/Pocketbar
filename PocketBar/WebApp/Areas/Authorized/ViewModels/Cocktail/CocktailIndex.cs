using WebApp.Areas.Authorized.ViewModels.Errors;


// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Authorized.ViewModels.Cocktail;


/// <summary>
/// Application Cocktail View Model Index Implementation. Defines Specific Entity Rows for Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class CocktailIndex 
{
    
    /// <summary>
    /// Defines Cocktail All Loaded Cocktails.
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public List<CocktailModel>? Cocktails { get; set; }

    /// <summary>
    /// Defines Error Values If Occured During Any Operation.
    /// </summary>
    public ErrorMarker? Error { get; set; }

}