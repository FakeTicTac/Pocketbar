using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Step Implementation. Defines Specific Entity Rows for Step.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Step : DomainEntityMetaId
{
    
    /// <summary>
    /// Defines Step Description (What To Do) Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines Step Index Number (In What Order To Fulfill) Value Entity Row.
    /// </summary>
    public int IndexNumber { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Step Belonging To The Cocktail ID.
    /// </summary>
    public Guid CocktailId { get; set; }
    
    /// <summary>
    /// Defines Step Belonging To The Cocktail.
    /// </summary>
    public Cocktail? Cocktail { get; set; }
    
}