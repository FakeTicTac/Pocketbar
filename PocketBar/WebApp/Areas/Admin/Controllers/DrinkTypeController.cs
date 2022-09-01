using App.BLL.DTO;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Admin.ViewModels.Errors;
using WebApp.Areas.Admin.ViewModels.DrinkType;


namespace WebApp.Areas.Admin.Controllers;


/// <summary>
/// Drink Type Controller.
/// </summary>
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DrinkTypeController : Controller
{
    
    /// <summary>
    /// Defines Connection To Business Logic Layer.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    
    /// <summary>
    /// Basic Drink Type Controller Constructor. Defines Connection To Business Logic Layer.
    /// </summary>
    /// <param name="bll">Defines Connection To Business Logic Layer.</param>
    public DrinkTypeController(IAppBusinessLogic bll) =>  _bll = bll;


    /// <summary>
    /// Method Loads All Drink Types For Index Page.
    /// </summary>
    /// <param name="errorMessage">Message Defines Error Occured During Any Process.</param>
    /// <returns>Index Page Of Amount Units.</returns>
    public async Task<IActionResult> Index(string? errorMessage = null)
    {
        try
        {
            // Try To Load Resources.
            var result = (await _bll.DrinkTypes.GetAllWithDrinksCountAsync()).ToList();
            
            return View(new DrinkTypeIndex
            {
                DrinkTypeModels = result.Select(x => new DrinkTypeModel
                {
                    
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    DrinksCount = x.DrinksCount
                    
                }).ToList(),
                Error = (errorMessage != null ? new ErrorMarker(errorMessage) : null) 
            });
        }
        catch (Exception)
        {
            // Error Occured During Loading Or Deletion.
            return View(new DrinkTypeIndex
            {
                DrinkTypeModels = new List<DrinkTypeModel>(),
                Error = new ErrorMarker($"{errorMessage ?? "Error Occured During Resource Loading."} Please Try Again!")
            });
        }
    }

    /// <summary>
    /// Method Loads Create Page For Drink Type.
    /// </summary>
    /// <returns>Create Page For Drink Type</returns>
    public IActionResult Create() => View();

    /// <summary>
    /// Method Creates Drink Type Record In Database.
    /// </summary>
    /// <param name="drinkType">Defines Amount Unit Data To Be Created.</param>
    /// <returns>Index View Of Drink Types.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DrinkTypeCreate drinkType)
    {
        if (!ModelState.IsValid) return View(drinkType);
        
        // Add Unit To Database.
        drinkType.Id = Guid.NewGuid();
        _bll.DrinkTypes.Add(new DrinkType
        {
            Id = drinkType.Id,
            Name = drinkType.Name!,
            Description = drinkType.Description!
            
        });
        await _bll.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Method Loads Data Of Updatable Drink Type.
    /// </summary>
    /// <param name="id">Defines Drink Type ID To Be Modified.</param>
    /// <returns>Edit View Of Drink Types.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid? id)
    {
        
        // ID For Update Should Be Defined.
        if (id == null) return NotFound();

        // Get Record From Database.
        var drinkType = await _bll.DrinkTypes.FirstOrDefaultAsync(id.Value);
        if (drinkType == null) return NotFound();

        return View(new DrinkTypeCreate
        {
            Id = drinkType.Id,
            Name = drinkType.Name,
            Description = drinkType.Description
        });
    }

    /// <summary>
    /// Method Modifies Drink Type Record In Database.
    /// </summary>
    /// <param name="id">Defines Drink Type ID To Be Modified.</param>
    /// <param name="drinkType">Defines Drink Type Data To Be Modified.</param>
    /// <returns>Index View Of Drink Types.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, DrinkTypeCreate drinkType)
    {
        // Check ID To Be Identical.
        if (id != drinkType.Id) return NotFound();

        if (!ModelState.IsValid) return View(drinkType);
        
        // Try To Modify Record In Database.
        try
        {
            _bll.DrinkTypes.Update(new DrinkType
            {
                Id = drinkType.Id,
                Name = drinkType.Name!,
                Description = drinkType.Description!
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
    /// Method Deletes Drink Type Record From Database.
    /// </summary>
    /// <param name="id">Defines Drink Type ID To Be Deleted.</param>
    /// <returns>Index View Of Drink Types.</returns>
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            // Get Record From Database.
            var drinkType = await _bll.DrinkTypes.FirstOrDefaultAsync(id);
            
            if (drinkType == null) return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
            
            // Remove Record From Database.
            _bll.DrinkTypes.Remove(drinkType);
            await _bll.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
        }
    }
}