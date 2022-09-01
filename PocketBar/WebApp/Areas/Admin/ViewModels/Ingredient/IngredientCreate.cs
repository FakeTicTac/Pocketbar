using Base.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.Ingredient;


/// <summary>
/// Application Ingredient Create Implementation. Defines Specific Entity Rows for Ingredient. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class IngredientCreate : DomainEntityId
{
    
    /// <summary>
    /// Defines Ingredient Name Value Entity Row.
    /// </summary>
    [Required(ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="NameRequired")]
    [MinLength(3, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MinLen")]
    [MaxLength(30, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MaxLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(Name))]
    public string? Name { get; set; }
    
    /// <summary>
    /// Defines Ingredient Description Value Entity Row.
    /// </summary>
    [Required(ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="DescriptionRequired")]
    [MinLength(10, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MinLen")]
    [MaxLength(256, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MaxLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(Description))]
    public string? Description { get; set; }
    
    /// <summary>
    /// Defines Ingredient Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MaxLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(CoverImagePath))]
    public string? CoverImagePath { get; set; }
    
}