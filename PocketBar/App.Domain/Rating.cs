using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Rating Implementation. Defines Specific Entity Rows for Rating.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Rating : DomainEntityMetaId
{   
    
    /// <summary>
    /// Defines Rating Grade Value Entity Row.
    /// </summary>
    public string? GradeValue { get; set; }
        
    /// <summary>
    /// Defines Rating Description Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Description { get; set; } = new();
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To Rating User Cocktails.
    /// </summary>
    public ICollection<UserCocktail>? UserCocktails { get; set; }

}