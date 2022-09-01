using WebApp.Areas.Authorized.ViewModels.Errors;


// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Authorized.ViewModels.UserCocktail;


/// <summary>
/// Application User Cocktail View Model Index Implementation. Defines Specific Entity Rows for User Cocktail.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class UserCocktailIndex 
{
    
    /// <summary>
    /// Defines User Cocktail All Loaded UserCocktails.
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public List<UserCocktailModel>? UserCocktails { get; set; }

    /// <summary>
    /// Defines Error Values If Occured During Any Operation.
    /// </summary>
    public ErrorMarker? Error { get; set; }

}