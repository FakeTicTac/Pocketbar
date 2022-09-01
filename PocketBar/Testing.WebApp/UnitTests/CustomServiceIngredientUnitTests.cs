using Moq;
using Xunit;
using System;
using AutoMapper;
using System.Linq;
using App.BLL.Services;
using App.Contracts.DAL;
using Xunit.Abstractions;
using System.Threading.Tasks;
using System.Collections.Generic;
using App.Contracts.DAL.Repositories;


// ReSharper disable NotAccessedField.Local
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable


namespace Testing.WebApp.UnitTests;


/// <summary>
/// Class Represents Ingredient Custom Service Unit Testing.
/// </summary>
public class CustomServiceIngredientUnitTests
{
    
    /// <summary>
    /// Defines Connection To Mocked Mapper.
    /// </summary>
    private readonly Mock<IMapper> _mockedMapper;
    
    /// <summary>
    /// Defines Class That Presents Test Outputs.
    /// </summary>
    private readonly ITestOutputHelper _testOutputHelper;
    
    /// <summary>
    /// Defines Connection To Mocked App Unit Of Work.
    /// </summary>
    private readonly Mock<IAppUnitOfWork> _mockedAppUnitOfWork;
    
    /// <summary>
    /// Defines Connection To Mocked Ingredient Repository.
    /// </summary>
    private readonly Mock<IIngredientRepository> _mockedIngredientRepository;

    /// <summary>
    /// Defines Connection To Ingredient Service.
    /// </summary>
    private readonly IngredientService _ingredientService;

    
    /// <summary>
    /// Basic Ingredient Custom Service Unit Testing Constructor.
    /// </summary>
    /// <param name="testOutputHelper">Defines Class That Presents Test Outputs.</param>
    public CustomServiceIngredientUnitTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        
        // Mocking Mapper (Basically Mapper Rules)
        _mockedMapper = new Mock<IMapper>();
        
        _mockedMapper.Setup(x => x
                .Map<App.BLL.DTO.Ingredient>(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")))
                .Returns(new App.BLL.DTO.Ingredient
                {
                    Name = "Lime", 
                    Description = "Limy", 
                    CoverImagePath = "www.image1.com",
                    IngredientInCocktailsCount = 20
                });
        
        _mockedMapper.Setup(x => x
                .Map<App.BLL.DTO.Ingredient>(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Ice")))
                .Returns(new App.BLL.DTO.Ingredient
                {
                    Name = "Ice",
                    Description = "Icy",
                    CoverImagePath = "www.image2.com",
                    IngredientInCocktailsCount = 30
                });
        
        _mockedAppUnitOfWork = new Mock<IAppUnitOfWork>();
        
        // Mocking Repository (Basically Repository Rules)
        _mockedIngredientRepository = new Mock<IIngredientRepository>();

        _mockedIngredientRepository.Setup(x => x
                .GetAllWithCocktailsCountAsync(It.Is<bool>(y => y)))
                .Returns(Task.FromResult(ListOfIngredients()));

        _mockedIngredientRepository.Setup(x => x
                .FirstOrDefaultWithCocktailsCountAsync(
                    It.Is<Guid>(a => a == Guid.Empty), It.Is<bool>(a => a)))
                .Returns(Task.FromResult(new App.DAL.DTO.Ingredient
                {
                    Name = "Lime",
                    Description = "Limy",
                    CoverImagePath = "www.image1.com",
                    IngredientInCocktailsCount = 20

                })!);
        
        _ingredientService = new IngredientService(_mockedAppUnitOfWork.Object, _mockedIngredientRepository.Object, _mockedMapper.Object);

    }
    
    /// <summary>
    /// Method Tests Get All With Counter Method In Service.
    /// </summary>
    [Fact]
    public async void TestGetAllWithCocktailsCountAsync()
    {
        // Action.
        var result = (await _ingredientService.GetAllWithCocktailsCountAsync()).ToList();

        // Assert Lime Ingredient
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Lime", result[0].Name);
        Assert.Equal("Limy", result[0].Description);
        Assert.Equal("www.image1.com", result[0].CoverImagePath);
        Assert.Equal(20, result[0].IngredientInCocktailsCount);
        
        // Assert Ice Ingredient
        Assert.Equal("Ice", result[1].Name);
        Assert.Equal("Icy", result[1].Description);
        Assert.Equal("www.image2.com", result[1].CoverImagePath);
        Assert.Equal(30, result[1].IngredientInCocktailsCount);

        // Check Repository
        _mockedIngredientRepository.Verify(x => x
            .GetAllWithCocktailsCountAsync(It.Is<bool>(a=> a)), Times.Once);
            
        // Check Mappers For Both.
        _mockedMapper.Verify(x => x
            .Map<App.BLL.DTO.Ingredient>(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
        _mockedMapper.Verify(x => x
            .Map<App.BLL.DTO.Ingredient>(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Ice")), Times.Once);
    }

    /// <summary>
    /// Method Tests First Or Default Counter Method In Service.
    /// </summary>
    [Fact]
    public async void TestFirstOrDefaultWithCocktailsCountAsync()
    {
        // Action.
        var result = await _ingredientService.FirstOrDefaultWithCocktailsCountAsync(Guid.Empty);

        // Assert Lime Ingredient
        Assert.NotNull(result);
        Assert.Equal("Lime", result!.Name);
        Assert.Equal("Limy", result.Description);
        Assert.Equal("www.image1.com", result.CoverImagePath);
        Assert.Equal(20, result.IngredientInCocktailsCount);

        // Check Repository
        _mockedIngredientRepository.Verify(x => x
            .FirstOrDefaultWithCocktailsCountAsync(
                It.Is<Guid>(a=> a == Guid.Empty),
                It.Is<bool>(a=> a)), Times.Once);
            
        // Check Mappers.
        _mockedMapper.Verify(x => x
            .Map<App.BLL.DTO.Ingredient>(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
    }

    
    // Helping Methods.
    
    
    /// <summary>
    /// Method Creates List of Data Access Layer Object.
    /// </summary>
    /// <returns>List of Data Access Layer Ingredients.</returns>
    private static IEnumerable<App.DAL.DTO.Ingredient> ListOfIngredients()
    {
        List<App.DAL.DTO.Ingredient> ingredients = new()
        {
            new App.DAL.DTO.Ingredient
            {
                Name = "Lime",
                Description = "Limy",
                CoverImagePath = "www.image1.com",
                IngredientInCocktailsCount = 20
            },
            new App.DAL.DTO.Ingredient
            {
                Name = "Ice",
                Description = "Icy",
                CoverImagePath = "www.image2.com",
                IngredientInCocktailsCount = 30
            }
        };
            
        return ingredients;
    }
}