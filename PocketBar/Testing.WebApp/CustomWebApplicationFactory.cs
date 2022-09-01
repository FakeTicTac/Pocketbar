using App.Domain;
using App.DAL.EF;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;


namespace Testing.WebApp;


/// <summary>
/// Class Modifies App Startup And Seeds Needed Data.
/// </summary>
/// <typeparam name="TStartup">Defines Type Of Start Up.</typeparam>
// ReSharper disable once ClassNeverInstantiated.Global
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> 
    where TStartup: class
{

    /// <summary>
    /// Configures Web Host Start Up.
    /// </summary>
    /// <param name="builder">Defines Builder For Web Host.</param>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Find Database Context
            var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<AppDbContext>));

            // Remove If Found
            if (descriptor != null) services.Remove(descriptor);

            // New DbContext
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MemoryDatabase"));
            
            
            // Create DB and Seed Data
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<AppDbContext>();
            
            db.Database.EnsureCreated();

            
            // Seed Cocktail Data Into In Memory Database.
            
            
            db.Cocktails.Add(new Cocktail
            {
                Name = "Long Drink",
                Description = "Amazing Long Drink",
                IsAlcoholic = true
            });
            
            db.Cocktails.Add(new Cocktail
            {
                Name = "Margarita",
                Description = "Amazing Margarita Drink",
                IsAlcoholic = true
            });
            
            db.Cocktails.Add(new Cocktail
            {
                Name = "Black Russian",
                Description = "Amazing Black Russian Drink",
                IsAlcoholic = true
            });
            
            db.Cocktails.Add(new Cocktail
            {
                Name = "White Russian",
                Description = "Amazing White Russian Drink",
                IsAlcoholic = true
            });

            db.SaveChanges();
        });
    }
}