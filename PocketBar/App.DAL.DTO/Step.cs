using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.DAL.DTO;


/// <summary>
/// Application Step Implementation. Defines Specific Entity Rows for Step.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Step : DomainEntityId
{
    
    /// <summary>
    /// Defines Step Description (What To Do) Value Entity Row.
    /// </summary>
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines Step Index Number (In What Order To Fulfill) Value Entity Row.
    /// </summary>
    public int IndexNumber { get; set; }

    /// <summary>
    /// Defines Step Detailed Info Field - Cocktail Name Value Entity Row.
    /// </summary>
    public LanguageString CocktailName { get; set; } = new();
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Step Belonging To The Cocktail ID.
    /// </summary>
    public Guid CocktailId { get; set; }
    
}