using Base.Domain.Identity;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.BLL.DTO.Identity;


/// <summary>
/// Application Identity User Implementation. Defines Specific Entity Rows for Identity User. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class AppUser : BaseUser
{

    /// <summary>
    /// Defines User First Name Entity Row. 
    /// </summary>
    [MaxLength(50)]
    public string? FirstName { get; set; }

    /// <summary>
    /// Defines User Last Name Entity Row. 
    /// </summary>
    [MaxLength(50)]
    public string? LastName { get; set; }
    
    /// <summary>
    /// Defines All Users Cocktails Count. (Rated And Commented)
    /// </summary>
    public int CocktailsCount { get; set; }
    
}