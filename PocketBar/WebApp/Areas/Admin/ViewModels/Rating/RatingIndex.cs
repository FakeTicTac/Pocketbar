using Base.Domain;
using WebApp.Areas.Admin.ViewModels.Errors;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.Rating;


/// <summary>
/// Application Index View Model Implementation. Defines Specific Entity Rows for Rating. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class RatingIndex : DomainEntityId
{
    
    /// <summary>
    /// Defines Ratings To Display.
    /// </summary>
    public List<RatingModel> RatingModels { get; set; } = new();
    
    /// <summary>
    /// Defines Error Occured During Backend Communication.
    /// </summary>
    public ErrorMarker? Error { get; set; }
    
}