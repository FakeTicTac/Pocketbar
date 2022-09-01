using App.BLL.DTO;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Admin.ViewModels.Errors;
using WebApp.Areas.Admin.ViewModels.Rating;


namespace WebApp.Areas.Admin.Controllers;


/// <summary>
/// Rating Controller.
/// </summary>
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class RatingController : Controller
{
    
    /// <summary>
    /// Defines Connection To Business Logic Layer.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    
    /// <summary>
    /// Basic Rating Controller Constructor. Defines Connection To Business Logic Layer.
    /// </summary>
    /// <param name="bll">Defines Connection To Business Logic Layer.</param>
    public RatingController(IAppBusinessLogic bll) =>  _bll = bll;


    /// <summary>
    /// Method Loads All Ratings For Index Page.
    /// </summary>
    /// <param name="errorMessage">Message Defines Error Occured During Any Process.</param>
    /// <returns>Index Page Of Ratings.</returns>
    public async Task<IActionResult> Index(string? errorMessage = null)
    {
        try
        {
            // Try To Load Resources.
            var result = (await _bll.Ratings.GetAllWithUsageCountAsync()).ToList();
            
            return View(new RatingIndex
            {
                RatingModels = result.Select(x => new RatingModel
                {
                    
                    Id = x.Id,
                    GradeValue = x.GradeValue,
                    Description = x.Description,
                    UsageCount = x.UsageCount,

                }).ToList(),
                Error = (errorMessage != null ? new ErrorMarker(errorMessage) : null) 
            });
        }
        catch (Exception)
        {
            // Error Occured During Loading Or Deletion.
            return View(new RatingIndex
            {
                RatingModels = new List<RatingModel>(),
                Error = new ErrorMarker($"{errorMessage ?? "Error Occured During Resource Loading."} Please Try Again!")
            });
        }
    }

    /// <summary>
    /// Method Loads Create Page For Rating.
    /// </summary>
    /// <returns>Create Page For Rating</returns>
    public IActionResult Create() => View();

    /// <summary>
    /// Method Creates Rating Record In Database.
    /// </summary>
    /// <param name="rating">Defines Rating Data To Be Created.</param>
    /// <returns>Index View Of Ratings.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RatingCreate rating)
    {
        if (!ModelState.IsValid) return View(rating);
        
        // Add Unit To Database.
        rating.Id = Guid.NewGuid();
        _bll.Ratings.Add(new Rating
        {
            Id = rating.Id,
            GradeValue = rating.GradeValue!,
            Description = rating.Description!,
        });
        await _bll.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Method Loads Data Of Updatable Ratings.
    /// </summary>
    /// <param name="id">Defines Ratings ID To Be Modified.</param>
    /// <returns>Edit View Of Ratings.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid? id)
    {
        
        // ID For Update Should Be Defined.
        if (id == null) return NotFound();

        // Get Record From Database.
        var rating = await _bll.Ratings.FirstOrDefaultAsync(id.Value);
        if (rating == null) return NotFound();

        return View(new RatingCreate
        {
            Id = rating.Id,
            GradeValue = rating.GradeValue,
            Description = rating.Description,
        });
    }

    /// <summary>
    /// Method Modifies Rating Record In Database.
    /// </summary>
    /// <param name="id">Defines Rating ID To Be Modified.</param>
    /// <param name="rating">Defines Rating Data To Be Modified.</param>
    /// <returns>Index View Of Ratings.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, RatingCreate rating)
    {
        // Check ID To Be Identical.
        if (id != rating.Id) return NotFound();

        if (!ModelState.IsValid) return View(rating);
        
        // Try To Modify Record In Database.
        try
        {
            _bll.Ratings.Update(new Rating
            {
                Id = rating.Id,
                GradeValue = rating.GradeValue!,
                Description = rating.Description!,
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
    /// Method Deletes Rating Record From Database.
    /// </summary>
    /// <param name="id">Defines Rating ID To Be Deleted.</param>
    /// <returns>Index View Of Ratings.</returns>
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            // Get Record From Database.
            var rating = await _bll.Ratings.FirstOrDefaultAsync(id);
            
            if (rating == null) return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
            
            // Remove Record From Database.
            _bll.Ratings.Remove(rating);
            await _bll.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", new { errorMessage = "Error Occured During Record Deletion. Please Try Again!" });
        }
    }
}