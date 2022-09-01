using Base.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.Rating;


/// <summary>
/// Application Rating Create Implementation. Defines Specific Entity Rows for Rating. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class RatingCreate : DomainEntityId
{
    
    /// <summary>
    /// Defines Rating Grade Value Entity Row.
    /// </summary>
    [Required(ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="GradeValueRequired")]
    [MinLength(1, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MinLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(GradeValue))]
    public string? GradeValue { get; set; }
        
    /// <summary>
    /// Defines Rating Description Value Entity Row.
    /// </summary>
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(Description))]
    public string? Description { get; set; }
    
}