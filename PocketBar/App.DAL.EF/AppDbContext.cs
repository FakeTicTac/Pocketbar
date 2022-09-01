using App.Domain;
using App.Domain.Identity;
using Base.DAL.EF.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace App.DAL.EF;


/// <summary>
/// Database Layer Implementation: Database Creation from Models.
/// </summary>
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    
    /// <summary>
    /// Entity Set for Amount Units Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<AmountUnit> AmountUnits { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Cocktails Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Cocktail> Cocktails { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Drinks Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Drink> Drinks { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Drink In Cocktails Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<DrinkInCocktail> DrinkInCocktails { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Drink Types Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<DrinkType> DrinkTypes { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Ingredients Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Ingredient> Ingredients { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Ingredient In Cocktails Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<IngredientInCocktail> IngredientInCocktails { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Ratings Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Rating> Ratings { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Steps Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Step> Steps { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for User Cocktails Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<UserCocktail> UserCocktails { get; set; } = default!;
    
    
    // Identity Related Only
    
    
    /// <summary>
    /// Entity Set for Refresh Tokens Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
    

    /// <summary>
    /// Initializes a New Instance of AppDbContext.
    /// </summary>
    /// <param name="options">The Option To Be Used by a DbContext.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    /// <summary>
    /// Method Defines Models Configurations.
    /// </summary>
    /// <param name="builder">Define API for Model Configuration.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove The Cascade Delete For Every Entity Relationship
        DbContextHelperProvider.RemoveCascadeDelete(builder);
        
        builder.Entity<Cocktail>()
            .HasMany(x => x.DrinkInCocktails)
            .WithOne(x => x.Cocktail)
            .HasForeignKey(x => x.CocktailId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Cocktail>()
            .HasMany(x => x.IngredientInCocktails)
            .WithOne(x => x.Cocktail)
            .HasForeignKey(x => x.CocktailId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Cocktail>()
            .HasMany(x => x.Steps)
            .WithOne(x => x.Cocktail)
            .HasForeignKey(x => x.CocktailId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }

    /// <summary>
    /// Method Fixes DataTime Type To Match UTC Zone and Saves All Changes To Database.
    /// </summary>
    /// <returns>The Number of State Entries Written to Database.</returns>
    public override int SaveChanges()
    {
        // Fix DateTime Type To Match UTC
        FixDatetimeUtc(this);

        // Handle Metadata Insertion and Change In Database.
        DbContextHelperProvider.SaveChangesMetadataUpdate(ChangeTracker);
        
        return base.SaveChanges();
    }

    /// <summary>
    /// Method Fixes DataTime Type To Match UTC Zone and Saves All Changes To Database.
    /// </summary>
    /// <param name="cancellationToken">Notification That Operations Should Be Stopped.</param>
    /// <returns>The Number of State Entries Written to Database.</returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        // Fix DateTime Type To Match UTC
        FixDatetimeUtc(this);
        
        // Handle Metadata Insertion and Change In Database.
        DbContextHelperProvider.SaveChangesMetadataUpdate(ChangeTracker);
        
        return base.SaveChangesAsync(cancellationToken);
    }
    

    // Custom Methods.


    /// <summary>
    /// Method Fixes DataTime Type To Match UTC Zone.
    /// </summary>
    /// <param name="context">Database Connection Definition.</param>
    // ReSharper disable once SuggestBaseTypeForParameter
    private static void FixDatetimeUtc(AppDbContext context)
    {
        var dateProperties = context.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?))
            .Select(z => new
            {
                ParentName = z.DeclaringEntityType.Name,
                PropertyName = z.Name
            });

        var editedEntitiesInTheDbContextGraph = context.ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified)
            .Select(x => x.Entity);
        

        foreach (var entity in editedEntitiesInTheDbContextGraph)
        {
            // ReSharper disable once PossibleMultipleEnumeration
            var entityFields = dateProperties
                .Where(d => d.ParentName == entity.GetType().FullName);

            foreach (var property in entityFields)
            {
                var prop = entity.GetType().GetProperty(property.PropertyName);

                if (prop == null) continue;

                if (prop.GetValue(entity) is not DateTime originalValue) continue;

                prop.SetValue(entity, DateTime.SpecifyKind(originalValue, DateTimeKind.Utc));
            }
        }
    }
}