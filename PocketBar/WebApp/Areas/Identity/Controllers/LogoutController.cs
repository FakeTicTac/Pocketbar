using WebApp.ViewModels;
using System.Diagnostics;
using App.Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace WebApp.Areas.Identity.Controllers;


/// <summary>
/// Logout Page Controller Implementation.
/// </summary>
[Authorize]
[Area("Identity")]
public class LogoutController : Controller
{
    
    /// <summary>
    /// Defines Sign In Manager Connection.
    /// </summary>
    private readonly SignInManager<AppUser> _signInManager;

    
    /// <summary>
    /// Logout Basic Constructor.
    /// </summary>
    /// <param name="signInManager">Defines Sign In Manager Connection.</param>
    public LogoutController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    
    /// <summary>
    /// Error Displaying.
    /// </summary>
    /// <returns>View With Displayed Error.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    
    /// <summary>
    /// Method Logs User Out Of System.
    /// </summary>
    /// <param name="returnUrl">Defines URL To Be Redirected After Procedure.</param>
    /// <returns>Redirect To Page.</returns>
    public async Task<IActionResult> Logout(string? returnUrl = null)
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home", new { area = "" });
    }
}