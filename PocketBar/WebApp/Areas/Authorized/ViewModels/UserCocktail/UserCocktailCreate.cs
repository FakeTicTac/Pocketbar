using Base.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Authorized.ViewModels.UserCocktail;


/// <summary>
/// Application User Cocktail Create Implementation. Defines Specific Entity Rows for User Cocktail. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class UserCocktailCreate : DomainEntityId
{
    
    /// <summary>
    /// Defines User Cocktail Comment Value Entity Row.
    /// </summary>
    [MaxLength(256, ErrorMessageResourceType=typeof(Base.Resources.Common.Common), ErrorMessageResourceName="MaxLen")]
    [Display(ResourceType = typeof(Base.Resources.Common.Common), Name = nameof(Comment))]
    public string? Comment { get; set; }

    /// <summary>
    /// Defines Select List For Choosing Ratings
    /// </summary>
    public SelectList? Ratings { get; set; }
    

    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines User Cocktail Belonging To The Rating ID.
    /// </summary>
    [Required]
    public Guid RatingId{ get; set; }
    
    /// <summary>
    /// Defines User Cocktail Belonging To The Cocktail ID.
    /// </summary>
    [Required]
    public Guid CocktailId{ get; set; }
    
}