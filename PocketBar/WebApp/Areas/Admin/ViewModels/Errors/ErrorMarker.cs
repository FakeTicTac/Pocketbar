
namespace WebApp.Areas.Admin.ViewModels.Errors;


// ReSharper disable MemberCanBePrivate.Global


/// <summary>
/// Class Represents Error Marker Data For Communication With User What Gone Wrong.
/// </summary>
public class ErrorMarker
{

    /// <summary>
    /// Defines Error Message To Display To User.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? ErrorMessage { get; set; }
    
    
    /// <summary>
    /// Basic Error Marker Constructor. Defines Error Message To Display To User.
    /// </summary>
    /// <param name="errorMessage"></param>
    public ErrorMarker(string errorMessage) => ErrorMessage = errorMessage;

}