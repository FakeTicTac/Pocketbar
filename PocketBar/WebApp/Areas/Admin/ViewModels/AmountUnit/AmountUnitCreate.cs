using System.ComponentModel;
using Base.Domain;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.AmountUnit;


/// <summary>
/// Application Amount Unit Create Implementation. Defines Specific Entity Rows for Amount Unit. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class AmountUnitCreate : DomainEntityId
{
    
    /// <summary>
    /// Defines Amount Unit Name Value Entity Row.
    /// </summary>
    [Required(ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="NameRequired")]
    [MinLength(1, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MinLen")]
    [MaxLength(30, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MaxLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(Name))]
    public string? Name { get; set; }
    
}