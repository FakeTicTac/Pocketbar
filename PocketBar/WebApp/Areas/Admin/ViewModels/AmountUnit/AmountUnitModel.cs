using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.AmountUnit;


/// <summary>
/// Application Amount Unit Implementation. Defines Specific Entity Rows for Amount Unit. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class AmountUnitModel : DomainEntityId
{
    
    /// <summary>
    /// Defines Amount Unit Name Value Entity Row.
    /// </summary>
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines All Amount Unit Usages With Drinks Count.
    /// </summary>
    public int UsageWithDrinksCount { get; set; }

    /// <summary>
    /// Defines All Amount Unit Usages With Ingredients Count.
    /// </summary>
    public int UsageWithIngredientsCount { get; set; }
    
}