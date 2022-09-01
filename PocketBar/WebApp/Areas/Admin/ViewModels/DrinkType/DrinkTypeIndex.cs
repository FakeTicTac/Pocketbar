using Base.Domain;
using WebApp.Areas.Admin.ViewModels.Errors;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.DrinkType;


/// <summary>
/// Application Index View Model Implementation. Defines Specific Entity Rows for Drink Type. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class DrinkTypeIndex : DomainEntityId
{
    
    /// <summary>
    /// Defines Drink Types To Display.
    /// </summary>
    public List<DrinkTypeModel> DrinkTypeModels { get; set; } = new();
    
    /// <summary>
    /// Defines Error Occured During Backend Communication.
    /// </summary>
    public ErrorMarker? Error { get; set; }
    
}