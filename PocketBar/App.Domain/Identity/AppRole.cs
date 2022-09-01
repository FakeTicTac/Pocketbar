using Base.Domain.Identity;
using Base.Domain.Translation;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.Domain.Identity;


/// <summary>
/// Application Identity Role Implementation. Defines Specific Entity Rows for Identity Role.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class AppRole : BaseRole
{
    
    /// <summary>
    /// Defines Application Role Display Name. 
    /// </summary>
    [Column(TypeName = "jsonb")]
    // ReSharper disable once CollectionNeverUpdated.Global
    public LanguageString DisplayName { get; set; } = new();
    
}