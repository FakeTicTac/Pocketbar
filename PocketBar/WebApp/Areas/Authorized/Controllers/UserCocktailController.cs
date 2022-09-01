using App.BLL.DTO;
using Base.Extensions;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Authorized.ViewModels.Errors;
using WebApp.Areas.Authorized.ViewModels.Rating;
using WebApp.Areas.Authorized.ViewModels.UserCocktail;


namespace WebApp.Areas.Authorized.Controllers;


/// <summary>
/// User Cocktails Page Controller Implementation.
/// </summary>
[Authorize]
[Area("Authorized")]
public class UserCocktailController : Controller
{

    /// <summary>
    /// Defines Connection To Business Logic Layer.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    
    /// <summary>
    /// User Cocktails Page Controller Controller Constructor. Defines Generic Logging Interface.
    /// </summary>
    /// <param name="bll">Defines Connection To Business Logic Layer.</param>
    public UserCocktailController(IAppBusinessLogic bll) => _bll = bll;
    
    
    /// <summary>
    /// Loads Index View With All User Cocktails Information.
    /// </summary>
    /// <param name="errorMessage">Defines Error Message Sent From Another Action.</param>
    /// <returns>User Cocktails Index Page.</returns>
    public async Task<IActionResult> Index(string? errorMessage = null)
    {
        try
        {
            // Try To Load Resources.
            var result = (await _bll.UserCocktails.GetAllDetailedAsync(User.GetUserId())).ToList();
            
            return View(new UserCocktailIndex
            {
                UserCocktails = result.Select(x => new UserCocktailModel
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    CocktailName = x.CocktailName,
                    RatingValue = x.RatingValue,
                    CoverImagePath = x.CoverImagePath,
                    AppUserId = x.AppUserId,
                    CocktailId = x.CocktailId,
                    RatingId = x.RatingId
                }).ToList(),
                Error = (errorMessage != null ? new ErrorMarker(errorMessage) : null) 
            });
        }
        catch (Exception)
        {
            // Error Occured During Loading Or Deletion.
            return View(new UserCocktailIndex
            {
                UserCocktails = new List<UserCocktailModel>(),
                Error = new ErrorMarker($"{errorMessage ?? "Error Occured During Resource Loading."} Please Try Again!")
            });
        }
    }


    /// <summary>
    /// Method Loads Create Page For User Cocktail.
    /// </summary>
    /// <param name="id">Defines ID of Cocktail.</param>
    /// <returns>Create Page For User Cocktail</returns>
    public async Task<IActionResult> Create(Guid id)
    {
        var drink = new UserCocktailCreate
        {
            CocktailId = id
        };
        drink.Ratings = new SelectList((await _bll.Ratings.GetAllAsync()).Select(x => new RatingModel
        {
            Id = x.Id,
            GradeValue = x.GradeValue,
            Description = x.Description,
            DisplayValue = x.GradeValue + " - " + x.Description
            
        }), "Id", "DisplayValue", drink.RatingId);

        return View(drink);
    }

    /// <summary>
    /// Method Creates User Cocktail Record In Database.
    /// </summary>
    /// <param name="userCocktail">Defines User Cocktail To Be Created.</param>
    /// <returns>Index View Of User Cocktails.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserCocktailCreate userCocktail)
    {
        if (!ModelState.IsValid) return View(userCocktail);
        
        // Add Unit To Database.
        userCocktail.Id = Guid.NewGuid();
        _bll.UserCocktails.Add(new UserCocktail
        {
            Id = userCocktail.Id,
            Comment = userCocktail.Comment,
            RatingId = userCocktail.RatingId,
            CocktailId = userCocktail.CocktailId,
            AppUserId = User.GetUserId()
        }, User.GetUserId());
        await _bll.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }
    
    /// <summary>
    /// Method Deletes User Cocktail Record From Database.
    /// </summary>
    /// <param name="id">Defines User Cocktail ID To Be Deleted.</param>
    /// <returns>Index View Of User Cocktails.</returns>
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            // Get Record From Database.
            var userCocktail = await _bll.UserCocktails.FirstOrDefaultAsync(id, User.GetUserId());
            
            if (userCocktail == null) return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
            
            // Remove Record From Database.
            _bll.UserCocktails.Remove(userCocktail, User.GetUserId());
            await _bll.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception x)
        {
            Console.WriteLine(x);
            
            return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
        }
    }
}