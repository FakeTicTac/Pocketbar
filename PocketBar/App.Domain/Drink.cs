using Base.Domain;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace App.Domain;


/// <summary>
/// Application Drink Implementation. Defines Specific Entity Rows for Drink.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class Drink : DomainEntityMetaId
{
    
    /// <summary>
    /// Defines Drink Name Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Drink Description Value Entity Row.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines Drink Alcohol By Volume Value Entity Row.
    /// </summary>
    public float AlcoholByVolume { get; set; }
    
    /// <summary>
    /// Defines Drink Cover Image For Chat on The Server Side Entity Row.
    /// </summary>
    [MaxLength(2048)]
    public string? CoverImagePath { get; set; }
    
    
    // EF CORE Related Relations Are Going Next -->
    
    
    /// <summary>
    /// Defines Drink Belonging To The Drink Type ID.
    /// </summary>
    public Guid DrinkTypeId{ get; set; }
    
    /// <summary>
    /// Defines Drink Belonging To The Drink Type.
    /// </summary>
    public DrinkType? DrinkType { get; set; }
    
    /// <summary>
    /// Defines All Related To Drink Drink in Cocktails.
    /// </summary>
    public ICollection<DrinkInCocktail>? DrinkInCocktails { get; set; }
    
}