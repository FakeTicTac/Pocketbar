using Base.Contracts.DAL;
using App.Contracts.DAL.Repositories;
using App.Contracts.DAL.Repositories.Identity;


namespace App.Contracts.DAL;


/// <summary>
/// App Specific Unit of Work Design. Defines Repos That Should Be Implemented.
/// </summary>
public interface IAppUnitOfWork : IUnitOfWork
{
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Amount Units.
    /// </summary>
    IAmountUnitRepository AmountUnits { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Cocktails.
    /// </summary>
    ICocktailRepository Cocktails { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Drink In Cocktails.
    /// </summary>
    IDrinkInCocktailRepository DrinkInCocktails { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Drinks.
    /// </summary>
    IDrinkRepository Drinks { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Drink Types.
    /// </summary>
    IDrinkTypeRepository DrinkTypes { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Ingredient In Cocktails.
    /// </summary>
    IIngredientInCocktailRepository IngredientInCocktails { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Ingredients.
    /// </summary>
    IIngredientRepository Ingredients { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Ratings.
    /// </summary>
    IRatingRepository Ratings { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Steps.
    /// </summary>
    IStepRepository Steps { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing User Cocktails.
    /// </summary>
    IUserCocktailRepository UserCocktails { get; }
    
    
    // Identity Related Only
    
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Refresh Tokens.
    /// </summary>
    IRefreshTokenRepository RefreshTokens { get; }
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Users.
    /// </summary>
    IAppUserRepository Users { get;}
    
    /// <summary>
    /// Data Access Layer Repository Definition For Storing Roles.
    /// </summary>
    IRoleRepository Roles { get; }
    
}