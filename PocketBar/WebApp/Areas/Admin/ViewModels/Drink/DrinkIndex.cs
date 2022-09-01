using Base.Domain;
using WebApp.Areas.Admin.ViewModels.Errors;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.Drink;


/// <summary>
/// Application Index View Model Implementation. Defines Specific Entity Rows for Drink. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class DrinkIndex : DomainEntityId
{
    
    /// <summary>
    /// Defines Drinks To Display.
    /// </summary>
    public List<DrinkModel> DrinkModels { get; set; } = new();
    
    /// <summary>
    /// Defines Error Occured During Backend Communication.
    /// </summary>
    public ErrorMarker? Error { get; set; }
    
}