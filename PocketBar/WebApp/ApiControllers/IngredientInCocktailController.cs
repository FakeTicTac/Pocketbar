using AutoMapper;
using Api.DTO.v1;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Ingredient In Cocktail Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]

public class IngredientInCocktailController : ControllerBase
{

    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Rating Mapper Connection Definition.
    /// </summary>
    private readonly IngredientInCocktailMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientInCocktailController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new IngredientInCocktailMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Ingredients In Cocktails.
    /// </summary>
    /// <returns>IEnumerable of Ingredients In Cocktails.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IngredientInCocktail), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<IngredientInCocktail>>> GetIngredientInCocktails() =>
        Ok((await _bll.IngredientInCocktails.GetAllAsync()).Select(x => _mapper.Map(x)));

    /// <summary>
    /// Method Gets Ingredients In Cocktail With Detailed Info.
    /// </summary>
    /// <param name="id">Ingredients In Cocktail ID Value To Search For Ingredients In Cocktail.</param>
    /// <returns>Ingredients In Cocktail With Detailed Info</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IngredientInCocktail), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IngredientInCocktail>> GetIngredientInCocktail(Guid id)
    {
        var ingredientInCocktail = await _bll.IngredientInCocktails.FirstOrDefaultDetailedAsync(id);

        // Check If Exist In Database.
        if (ingredientInCocktail == null) return NotFound();

        return _mapper.Map(ingredientInCocktail)!;
    }

    /// <summary>
    /// Method Updates Record of Ingredients In Cocktail In Database Layer.
    /// </summary>
    /// <param name="id">Ingredients In Cocktail ID Value of Ingredients In Cocktail To Be Updated.</param>
    /// <param name="ingredientInCocktail">Defines Ingredients In Cocktail Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutIngredientInCocktail(Guid id, IngredientInCocktail ingredientInCocktail)
    {
        if (!id.Equals(ingredientInCocktail.Id)) return BadRequest();
        
        // Update State In Database.
        _bll.IngredientInCocktails.Update(_mapper.Map(ingredientInCocktail)!);
        await _bll.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Method Creates Ingredients In Cocktail Record In Database Layer.
    /// </summary>
    /// <param name="ingredientInCocktail">Object Value To Be Created In Database.</param>
    /// <returns>Created Ingredients In Cocktail Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(IngredientInCocktail), StatusCodes.Status200OK)]
    public async Task<ActionResult<IngredientInCocktail>> PostIngredientInCocktail(IngredientInCocktail ingredientInCocktail)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Ingredients In Cocktail To The Database Layer.
        var bllIngredientInCocktail = _bll.IngredientInCocktails.Add(_mapper.Map(ingredientInCocktail)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetIngredientInCocktail", new
        {
            id = bllIngredientInCocktail.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllIngredientInCocktail);
    }

    /// <summary>
    /// Method Deletes Ingredients In Cocktail In The Database Layer.
    /// </summary>
    /// <param name="id">Ingredients In Cocktail ID Value of Ingredients In Cocktail To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteIngredientInCocktail(Guid id)
    {
        // Try To Get Record From Database.
        var ingredientInCocktail = await _bll.IngredientInCocktails.FirstOrDefaultAsync(id);
        if (ingredientInCocktail == null) return NotFound();
    
        // Remove Existed Record.
        _bll.IngredientInCocktails.Remove(ingredientInCocktail);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}