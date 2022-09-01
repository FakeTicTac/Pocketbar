using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Authorized.ViewModels.Errors;
using WebApp.Areas.Authorized.ViewModels.Cocktail;


namespace WebApp.Areas.Authorized.Controllers;


/// <summary>
/// Cocktails Page Controller Implementation.
/// </summary>
[Authorize]
[Area("Authorized")]
public class CocktailsController : Controller
{

    /// <summary>
    /// Defines Connection To Business Logic Layer.
    /// </summary>
    private readonly IAppBusinessLogic _bll;


    /// <summary>
    /// Cocktails Page Controller Controller Constructor. Defines Generic Logging Interface.
    /// </summary>
    /// <param name="bll">Defines Connection To Business Logic Layer.</param>
    public CocktailsController(IAppBusinessLogic bll) => _bll = bll;


    /// <summary>
    /// Loads Index View With All Cocktails Information.
    /// </summary>
    /// <param name="errorMessage">Defines Error Message Sent From Another Action.</param>
    /// <returns>Cocktails Index Page.</returns>
    public async Task<IActionResult> Index(string? errorMessage = null)
    {
        try
        {
            // Try To Load Resources.
            var result = (await _bll.Cocktails.GetAllAsync()).ToList();
            
            return View(new CocktailIndex
            {
                Cocktails = result.Select(x => new CocktailModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CoverImagePath = x.CoverImagePath
                }).ToList(),
                Error = (errorMessage != null ? new ErrorMarker(errorMessage) : null) 
            });
        }
        catch (Exception)
        {
            // Error Occured During Loading Or Deletion.
            return View(new CocktailIndex
            {
                Cocktails = new List<CocktailModel>(),
                Error = new ErrorMarker($"{errorMessage ?? "Error Occured During Resource Loading."} Please Try Again!")
            });
        }
    }


    /// <summary>
    /// Loads Details View With All Cocktail Information.
    /// </summary>
    /// <param name="id">Defines ID Of Cocktail To Be Loaded.</param>
    /// <returns>Cocktail Details Page</returns>
    public async Task<IActionResult> Details(Guid id)
    {
        // Try To Load Resources.
        var result = await _bll.Cocktails.FirstOrDefaultDetailedAsync(id);

        // Data Wasn't Found.
        if (result == null) RedirectToAction("Index");
        
        return View(result);
    }
    
    /// <summary>
    /// Loads Index View With All Cocktail Information And Deletes One Record.
    /// </summary>
    /// <param name="id">Defines ID Of Cocktail To Be Deleted.</param>
    /// <returns>Cocktail Index Page</returns>
    public async Task<IActionResult?> Delete(Guid id)
    {
        try
        {
            // Try To Delete Record From Database.
            await _bll.Cocktails.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            // Send Message That Error Occured During Deletion.
            return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion." });
        }
    }
}