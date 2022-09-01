using Base.Domain;
using WebApp.Areas.Admin.ViewModels.Errors;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.Ingredient;


/// <summary>
/// Application Index View Model Implementation. Defines Specific Entity Rows for Ingredient. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class IngredientIndex : DomainEntityId
{
    
    /// <summary>
    /// Defines Ingredients To Display.
    /// </summary>
    public List<IngredientModel> IngredientModels { get; set; } = new();
    
    /// <summary>
    /// Defines Error Occured During Backend Communication.
    /// </summary>
    public ErrorMarker? Error { get; set; }
    
}