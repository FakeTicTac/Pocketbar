using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace Api.DTO.v1;


/// <summary>
/// Application Rating Implementation. Defines Specific Entity Rows for Rating.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global  
public class Rating : DomainEntityId
{   
    
    /// <summary>
    /// Defines Rating Grade Value Entity Row.
    /// </summary>
    public string? GradeValue { get; set; }
        
    /// <summary>
    /// Defines Rating Description Value Entity Row.
    /// </summary>
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines All Rating Related Usage Counts.
    /// </summary>
    public int UsageCount { get; set; }
    
}