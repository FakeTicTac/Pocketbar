using App.BLL.DTO;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Admin.ViewModels.Drink;
using WebApp.Areas.Admin.ViewModels.Errors;


namespace WebApp.Areas.Admin.Controllers;


/// <summary>
/// Drink Controller.
/// </summary>
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DrinkController : Controller
{
    
    /// <summary>
    /// Defines Connection To Business Logic Layer.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    
    /// <summary>
    /// Basic Drink Controller Constructor. Defines Connection To Business Logic Layer.
    /// </summary>
    /// <param name="bll">Defines Connection To Business Logic Layer.</param>
    public DrinkController(IAppBusinessLogic bll) =>  _bll = bll;


    /// <summary>
    /// Method Loads All Drinks For Index Page.
    /// </summary>
    /// <param name="errorMessage">Message Defines Error Occured During Any Process.</param>
    /// <returns>Index Page Of Drinks.</returns>
    public async Task<IActionResult> Index(string? errorMessage = null)
    {
        try
        {
            // Try To Load Resources.
            var result = (await _bll.Drinks.GetAllWithDrinkTypeAndCocktailsCountAsync()).ToList();
            return View(new DrinkIndex
            {
                DrinkModels = result.Select(x => new DrinkModel
                {
                    
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    AlcoholByVolume = x.AlcoholByVolume,
                    CoverImagePath = x.CoverImagePath,
                    DrinkTypeName = x.DrinkTypeName,
                    DrinkInCocktailsCount = x.DrinkInCocktailsCount

                }).ToList(),
                Error = (errorMessage != null ? new ErrorMarker(errorMessage) : null) 
            });
        }
        catch (Exception)
        {
            // Error Occured During Loading Or Deletion.
            return View(new DrinkIndex
            {
                DrinkModels = new List<DrinkModel>(),
                Error = new ErrorMarker($"{errorMessage ?? "Error Occured During Resource Loading."} Please Try Again!")
            });
        }
    }

    /// <summary>
    /// Method Loads Create Page For Amount Unit.
    /// </summary>
    /// <returns>Create Page For Amount Unit</returns>
    public async Task<IActionResult> Create()
    {
        var drink = new DrinkCreate();
        drink.DrinkTypes = new SelectList(await _bll.DrinkTypes.GetAllAsync(), "Id", "Name", drink.DrinkTypeId);

        return View(drink);
    }

    /// <summary>
    /// Method Creates Drink Record In Database.
    /// </summary>
    /// <param name="drink">Defines Drink Data To Be Created.</param>
    /// <returns>Index View Of Drinks.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DrinkCreate drink)
    {
        if (!ModelState.IsValid)
        {
            drink.DrinkTypes = new SelectList(await _bll.DrinkTypes.GetAllAsync(), "Id", "Name", drink.DrinkTypeId);
            return View(drink);
        }
        
        // Add Unit To Database.
        drink.Id = Guid.NewGuid();
        _bll.Drinks.Add(new Drink
        {
            Id = drink.Id,
            Name = drink.Name!,
            Description = drink.Description!,
            AlcoholByVolume = drink.AlcoholByVolume,
            CoverImagePath = drink.CoverImagePath,
            DrinkTypeId = drink.DrinkTypeId
        });
        await _bll.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Method Loads Data Of Updatable Drink.
    /// </summary>
    /// <param name="id">Defines Drink ID To Be Modified.</param>
    /// <returns>Edit View Of Drinks.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid? id)
    {
        
        // ID For Update Should Be Defined.
        if (id == null) return NotFound();

        // Get Record From Database.
        var drink = await _bll.Drinks.FirstOrDefaultAsync(id.Value);
        if (drink == null) return NotFound();

        var drinkCreate = new DrinkCreate
        {
            Id = drink.Id,
            Name = drink.Name,
            Description = drink.Description,
            AlcoholByVolume = drink.AlcoholByVolume,
            CoverImagePath = drink.CoverImagePath,
            DrinkTypeId = drink.DrinkTypeId
        };
        
        drinkCreate.DrinkTypes = new SelectList(await _bll.DrinkTypes.GetAllAsync(), "Id", "Name", drinkCreate.DrinkTypeId);
        
        return View(drinkCreate);
    }

    /// <summary>
    /// Method Modifies Drink Record In Database.
    /// </summary>
    /// <param name="id">Defines Drink ID To Be Modified.</param>
    /// <param name="drink">Defines Drink Data To Be Modified.</param>
    /// <returns>Index View Of Drinks.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, DrinkCreate drink)
    {
        // Check ID To Be Identical.
        if (id != drink.Id) return NotFound();

        if (!ModelState.IsValid)
        {
            drink.DrinkTypes = new SelectList(await _bll.DrinkTypes.GetAllAsync(), "Id", "Name", drink.DrinkTypeId);
            return View(drink);
        }
        
        // Try To Modify Record In Database.
        try
        {
            _bll.Drinks.Update(new Drink
            {
                Id = drink.Id,
                Name = drink.Name!,
                Description = drink.Description!,
                AlcoholByVolume = drink.AlcoholByVolume,
                CoverImagePath = drink.CoverImagePath,
                DrinkTypeId = drink.DrinkTypeId
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
    /// Method Deletes Drink Record From Database.
    /// </summary>
    /// <param name="id">Defines Drink ID To Be Deleted.</param>
    /// <returns>Index View Of Drinks.</returns>
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            // Get Record From Database.
            var drink = await _bll.Drinks.FirstOrDefaultAsync(id);
            
            if (drink == null) return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
            
            // Remove Record From Database.
            _bll.Drinks.Remove(drink);
            await _bll.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
        }
    }
}
