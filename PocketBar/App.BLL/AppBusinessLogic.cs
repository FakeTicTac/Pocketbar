using Base.BLL;
using AutoMapper;
using App.BLL.Services;
using App.Contracts.DAL;
using App.Contracts.BLL;
using App.BLL.Services.Identity;
using App.Contracts.BLL.Services;
using App.Contracts.BLL.Services.Identity;


namespace App.BLL;


/// <summary>
/// App Specific Business Logic Design Implementation - Implements All Services.
/// </summary>
public class AppBusinessLogic : BaseBusinessLogic<IAppUnitOfWork>, IAppBusinessLogic
{
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Amount Units.
    /// </summary>
    public IAmountUnitService AmountUnits =>
        GetService<IAmountUnitService>(() => new AmountUnitService(Uow, Uow.AmountUnits, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Cocktails.
    /// </summary>
    public ICocktailService Cocktails =>
        GetService<ICocktailService>(() => new CocktailService(Uow, Uow.Cocktails, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Drink In Cocktails.
    /// </summary>
    public IDrinkInCocktailService DrinkInCocktails =>
        GetService<IDrinkInCocktailService>(() => new DrinkInCocktailService(Uow, Uow.DrinkInCocktails, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Drinks.
    /// </summary>
    public IDrinkService Drinks =>
        GetService<IDrinkService>(() => new DrinkService(Uow, Uow.Drinks, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Drink Types.
    /// </summary>
    public IDrinkTypeService DrinkTypes =>
        GetService<IDrinkTypeService>(() => new DrinkTypeService(Uow, Uow.DrinkTypes, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Ingredient In Cocktails.
    /// </summary>
    public IIngredientInCocktailService IngredientInCocktails =>
        GetService<IIngredientInCocktailService>(() => new IngredientInCocktailService(Uow, Uow.IngredientInCocktails, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Ingredients.
    /// </summary>
    public IIngredientService Ingredients =>
        GetService<IIngredientService>(() => new IngredientService(Uow, Uow.Ingredients, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Ratings.
    /// </summary>
    public IRatingService Ratings =>
        GetService<IRatingService>(() => new RatingService(Uow, Uow.Ratings, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Steps.
    /// </summary>
    public IStepService Steps =>
        GetService<IStepService>(() => new StepService(Uow, Uow.Steps, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing User Cocktails.
    /// </summary>
    public IUserCocktailService UserCocktails =>
        GetService<IUserCocktailService>(() => new UserCocktailService(Uow, Uow.UserCocktails, Mapper));
    
    
    // Identity Related Only
    
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Refresh Tokens.
    /// </summary>
    public IRefreshTokenService RefreshTokens =>
        GetService<IRefreshTokenService>(() => new RefreshTokenService(Uow, Uow.RefreshTokens, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing App Users.
    /// </summary>
    public IAppUserService AppUsers =>
        GetService<IAppUserService>(() => new AppUserService(Uow, Uow.Users, Mapper));
    
    /// <summary>
    /// Business Logic Layer Service Definition Implementation For Storing Roles.
    /// </summary>
    public IRoleService Roles =>
        GetService<IRoleService>(() => new RoleService(Uow, Uow.Roles, Mapper));
    
    
    /// <summary>
    /// Defines Connection to The Mapper Profile.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly IMapper Mapper;


    /// <summary>
    /// Service Constructor Defines Connection With Data Access Layer (Unit of Work). 
    /// </summary>
    /// <param name="uow">ata Access Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppBusinessLogic(IAppUnitOfWork uow, IMapper mapper) : base(uow) => Mapper = mapper;

}