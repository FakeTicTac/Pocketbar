
namespace WebApp.Areas.Authorized.ViewModels.Errors;


/// <summary>
/// Class Represents Error Marker Data For Communication With User What Gone Wrong.
/// </summary>
public class ErrorMarker
{

    /// <summary>
    /// Defines Error Message To Display To User.
    /// </summary>
    public string? ErrorMessage { get; set; }
    
    
    /// <summary>
    /// Basic Error Marker Constructor. Defines Error Message To Display To User.
    /// </summary>
    /// <param name="errorMessage"></param>
    public ErrorMarker(string errorMessage) => ErrorMessage = errorMessage;

}