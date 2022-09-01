using App.BLL.DTO;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Admin.ViewModels.Errors;
using WebApp.Areas.Admin.ViewModels.Ingredient;


namespace WebApp.Areas.Admin.Controllers;


/// <summary>
/// Ingredient Controller.
/// </summary>
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class IngredientController : Controller
{
    
    /// <summary>
    /// Defines Connection To Business Logic Layer.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    
    /// <summary>
    /// Basic Ingredient Controller Constructor. Defines Connection To Business Logic Layer.
    /// </summary>
    /// <param name="bll">Defines Connection To Business Logic Layer.</param>
    public IngredientController(IAppBusinessLogic bll) =>  _bll = bll;


    /// <summary>
    /// Method Loads All Ingredients For Index Page.
    /// </summary>
    /// <param name="errorMessage">Message Defines Error Occured During Any Process.</param>
    /// <returns>Index Page Of Ingredients.</returns>
    public async Task<IActionResult> Index(string? errorMessage = null)
    {
        try
        {
            // Try To Load Resources.
            var result = (await _bll.Ingredients.GetAllWithCocktailsCountAsync()).ToList();
            
            return View(new IngredientIndex
            {
                IngredientModels = result.Select(x => new IngredientModel
                {
                    
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CoverImagePath = x.CoverImagePath,
                    IngredientInCocktailsCount = x.IngredientInCocktailsCount
                    
                }).ToList(),
                Error = (errorMessage != null ? new ErrorMarker(errorMessage) : null) 
            });
        }
        catch (Exception)
        {
            // Error Occured During Loading Or Deletion.
            return View(new IngredientIndex
            {
                IngredientModels = new List<IngredientModel>(),
                Error = new ErrorMarker($"{errorMessage ?? "Error Occured During Resource Loading."} Please Try Again!")
            });
        }
    }

    /// <summary>
    /// Method Loads Create Page For Ingredient.
    /// </summary>
    /// <returns>Create Page For Ingredient</returns>
    public IActionResult Create() => View();

    /// <summary>
    /// Method Creates Ingredient Record In Database.
    /// </summary>
    /// <param name="ingredient">Defines Ingredient Data To Be Created.</param>
    /// <returns>Index View Of Ingredients.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IngredientCreate ingredient)
    {
        if (!ModelState.IsValid) return View(ingredient);
        
        // Add Unit To Database.
        ingredient.Id = Guid.NewGuid();
        _bll.Ingredients.Add(new Ingredient
        {
            Id = ingredient.Id,
            Name = ingredient.Name!,
            Description = ingredient.Description!,
            CoverImagePath = ingredient.CoverImagePath
        });
        await _bll.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Method Loads Data Of Updatable Ingredients.
    /// </summary>
    /// <param name="id">Defines Ingredients ID To Be Modified.</param>
    /// <returns>Edit View Of Ingredients.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid? id)
    {
        
        // ID For Update Should Be Defined.
        if (id == null) return NotFound();

        // Get Record From Database.
        var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id.Value);
        if (ingredient == null) return NotFound();

        return View(new IngredientCreate
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Description = ingredient.Description,
            CoverImagePath = ingredient.CoverImagePath
        });
    }

    /// <summary>
    /// Method Modifies Ingredient Record In Database.
    /// </summary>
    /// <param name="id">Defines Ingredient ID To Be Modified.</param>
    /// <param name="ingredient">Defines Ingredient Data To Be Modified.</param>
    /// <returns>Index View Of Ingredients.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, IngredientCreate ingredient)
    {
        // Check ID To Be Identical.
        if (id != ingredient.Id) return NotFound();

        if (!ModelState.IsValid) return View(ingredient);
        
        // Try To Modify Record In Database.
        try
        {
            _bll.Ingredients.Update(new Ingredient
            {
                Id = ingredient.Id,
                Name = ingredient.Name!,
                Description = ingredient.Description!,
                CoverImagePath = ingredient.CoverImagePath
            });
            
            await _bll.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Update. Please Try Again!" });
        }
    }

    
    /// <summary>
    /// Method Deletes Ingredient Record From Database.
    /// </summary>
    /// <param name="id">Defines Ingredient ID To Be Deleted.</param>
    /// <returns>Index View Of Ingredients.</returns>
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            // Get Record From Database.
            var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id);
            
            if (ingredient == null) return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
            
            // Remove Record From Database.
            _bll.Ingredients.Remove(ingredient);
            await _bll.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
        }
    }
}