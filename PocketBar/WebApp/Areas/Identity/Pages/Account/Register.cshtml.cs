#nullable disable

using System.Text;
using App.Domain.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.UI.Services;


// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global


namespace WebApp.Areas.Identity.Pages.Account;


/// <summary>
/// Application Registration Model.
/// </summary>
public class RegisterModel : PageModel
{
    
    /// <summary>
    /// Defines Connection To Sing In Manager.
    /// </summary>
    private readonly SignInManager<AppUser> _signInManager;
    
    /// <summary>
    /// Defines Connection To User Manager.
    /// </summary>
    private readonly UserManager<AppUser> _userManager;
    
    /// <summary>
    /// Defines Connection To User Store.
    /// </summary>
    private readonly IUserStore<AppUser> _userStore;
    
    /// <summary>
    /// Defines Connection To Email Store.
    /// </summary>
    private readonly IUserEmailStore<AppUser> _emailStore;
    
    /// <summary>
    /// Defines Connection To Logger.
    /// </summary>
    private readonly ILogger<RegisterModel> _logger;
    
    /// <summary>
    /// Defines Connection To Email Sender.
    /// </summary>
    private readonly IEmailSender _emailSender;

    
    /// <summary>
    /// Basic Register Constructor.
    /// </summary>
    /// <param name="userManager">Defines Connection To User Manager.</param>
    /// <param name="userStore">Defines Connection To User Store.</param>
    /// <param name="signInManager">Defines Connection To Sing In Manager.</param>
    /// <param name="logger">Defines Connection To Logger.</param>
    /// <param name="emailSender">Defines Connection To Email Sender.</param>
    public RegisterModel(UserManager<AppUser> userManager, IUserStore<AppUser> userStore, SignInManager<AppUser> signInManager,
        ILogger<RegisterModel> logger, IEmailSender emailSender)
    {
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
        _signInManager = signInManager;
        _logger = logger;
        _emailSender = emailSender;
    }

    
    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [BindProperty]
    public InputModel Input { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public string ReturnUrl { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public IList<AuthenticationScheme> ExternalLogins { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class InputModel
    {
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [Display(Name = "Username")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Username { get; set; }
        
    }

    /// <summary>
    /// Method Handles External Logins.
    /// </summary>
    /// <param name="returnUrl">Defines URL For Redirect.</param>
    public async Task OnGetAsync(string returnUrl = null)
    {
        ReturnUrl = returnUrl;
        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    /// <summary>
    /// Method Handles External Logins.
    /// </summary>
    /// <param name="returnUrl">Defines URL For Redirect.</param>
    /// <returns>Redirected To Page.</returns>
    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        // ReSharper disable Html.PathError
        returnUrl ??= Url.Content("~/Authorized/Homepage");
        // ReSharper restore Html.PathError
        
        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        if (ModelState.IsValid)
        {
            var user = CreateUser();

            await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

            user.UserName = Input.Username;

            var result = await _userManager.CreateAsync(user, Input.Password);
            
            await _userManager.AddClaimAsync(user, new Claim("aspnet.username", user.UserName));

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity",userId, code, returnUrl },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl!)}'>clicking here</a>.");

                await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, false);
                
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
                
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }

    /// <summary>
    /// Method Handles User Creation.
    /// </summary>
    /// <returns>Created User State.</returns>
    /// <exception cref="InvalidOperationException">Drops If User Creation Not Succeeded.</exception>
    private AppUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<AppUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                                                $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }

    /// <summary>
    /// Some Method.
    /// </summary>
    /// <returns>Something.</returns>
    /// <exception cref="NotSupportedException">Drops If Occured Error With Email.</exception>
    private IUserEmailStore<AppUser> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<AppUser>)_userStore;
    }
}