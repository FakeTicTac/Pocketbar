using WebApp.ViewModels;
using WebApp.Controllers;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authorization;


namespace WebApp.Areas.Authorized.Controllers;


/// <summary>
/// Home Page Controller Implementation.
/// </summary>
[Authorize]
[Area("Authorized")]
public class HomePageController : Controller
{
    
    /// <summary>
    /// Generic Logging Interface Definition.
    /// </summary>
    // ReSharper disable once NotAccessedField.Local
    private readonly ILogger<HomeController> _logger;

    /// <summary>
    /// Home Page Controller Controller Constructor. Defines Generic Logging Interface.
    /// </summary>
    /// <param name="logger">Generic Logging Interface</param>
    public HomePageController(ILogger<HomeController> logger) => _logger = logger;

    /// <summary>
    /// Loads Index View.
    /// </summary>
    /// <returns></returns>
    public IActionResult Index() => View();

    /// <summary>
    /// Error Displaying.
    /// </summary>
    /// <returns>View With Displayed Error.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
   
    /// <summary>
    /// Method Appends Users' Chosen Language to Cookie.
    /// </summary>
    /// <param name="culture">Chosen Culture Value.</param>
    /// <param name="returnUrl">URL To Redirect User To.</param>
    /// <returns>Redirect User To URL with Chosen Language Preference.</returns>
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, 
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            }
        );
        
        return LocalRedirect(returnUrl);
    }
}