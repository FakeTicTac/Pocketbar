using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Drink Type Implementation. Defines Specific Entity Rows for Drink Type.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class DrinkType : DomainEntityMetaId
{
    
    /// <summary>
    /// Defines Drink Type Name Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Drink Type Description Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Description { get; set; } = new();
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines All Related To Drink Type Drinks.
    /// </summary>
    public ICollection<Drink>? Drinks { get; set; }
    
}