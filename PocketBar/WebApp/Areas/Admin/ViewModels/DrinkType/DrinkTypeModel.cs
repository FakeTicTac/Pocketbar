using Base.Domain;
using Base.Domain.Translation;


// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global


namespace WebApp.Areas.Admin.ViewModels.DrinkType;


/// <summary>
/// Application Drink Type Implementation. Defines Specific Entity Rows for Drink Type. 
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global 
public class DrinkTypeModel : DomainEntityId
{
    
    /// <summary>
    /// Defines Drink Type Name Value Entity Row.
    /// </summary>
    public LanguageString Name { get; set; } = new();
    
    /// <summary>
    /// Defines Drink Type Description Value Entity Row.
    /// </summary>
    public LanguageString Description { get; set; } = new();
    
    /// <summary>
    /// Defines All Drink Type Related Drinks Count.
    /// </summary>
    public int DrinksCount { get; set; }

}