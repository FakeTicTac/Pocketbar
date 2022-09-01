using Base.Domain;
using WebApp.Areas.Admin.ViewModels.Errors;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.AmountUnit;


/// <summary>
/// Application Index View Model Implementation. Defines Specific Entity Rows for Amount Unit. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class AmountUnitIndex : DomainEntityId
{
    
    /// <summary>
    /// Defines Amount Units To Display.
    /// </summary>
    public List<AmountUnitModel> AmountUnitModels { get; set; } = new();
    
    /// <summary>
    /// Defines Error Occured During Backend Communication.
    /// </summary>
    public ErrorMarker? Error { get; set; }
    
}