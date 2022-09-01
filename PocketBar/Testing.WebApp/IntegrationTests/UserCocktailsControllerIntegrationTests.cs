using System.Collections.Generic;
using System.Net;
using Xunit;
using System.Net.Http;
using AngleSharp.Html.Dom;
using System.Threading.Tasks;
using Testing.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Testing.WebApp.Extensions;


namespace Testing.WebApp.IntegrationTests;


/// <summary>
/// Class Represents User Cocktail API Controller Integration Testing.
/// </summary>
public class UserCocktailsControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    
    /// <summary>
    /// Defines Connection To HTTP Request Sender.
    /// </summary>
    private readonly HttpClient _client;
    
    /// <summary>
    /// Defines Connection To Class That Modifies App Startup And Seeds Needed Data.
    /// </summary>
    // ReSharper disable once NotAccessedField.Local
    private readonly CustomWebApplicationFactory<Program> _factory;


    /// <summary>
    /// Basic User Cocktail Integration Testing Constructor.
    /// </summary>
    /// <param name="factory">Defines Connection To Class That Modifies App Startup And Seeds Needed Data.</param>
    public UserCocktailsControllerIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }


    /// <summary>
    /// Method Tests Program Happy Flow
    /// </summary>
    [Fact]
    public async Task HappyFlowTesting()
    {
        // Arrange

        // Act - Load Landing Page
        var response = await _client.GetAsync("/");

        // Assert
        response.EnsureSuccessStatusCode();
        
        // Get The Actual Content From Response
        var getTestContent = await HtmlHelpers.GetDocumentAsync(response);
        var signInButton = (IHtmlAnchorElement) getTestContent.QuerySelector("#signIn")!;
        var registerButton = (IHtmlAnchorElement) getTestContent.QuerySelector("#register")!;
        
        // Assert That Buttons Exist.
        Assert.NotNull(signInButton);
        Assert.NotNull(registerButton);
        
        // Act 2 - Try To Login 
        response = await _client.GetAsync("/Identity/Account/Login");
        
        // Assert
        response.EnsureSuccessStatusCode();
        
        // Get The Actual Content From Response
        getTestContent = await HtmlHelpers.GetDocumentAsync(response);
        
        var formLogin = (IHtmlFormElement) getTestContent.QuerySelector("#form-login")!;
        
        var loginField = (IHtmlInputElement) getTestContent.QuerySelector("#loginField")!;
        var passwordField = (IHtmlInputElement) getTestContent.QuerySelector("#passwordField")!;
        
        // Assert That Fields Exist.
        Assert.NotNull(loginField);
        Assert.NotNull(passwordField);
        Assert.NotNull(formLogin);
        
        // Act 2 - Try To Register 
        response = await _client.GetAsync("/Identity/Account/Register");
        
        // Assert
        response.EnsureSuccessStatusCode();
        
        // Get The Actual Content From Response
        getTestContent = await HtmlHelpers.GetDocumentAsync(response);
        
        var formRegister = (IHtmlFormElement) getTestContent.QuerySelector("#form-register")!;
        
        var emailField = (IHtmlInputElement) getTestContent.QuerySelector("#emailField")!;
        var usernameField = (IHtmlInputElement) getTestContent.QuerySelector("#usernameField")!;
        passwordField = (IHtmlInputElement) getTestContent.QuerySelector("#passwordField")!;
        var repeatPasswordField = (IHtmlInputElement) getTestContent.QuerySelector("#repeatPasswordField")!;
        
        // Assert That Fields Exist.
        Assert.NotNull(emailField);
        Assert.NotNull(usernameField);
        Assert.NotNull(passwordField);
        Assert.NotNull(repeatPasswordField);
        
        Assert.NotNull(formRegister);
        
        var formRegisterValues = new Dictionary<string, string>
        {
            ["Email"] = "testyManUser@ttu.ee",
            ["Username"] = "testyManUser",
            ["Password"] = "Qq123!Qq123!",
            ["ConfirmPassword"] = "Qq123!Qq123!",
        };
        
        // ACT send form with data to server, method (POST) is detected from form element
        var postRegisterResponse = await _client.SendAsync(formRegister, formRegisterValues);
        
        // ASSERT found - 302 - ie user was created and we should redirect
        Assert.Equal(HttpStatusCode.OK, postRegisterResponse.StatusCode);
        
    }
}