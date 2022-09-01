using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Drink In Cocktail Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
public class DrinkInCocktailController : ControllerBase
{
    
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Drink In Cocktail Mapper Connection Definition.
    /// </summary>
    private readonly DrinkInCocktailMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkInCocktailController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new DrinkInCocktailMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Drink In Cocktails.
    /// </summary>
    /// <returns>IEnumerable of Drink In Cocktails.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DrinkInCocktail>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DrinkInCocktail>>> GetDrinkInCocktails() =>
        Ok((await _bll.DrinkInCocktails.GetAllAsync()).Select(x => _mapper.Map(x)));

    /// <summary>
    /// Method Gets Drink In Cocktail With Detailed Info. (Names Of Entities)
    /// </summary>
    /// <param name="id">Drink In Cocktail ID Value To Search For Drink In Cocktail.</param>
    /// <returns>Drink In Cocktail With Detailed Info. (Names Of Entities)</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DrinkInCocktail), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DrinkInCocktail>> GetDrinkInCocktail(Guid id)
    {
        var drinkInCocktail = await _bll.DrinkInCocktails.FirstOrDefaultDetailedAsync(id);

        // Check If Exist In Database.
        if (drinkInCocktail == null) return NotFound();
        
        return _mapper.Map(drinkInCocktail)!;
    }

    /// <summary>
    /// Method Updates Record of Drink In Cocktail In Database Layer.
    /// </summary>
    /// <param name="id">Drink In Cocktail ID Value of Drink In Cocktail To Be Updated.</param>
    /// <param name="drinkInCocktail">Defines Drink In Cocktail Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutDrinkInCocktail(Guid id, DrinkInCocktail drinkInCocktail)
    {
        if (!id.Equals(drinkInCocktail.Id)) return BadRequest();
        
        // Update State In Database.
        _bll.DrinkInCocktails.Update(_mapper.Map(drinkInCocktail)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Drink In Cocktail Record In Database Layer.
    /// </summary>
    /// <param name="drinkInCocktail">Object Value To Be Created In Database.</param>
    /// <returns>Created Drink In Cocktail Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(DrinkInCocktail), StatusCodes.Status200OK)]
    public async Task<ActionResult<DrinkInCocktail>> PostDrinkInCocktail(DrinkInCocktail drinkInCocktail)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Drink In Cocktail To The Database Layer.
        var bllDrinkInCocktail = _bll.DrinkInCocktails.Add(_mapper.Map(drinkInCocktail)!);
        await _bll.SaveChangesAsync();
        
        return CreatedAtAction("GetDrinkInCocktail", new
        {
            id = bllDrinkInCocktail.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllDrinkInCocktail);
    }

    /// <summary>
    /// Method Deletes Drink In Cocktail In The Database Layer.
    /// </summary>
    /// <param name="id">Drink In Cocktail ID Value of Drink In Cocktail To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDrinkInCocktail(Guid id)
    {
        // Try To Get Record From Database.
        var drinkInCocktail = await _bll.DrinkInCocktails.FirstOrDefaultAsync(id);
        if (drinkInCocktail == null) return NotFound();
     
        // Remove Existed Record.
        _bll.DrinkInCocktails.Remove(drinkInCocktail);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}