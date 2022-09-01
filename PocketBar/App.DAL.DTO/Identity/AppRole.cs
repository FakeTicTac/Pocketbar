﻿using Base.Domain.Identity;
using Base.Domain.Translation;


namespace App.DAL.DTO.Identity;


/// <summary>
/// Application Identity Role Implementation. Defines Specific Entity Rows for Identity Role.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class AppRole : BaseRole
{
    
    /// <summary>
    /// Defines Application Role Display Name. 
    /// </summary>
    // ReSharper disable once CollectionNeverUpdated.Global
    public LanguageString DisplayName { get; set; } = new();
    
}