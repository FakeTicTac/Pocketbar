using Base.Contracts.BLL;
using App.Contracts.BLL.Services;
using App.Contracts.BLL.Services.Identity;


namespace App.Contracts.BLL;


/// <summary>
/// App Specific Business Logic Design. Defines Services That Should Be Implemented.
/// </summary>
public interface IAppBusinessLogic : IBusinessLogic
{
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Amount Units.
    /// </summary>
    IAmountUnitService AmountUnits { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Cocktails.
    /// </summary>
    ICocktailService Cocktails { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Drink In Cocktails.
    /// </summary>
    IDrinkInCocktailService DrinkInCocktails { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Drinks.
    /// </summary>
    IDrinkService Drinks { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Drink Types.
    /// </summary>
    IDrinkTypeService DrinkTypes { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Ingredient In Cocktails.
    /// </summary>
    IIngredientInCocktailService IngredientInCocktails { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Ingredients.
    /// </summary>
    IIngredientService Ingredients { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Ratings.
    /// </summary>
    IRatingService Ratings { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Steps.
    /// </summary>
    IStepService Steps { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing User Cocktails.
    /// </summary>
    IUserCocktailService UserCocktails { get; }
    
    
    // Identity Related Only
    
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Refresh Tokens.
    /// </summary>
    IRefreshTokenService RefreshTokens { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Users .
    /// </summary>
    IAppUserService AppUsers { get; }
    
    /// <summary>
    /// Business Logic Layer Service Definition For Storing Roles.
    /// </summary>
    IRoleService Roles { get; }
    
}