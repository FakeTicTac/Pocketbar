using Base.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.Drink;


/// <summary>
/// Application Drink Create Implementation. Defines Specific Entity Rows for Amount Unit. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class DrinkCreate : DomainEntityId
{
    
    /// <summary>
    /// Defines Amount Unit Name Value Entity Row.
    /// </summary>
    [Required(ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="NameRequired")]
    [MinLength(3, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MinLen")]
    [MaxLength(30, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MaxLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(Name))]
    public string? Name { get; set; }
    
    /// <summary>
    /// Defines Drink Description Value Entity Row.
    /// </summary>
    [Required(ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="DescriptionRequired")]
    [MinLength(10, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MinLen")]
    [MaxLength(256, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MaxLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(Description))]
    public string? Description { get; set; }
    
    /// <summary>
    /// Defines Drink Alcohol By Volume Value Entity Row.
    /// </summary>
    [Required(ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="AlcoholByVolumeRequired")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(AlcoholByVolume))]
    public float AlcoholByVolume { get; set; }
    
    /// <summary>
    /// Defines Drink Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MaxLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(CoverImagePath))]
    public string? CoverImagePath { get; set; }

    /// <summary>
    /// Defines Select List For Choosing DrinkType
    /// </summary>
    public SelectList? DrinkTypes { get; set; }
    

    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Drink Belonging To The Drink Type ID.
    /// </summary>
    [Required]
    public Guid DrinkTypeId{ get; set; }
    
}