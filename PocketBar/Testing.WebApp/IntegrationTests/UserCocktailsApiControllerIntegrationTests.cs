using Xunit;
using System;
using Api.DTO.v1;
using Newtonsoft.Json;
using System.Net.Http;
using Xunit.Abstractions;
using Api.DTO.v1.Identity;
using System.Threading.Tasks;
using Testing.WebApp.Helpers;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;


namespace Testing.WebApp.IntegrationTests;


/// <summary>
/// Class Represents User Cocktail API Controller Integration Testing.
/// </summary>
public class UserCocktailsApiControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    
    /// <summary>
    /// Defines Connection To HTTP Request Sender.
    /// </summary>
    private readonly HttpClient _client;
    
    /// <summary>
    /// Defines Class That Presents Test Outputs.
    /// </summary>
    // ReSharper disable once NotAccessedField.Local
    private readonly ITestOutputHelper _testOutputHelper;
    
    /// <summary>
    /// Defines Connection To Class That Modifies App Startup And Seeds Needed Data.
    /// </summary>
    // ReSharper disable once NotAccessedField.Local
    private readonly CustomWebApplicationFactory<Program> _factory;


    /// <summary>
    /// Basic User Cocktail Integration Testing Constructor.
    /// </summary>
    /// <param name="factory">Defines Connection To Class That Modifies App Startup And Seeds Needed Data.</param>
    /// <param name="testOutputHelper">Defines Class That Presents Test Outputs.</param>
    public UserCocktailsApiControllerIntegrationTests(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
    {
        _factory = factory;
        _testOutputHelper = testOutputHelper;
        _client = factory.WithWebHostBuilder(builder =>
            {
                builder.UseSetting("MemoryDatabase", Guid.NewGuid().ToString());
            })
            .CreateClient(new WebApplicationFactoryClientOptions
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

        const string uriAllCocktails = "/api/v1/Cocktail";
        const string uriRegister = "/api/v1/Identity/Account/Register";
        
        // Registration Data.
        var register = new Register
        {
            UserName = "TestyMan",
            Email = "testy_man@gmail.com",
            Password = "Qwe123!Qwe123!"
        };
        
        StringContent httpContent = 
            new(JsonConvert.SerializeObject(register), System.Text.Encoding.UTF8, "application/json");
            
            
        // Action 1. (Try To Register User)
        var getRegisterResponse = await _client.PostAsync(uriRegister, httpContent);
        var content = getRegisterResponse.Content.ReadAsStringAsync().Result;

        var jwtResponse = JsonHelper.DeserializeWithWebDefaults<Jwt>(content);

        // Assert Registration.
        Assert.NotNull(jwtResponse);
        Assert.NotNull(jwtResponse!.TokenValue);
        Assert.Contains("TestyMan", jwtResponse.Username!);
            
            
        // Action 2. (Try To Get All Cocktails)
        _client.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", jwtResponse.TokenValue);
        
        var getAllCocktailsResponse = await _client.GetAsync(uriAllCocktails);
        
        content = getAllCocktailsResponse.Content.ReadAsStringAsync().Result;

        var cocktailsList = JsonHelper.DeserializeWithWebDefaults<List<Cocktail>>(content);
            
        // Assert Cocktail List.
        Assert.NotNull(cocktailsList);
        Assert.Equal(8, cocktailsList!.Count);
        Assert.True(cocktailsList[0].IsAlcoholic);
        Assert.True(cocktailsList[1].IsAlcoholic);
        Assert.True(cocktailsList[2].IsAlcoholic);
        Assert.True(cocktailsList[3].IsAlcoholic);
       
        // Action 3. (Leave Comments On Two Cocktails)
        
        var userCocktailOne = new UserCocktail
        {
            Comment = "TestyMan Comment 1",
            CocktailId = cocktailsList[0].Id
        };
        
        var userCocktailTwo = new UserCocktail
        {
            Comment = "TestyMan Comment 2",
            CocktailId = cocktailsList[2].Id
        };
        
        StringContent useCocktailOneHttpContent = 
            new(JsonConvert.SerializeObject(userCocktailOne), System.Text.Encoding.UTF8, "application/json");
        
        StringContent useCocktailTwoHttpContent = 
            new(JsonConvert.SerializeObject(userCocktailTwo), System.Text.Encoding.UTF8, "application/json");
        
        var postUserCocktailOne = await _client.PostAsync("api/v1/usercocktail", useCocktailOneHttpContent);
        var postUserCocktailTwo = await _client.PostAsync("api/v1/usercocktail", useCocktailTwoHttpContent);
        
        content = postUserCocktailOne.Content.ReadAsStringAsync().Result;
        
        var userCocktailOneData = JsonHelper.DeserializeWithWebDefaults<UserCocktail>(content);
        
        content = postUserCocktailTwo.Content.ReadAsStringAsync().Result;
        
        var userCocktailTwoData = JsonHelper.DeserializeWithWebDefaults<UserCocktail>(content);
        
        // Assert First User Cocktail Data.
        Assert.NotNull(userCocktailOneData);
        Assert.True(userCocktailOneData!.CocktailId == cocktailsList[0].Id);
        Assert.True(userCocktailOneData.Comment == "TestyMan Comment 1");
        
        // Assert Second User Cocktail Data.
        Assert.NotNull(userCocktailTwoData);
        Assert.True(userCocktailTwoData!.CocktailId == cocktailsList[2].Id);
        Assert.True(userCocktailTwoData.Comment == "TestyMan Comment 2");
    }
}




