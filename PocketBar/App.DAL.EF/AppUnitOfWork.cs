using AutoMapper;
using Base.DAL.EF;
using App.Contracts.DAL;
using App.DAL.EF.Repositories;
using App.Contracts.DAL.Repositories;
using App.DAL.EF.Repositories.Identity;
using App.Contracts.DAL.Repositories.Identity;


namespace App.DAL.EF;


/// <summary>
/// App Specific Unit of Work Design Implementation - Implements All Repositories.
/// </summary>
public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
{
        
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Amount Units.
    /// </summary>
    public IAmountUnitRepository AmountUnits =>
        GetRepository(() => new AmountUnitRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Cocktails.
    /// </summary>
    public ICocktailRepository Cocktails =>
        GetRepository(() => new CocktailRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Drink In Cocktails.
    /// </summary>
    public IDrinkInCocktailRepository DrinkInCocktails =>
        GetRepository(() => new DrinkInCocktailRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Drinks.
    /// </summary>
    public IDrinkRepository Drinks =>
        GetRepository(() => new DrinkRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Drink Types.
    /// </summary>
    public IDrinkTypeRepository DrinkTypes =>
        GetRepository(() => new DrinkTypeRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Ingredient In Cocktails.
    /// </summary>
    public IIngredientInCocktailRepository IngredientInCocktails =>
        GetRepository(() => new IngredientInCocktailRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Ingredients.
    /// </summary>
    public IIngredientRepository Ingredients =>
        GetRepository(() => new IngredientRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Ratings.
    /// </summary>
    public IRatingRepository Ratings =>
        GetRepository(() => new RatingRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Steps.
    /// </summary>
    public IStepRepository Steps =>
        GetRepository(() => new StepRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing User Cocktails.
    /// </summary>
    public IUserCocktailRepository UserCocktails =>
        GetRepository(() => new UserCocktailRepository(UowDbContext, Mapper));
    
    
    // Identity Related Only.
    
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Achievement Types.
    /// </summary>
    public IAppUserRepository Users =>
        GetRepository(() => new AppUserRepository(UowDbContext, Mapper));
    
    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Roles.
    /// </summary>
    public IRoleRepository Roles =>
        GetRepository(() => new RoleRepository(UowDbContext, Mapper));

    /// <summary>
    /// Data Access Layer Repository Definition Implementation For Storing Refresh Tokens.
    /// </summary>
    public IRefreshTokenRepository RefreshTokens =>
        GetRepository(() => new RefreshTokenRepository(UowDbContext, Mapper));


    /// <summary>
    /// Defines Connection to The Mapper Profile.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly IMapper Mapper;


    /// <summary>
    /// App Specific Unit of Work Constructor. Defines Connection to The Database Layer.
    /// </summary>
    /// <param name="uowDbContext">Defines Connection to The Database Layer.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext) => Mapper = mapper;

}