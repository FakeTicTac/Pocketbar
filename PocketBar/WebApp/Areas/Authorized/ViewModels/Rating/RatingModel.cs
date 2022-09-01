using Base.Domain;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Authorized.ViewModels.Rating;


/// <summary>
/// Application Rating Implementation. Defines Specific Entity Rows for Rating. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class RatingModel : DomainEntityId
{
    
    /// <summary>
    /// Defines Rating Name Value Entity Row.
    /// </summary>
    public string? GradeValue { get; set; }
    
    /// <summary>
    /// Defines Rating Description Value Entity Row.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Defines Display Value Combined From Grade And Description.
    /// </summary>
    public string? DisplayValue { get; set; }
}