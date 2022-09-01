using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace WebApp.Areas.Admin.Controllers;


/// <summary>
/// Class Represents Control Panel Controller With Views.
/// </summary>
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ControlPanelController : Controller
{
    
    /// <summary>
    /// Loads Control Panel Index View.
    /// </summary>
    /// <returns></returns>
    public IActionResult Index() => View();
    
}