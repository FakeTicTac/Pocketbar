using Moq;
using Xunit;
using System;
using System.Linq;
using App.Contracts.DAL;
using Base.BLL.Services;
using Xunit.Abstractions;
using Testing.WebApp.Enums;
using System.Threading.Tasks;
using Base.Contracts.BLL.Mappers;
using System.Collections.Generic;
using Base.Contracts.DAL.Repositories;


// ReSharper disable NotAccessedField.Local
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable


namespace Testing.WebApp.UnitTests;


/// <summary>
/// Class Represents Ingredient Base Service Unit Testing.
/// </summary>
public class BaseServiceIngredientUnitTests
{
    
    /// <summary>
    /// Defines Class That Presents Test Outputs.
    /// </summary>
    private readonly ITestOutputHelper _testOutputHelper;
    
    /// <summary>
    /// Defines Connection To Mocked App Unit Of Work.
    /// </summary>
    private readonly Mock<IAppUnitOfWork> _mockedAppUnitOfWork;
    
    /// <summary>
    /// Defines Connection To Mocked Base Ingredient Repository.
    /// </summary>
    private readonly Mock<IEntityRepository<App.DAL.DTO.Ingredient>> _mockedBaseRepository;
    
    /// <summary>
    /// Defines Connection To Mocked Base Mapper.
    /// </summary>
    private readonly Mock<IBaseMapper<App.BLL.DTO.Ingredient, App.DAL.DTO.Ingredient>> _mockedMapper;

    /// <summary>
    /// Defines Connection To Base Ingredient Service.
    /// </summary>
    private readonly BaseEntityService<App.BLL.DTO.Ingredient, App.DAL.DTO.Ingredient, IAppUnitOfWork, IEntityRepository<App.DAL.DTO.Ingredient>> _baseEntityService;
        
    
    /// <summary>
    /// Basic Ingredient Base Service Unit Testing Constructor.
    /// </summary>
    /// <param name="testOutputHelper">Defines Class That Presents Test Outputs.</param>
    public BaseServiceIngredientUnitTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            
            // mocked objects
            _mockedAppUnitOfWork = new Mock<IAppUnitOfWork>();

            // Mocking Repository (Basically Repository Rules)
            _mockedBaseRepository = new Mock<IEntityRepository<App.DAL.DTO.Ingredient>>(MockBehavior.Strict);
            
            // Setting Up Repository Rules
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.GetAllAsync);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.GetAll);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.FirstOrDefaultAsync);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.FirstOrDefault);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.Add);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.Update);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.Remove);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.RemoveAsync);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.ExistAsync);
            SetupForMockedRepo(_mockedBaseRepository, EBaseTestingMethods.Exist);
            
            // Mocking Mapper (Basically Mapper Rules)
            _mockedMapper = new Mock<IBaseMapper<App.BLL.DTO.Ingredient, App.DAL.DTO.Ingredient>>();
            
            // Setting Up Mapper Rules
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.GetAllAsync);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.GetAll);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.FirstOrDefaultAsync);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.FirstOrDefault);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.Add);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.Update);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.Remove);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.RemoveAsync);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.ExistAsync);
            SetupForMockedMapper(_mockedMapper, EBaseTestingMethods.Exist);
            
            _baseEntityService =
                new BaseEntityService<App.BLL.DTO.Ingredient, App.DAL.DTO.Ingredient, IAppUnitOfWork, IEntityRepository<App.DAL.DTO.Ingredient>>
                    (_mockedAppUnitOfWork.Object, _mockedBaseRepository.Object, _mockedMapper.Object);
            
        }

    
        /// <summary>
        /// Method Tests Get All Async Method In Base Service.
        /// </summary>
        [Fact]
        public async void TestGetAllAsync()
        {
            // Action.
            var result = (await _baseEntityService.GetAllAsync()).ToList();
            
            // Assert Collection
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            
            // Assert Lime Ingredient
            Assert.Equal("Lime", result[0].Name);
            Assert.Equal("Limy", result[0].Description);
            Assert.Equal("www.image1.com", result[0].CoverImagePath);

            // Assert Ice Ingredient
            Assert.Equal("Ice", result[1].Name);
            Assert.Equal("Icy", result[1].Description);
            Assert.Equal("www.image2.com", result[1].CoverImagePath);
            
            // Check Repository
            _mockedBaseRepository.Verify(x => x
                .GetAllAsync(It.Is<Guid?>(a => a == default), It.Is<bool>(a=> a)), Times.Once);
            
            // Check Mappers For Both.
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Ice")), Times.Once);
            
        }
        
        /// <summary>
        /// Method Tests Get All Method In Base Service.
        /// </summary>
        [Fact]
        public void TestGetAll()
        {
            // Action.
            var result = _baseEntityService.GetAll().ToList();
            
            // Assert Collection
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            
            // Assert Lime Ingredient
            Assert.Equal("Lime", result[0].Name);
            Assert.Equal("Limy", result[0].Description);
            Assert.Equal("www.image1.com", result[0].CoverImagePath);

            // Assert Ice Ingredient
            Assert.Equal("Ice", result[1].Name);
            Assert.Equal("Icy", result[1].Description);
            Assert.Equal("www.image2.com", result[1].CoverImagePath);
            
            // Check Repository
            _mockedBaseRepository.Verify(x => x
                .GetAll(It.Is<Guid?>(a => a == default), It.Is<bool>(a=> a)), Times.Once);
            
            // Check Mappers For Both.
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Ice")), Times.Once);
            
        }
        
        /// <summary>
        /// Method Tests First Or Default Async Method In Base Service.
        /// </summary>
        [Fact]
        public async void TestFirstOrDefaultAsync()
        {
            // Action.
            var result = await _baseEntityService.FirstOrDefaultAsync(Guid.Empty);
            
            // Assert Lime Ingredient
            Assert.NotNull(result);
            Assert.Equal("Lime", result!.Name);
            Assert.Equal("Limy", result.Description);
            Assert.Equal("www.image1.com", result.CoverImagePath);

            // Check Repository
            _mockedBaseRepository.Verify(x => x
                .FirstOrDefaultAsync(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default),
                    It.Is<bool>(a=> a)), Times.Once);
            
            // Check Mapper.
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
        }
        
        /// <summary>
        /// Method Tests First Or Default Method In Base Service.
        /// </summary>
        [Fact]
        public void TestFirstOrDefault()
        {
            // Action.
            var result = _baseEntityService.FirstOrDefault(Guid.Empty);
            
            // Assert Lime Ingredient
            Assert.NotNull(result);
            Assert.Equal("Lime", result!.Name);
            Assert.Equal("Limy", result.Description);
            Assert.Equal("www.image1.com", result.CoverImagePath);

            // Check Repository
            _mockedBaseRepository.Verify(x => x
                .FirstOrDefault(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default),
                    It.Is<bool>(a=> a)), Times.Once);
            
            // Check Mapper.
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
        }
        
        /// <summary>
        /// Method Add Method In Base Service.
        /// </summary>
        [Fact]
        public void TestAdd()
        {
            // Action.
            var result = _baseEntityService.Add(new App.BLL.DTO.Ingredient {
                Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
            });
            
            // Assert Lime Ingredient
            Assert.NotNull(result);
            Assert.Equal("Lime", result.Name);
            Assert.Equal("Limy", result.Description);
            Assert.Equal("www.image1.com", result.CoverImagePath);

            // Check Repository
            _mockedBaseRepository.Verify(x => x
                .Add(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime"), default), Times.Once);
            
            // Check Mappers Both.
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.BLL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
        }
        
        /// <summary>
        /// Method Update Method In Base Service.
        /// </summary>
        [Fact]
        public void TestUpdate()
        {
            // Action.
            var result = _baseEntityService.Update(new App.BLL.DTO.Ingredient {
                Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
            });
            
            // Assert Lime Ingredient
            Assert.NotNull(result);
            Assert.Equal("Lime", result.Name);
            Assert.Equal("Limy", result.Description);
            Assert.Equal("www.image1.com", result.CoverImagePath);

            // Check Repository
            _mockedBaseRepository.Verify(x => x
                .Update(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime"), default), Times.Once);
            
            // Check Mappers Both.
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.BLL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
        }
        
        /// <summary>
        /// Method Remove Method In Base Service.
        /// </summary>
        [Fact]
        public void TestRemove()
        {
            // Action.
            var result = _baseEntityService.Remove(new App.BLL.DTO.Ingredient {
                Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
            });
            
            // Assert Lime Ingredient
            Assert.NotNull(result);
            Assert.Equal("Lime", result.Name);
            Assert.Equal("Limy", result.Description);
            Assert.Equal("www.image1.com", result.CoverImagePath);

            // Check Repository
            _mockedBaseRepository.Verify(x => x
                .Remove(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime"), 
                    It.Is<Guid?>(a => a == default)), Times.Once);
            
            // Check Mappers Both.
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.BLL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
        }
        
        /// <summary>
        /// Method Remove Async Method In Base Service.
        /// </summary>
        [Fact]
        public async void TestRemoveAsync()
        {
            // Action.
            var result = await _baseEntityService.RemoveAsync(Guid.Empty);
            
            // Assert Lime Ingredient
            Assert.NotNull(result);
            Assert.Equal("Lime", result.Name);
            Assert.Equal("Limy", result.Description);
            Assert.Equal("www.image1.com", result.CoverImagePath);

            // Check Repository
            _mockedBaseRepository.Verify(x => x
                    .RemoveAsync(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default)), Times.Once);
            
            // Check Mapper.
            _mockedMapper.Verify(x => x
                .Map(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")), Times.Once);
            
        }
        
        /// <summary>
        /// Method Exist Async Method In Base Service.
        /// </summary>
        [Fact]
        public async void TestExistAsync()
        {
            // Action.
            var resultExpectTrue = await _baseEntityService.ExistAsync(Guid.Empty);
            var resultExpectFalse = await _baseEntityService.ExistAsync(Guid.Parse("b847c33b-2590-4cf8-bf77-f24e9728650b"));

            // Assert Existence of Ingredient
            Assert.IsType<bool>(resultExpectTrue);
            Assert.IsType<bool>(resultExpectFalse);
            Assert.True(resultExpectTrue);
            Assert.False(resultExpectFalse);

            // Check Repository
            _mockedBaseRepository.Verify(x => x
                    .ExistAsync(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default)), Times.Once);
            
            // Check Mapper.
            _mockedBaseRepository.Verify(x => x
                    .ExistAsync(It.Is<Guid>(a => a == Guid.Parse("b847c33b-2590-4cf8-bf77-f24e9728650b")), 
                    It.Is<Guid?>(a => a == default)), Times.Once);
            
        }
        
        /// <summary>
        /// Method Exist Method In Base Service.
        /// </summary>
        [Fact]
        public void TestExist()
        {
            // Action.
            var resultExpectTrue = _baseEntityService.Exist(Guid.Empty);
            var resultExpectFalse = _baseEntityService.Exist(Guid.Parse("b847c33b-2590-4cf8-bf77-f24e9728650b"));

            // Assert Existence of Ingredient
            Assert.IsType<bool>(resultExpectTrue);
            Assert.IsType<bool>(resultExpectFalse);
            Assert.True(resultExpectTrue);
            Assert.False(resultExpectFalse);

            // Check Repository
            _mockedBaseRepository.Verify(x => x
                .Exist(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default)), Times.Once);
            
            // Check Mapper.
            _mockedBaseRepository.Verify(x => x
                .Exist(It.Is<Guid>(a => a == Guid.Parse("b847c33b-2590-4cf8-bf77-f24e9728650b")), 
                    It.Is<Guid?>(a => a == default)), Times.Once);
            
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
                },
                new App.DAL.DTO.Ingredient
                {
                    Name = "Ice",
                    Description = "Icy",
                    CoverImagePath = "www.image2.com",
                }
            };
            
            return ingredients;
        }

    /// <summary>
    /// Method Sets Up Rules For Mocked Repository Based On Method.
    /// </summary>
    /// <param name="mockedBaseRepository">Defines Mocked Repository Connection.</param>
    /// <param name="method">Defines Method For Rule Setup.</param>
    private static void SetupForMockedRepo(Mock<IEntityRepository<App.DAL.DTO.Ingredient>> mockedBaseRepository, EBaseTestingMethods method)
    {
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (method)
        {
            // Get All Methods Initialization.
            case EBaseTestingMethods.GetAllAsync:

                mockedBaseRepository
                    .Setup(x => x.GetAllAsync(
                        It.Is<Guid?>(a => a == default), It.Is<bool>(a => a)))
                    .Returns(Task.FromResult(ListOfIngredients()));
                break;

            case EBaseTestingMethods.GetAll:

                mockedBaseRepository
                    .Setup(x => x.GetAll(
                        It.Is<Guid?>(a => a == default), It.Is<bool>(a => a)))
                    .Returns(ListOfIngredients());
                    break;

            // Get One Item Methods Initialization.
            case EBaseTestingMethods.FirstOrDefaultAsync:

                mockedBaseRepository
                    .Setup(x => x.FirstOrDefaultAsync(It.Is<Guid>(a => a == Guid.Empty), 
                        It.Is<Guid?>(a => a == default), It.Is<bool>(a => a)))
                    .Returns(Task.FromResult(new App.DAL.DTO.Ingredient
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    })!);
                break;

            case EBaseTestingMethods.FirstOrDefault:

                mockedBaseRepository
                    .Setup(x => x.FirstOrDefault(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default), 
                        It.Is<bool>(a => a)))
                    .Returns(new App.DAL.DTO.Ingredient
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    });
                break;

            // Basic Operations (Add, Remove, Update)
            case EBaseTestingMethods.Add:

                mockedBaseRepository
                    .Setup(x => x.Add(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime"), default))
                    .Returns(new App.DAL.DTO.Ingredient
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    });
                break;

            case EBaseTestingMethods.Update:

                mockedBaseRepository
                    .Setup(x => x.Update(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime"), default))
                    .Returns(new App.DAL.DTO.Ingredient
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    });
                break;

            case EBaseTestingMethods.Remove:

                mockedBaseRepository
                    .Setup(x => x.Remove(It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime"), 
                        It.Is<Guid?>(a => a == default)))
                    .Returns(new App.DAL.DTO.Ingredient
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    });
                break;

            case EBaseTestingMethods.RemoveAsync:
                mockedBaseRepository
                    .Setup(x => x.RemoveAsync(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default)))
                    .Returns(Task.FromResult(new App.DAL.DTO.Ingredient
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    }));
                break;

            // Exist Operations.
            case EBaseTestingMethods.ExistAsync:

                mockedBaseRepository
                    .Setup(x => x.ExistAsync(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default)))
                    .Returns(Task.FromResult(true));

                mockedBaseRepository
                    .Setup(x => x.ExistAsync(
                        It.Is<Guid>(a => a == Guid.Parse("b847c33b-2590-4cf8-bf77-f24e9728650b")), 
                        It.Is<Guid?>(a => a == default)))
                    .Returns(Task.FromResult(false));
                    break;

            case EBaseTestingMethods.Exist:

                mockedBaseRepository
                    .Setup(x => x.Exist(It.Is<Guid>(a => a == Guid.Empty), It.Is<Guid?>(a => a == default)))
                    .Returns(true);

                mockedBaseRepository.Setup(x => 
                        x.Exist(It.Is<Guid>(a => a == Guid.Parse("b847c33b-2590-4cf8-bf77-f24e9728650b")), 
                            It.Is<Guid?>(a => a == default)))
                    .Returns(false);
                    break; 
        }
    }

    /// <summary>
    /// Method Sets Up Rules For Mocked Mapper Based On Method.
    /// </summary>
    /// <param name="mockedMapper">Defines Mocked Mapper Connection.</param>
    /// <param name="method">Defines Method For Rule Setup.</param>
    private static void SetupForMockedMapper(Mock<IBaseMapper<App.BLL.DTO.Ingredient, App.DAL.DTO.Ingredient>> mockedMapper, EBaseTestingMethods method)
    {
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (method)
        {
            case EBaseTestingMethods.ExistAsync: case EBaseTestingMethods.Exist:
                break;

            // Handle Data Transfer Both Sides.
            case EBaseTestingMethods.Add: case EBaseTestingMethods.Update:
                mockedMapper
                    .Setup(x => x.Map(
                        It.Is<App.BLL.DTO.Ingredient>(a => a.Name == "Lime")))
                    .Returns(new App.DAL.DTO.Ingredient
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    });

                mockedMapper
                    .Setup(x => x.Map(
                        It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")))
                    .Returns(new App.BLL.DTO.Ingredient
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    });
                break;
            
            default:

                mockedMapper
                    .Setup(x => x.Map(
                        It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Lime")))
                    .Returns(new App.BLL.DTO.Ingredient         
                    {
                        Name = "Lime", Description = "Limy", CoverImagePath = "www.image1.com"
                    });

                mockedMapper.
                    Setup(x => x.Map(
                        It.Is<App.DAL.DTO.Ingredient>(a => a.Name == "Ice")))
                    .Returns(new App.BLL.DTO.Ingredient                     
                    {
                        Name = "Ice", Description = "Icy", CoverImagePath = "www.image2.com"
                    });
                break; 
        }
    }
}