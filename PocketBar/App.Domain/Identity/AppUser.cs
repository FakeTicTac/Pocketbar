using Base.Domain.Identity;
using System.ComponentModel.DataAnnotations;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain.Identity;


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
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To User User Cocktails.
    /// </summary>
    public ICollection<UserCocktail>? UserCocktails { get; set; }
    
    /// <summary>
    /// Defines All Users' Refresh Tokens.
    /// </summary>
    public ICollection<RefreshToken>? RefreshTokens { get; set; }
}