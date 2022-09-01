using App.BLL.DTO;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Admin.ViewModels.Errors;
using WebApp.Areas.Admin.ViewModels.AmountUnit;


namespace WebApp.Areas.Admin.Controllers;


/// <summary>
/// Amount Unit Controller.
/// </summary>
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AmountUnitController : Controller
{
    
    /// <summary>
    /// Defines Connection To Business Logic Layer.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    
    /// <summary>
    /// Basic Amount Unit Controller Constructor. Defines Connection To Business Logic Layer.
    /// </summary>
    /// <param name="bll">Defines Connection To Business Logic Layer.</param>
    public AmountUnitController(IAppBusinessLogic bll) =>  _bll = bll;


    /// <summary>
    /// Method Loads All Amount Units For Index Page.
    /// </summary>
    /// <param name="errorMessage">Message Defines Error Occured During Any Process.</param>
    /// <returns>Index Page Of Amount Units.</returns>
    public async Task<IActionResult> Index(string? errorMessage = null)
    {
        try
        {
            // Try To Load Resources.
            var result = (await _bll.AmountUnits.GetAllWithUsageCountsAsync()).ToList();
            
            return View(new AmountUnitIndex
            {
                AmountUnitModels = result.Select(x => new AmountUnitModel
                {
                    
                    Id = x.Id,
                    Name = x.Name,
                    UsageWithDrinksCount = x.UsageWithDrinksCount,
                    UsageWithIngredientsCount = x.UsageWithIngredientsCount
                    
                }).ToList(),
                Error = (errorMessage != null ? new ErrorMarker(errorMessage) : null) 
            });
        }
        catch (Exception)
        {
            // Error Occured During Loading Or Deletion.
            return View(new AmountUnitIndex
            {
                AmountUnitModels = new List<AmountUnitModel>(),
                Error = new ErrorMarker($"{errorMessage ?? "Error Occured During Resource Loading."} Please Try Again!")
            });
        }
    }

    /// <summary>
    /// Method Loads Create Page For Amount Unit.
    /// </summary>
    /// <returns>Create Page For Amount Unit</returns>
    public IActionResult Create() => View();

    /// <summary>
    /// Method Creates Amount Unit Record In Database.
    /// </summary>
    /// <param name="amountUnit">Defines Amount Unit Data To Be Created.</param>
    /// <returns>Index View Of Amount Units.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AmountUnitCreate amountUnit)
    {
        if (!ModelState.IsValid) return View(amountUnit);
        
        // Add Unit To Database.
        amountUnit.Id = Guid.NewGuid();
        _bll.AmountUnits.Add(new AmountUnit
        {
            Id = amountUnit.Id,
            Name = amountUnit.Name!
        });
        await _bll.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Method Loads Data Of Updatable Amount Unit.
    /// </summary>
    /// <param name="id">Defines Amount Unit ID To Be Modified.</param>
    /// <returns>Edit View Of Amount Units.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid? id)
    {
        
        // ID For Update Should Be Defined.
        if (id == null) return NotFound();

        // Get Record From Database.
        var amountUnit = await _bll.AmountUnits.FirstOrDefaultAsync(id.Value);
        if (amountUnit == null) return NotFound();

        return View(new AmountUnitCreate
        {
            Id = amountUnit.Id,
            Name = amountUnit.Name
        });
    }

    /// <summary>
    /// Method Modifies Amount Unit Record In Database.
    /// </summary>
    /// <param name="id">Defines Amount Unit ID To Be Modified.</param>
    /// <param name="amountUnit">Defines Amount Unit Data To Be Modified.</param>
    /// <returns>Index View Of Amount Units.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, AmountUnitCreate amountUnit)
    {
        // Check ID To Be Identical.
        if (id != amountUnit.Id) return NotFound();

        if (!ModelState.IsValid) return View(amountUnit);
        
        // Try To Modify Record In Database.
        try
        {
            _bll.AmountUnits.Update(new AmountUnit
            {
                Id = amountUnit.Id,
                Name = amountUnit.Name!
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
    /// Method Deletes Amount Unit Record From Database.
    /// </summary>
    /// <param name="id">Defines Amount Unit ID To Be Deleted.</param>
    /// <returns>Index View Of Amount Units.</returns>
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            // Get Record From Database.
            var amountUnit = await _bll.AmountUnits.FirstOrDefaultAsync(id);
            
            if (amountUnit == null) return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
            
            // Remove Record From Database.
            _bll.AmountUnits.Remove(amountUnit);
            await _bll.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
        }
    }
}