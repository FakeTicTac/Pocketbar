using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Drink Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
public class DrinkController : ControllerBase
{
    
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Drink Mapper Connection Definition.
    /// </summary>
    private readonly DrinkMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new DrinkMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Drinks With Counters And Drink Type.
    /// </summary>
    /// <returns>IEnumerable of Drinks With Counters And Drink Type.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Drink>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Drink>>> GetDrinks() =>
        Ok((await _bll.Drinks.GetAllWithDrinkTypeAndCocktailsCountAsync()).Select(x => _mapper.Map(x)));
    
    /// <summary>
    /// Method Gets Drink With Counters And Drink Type.
    /// </summary>
    /// <param name="id">Drink ID Value To Search For Drink.</param>
    /// <returns>Drink With Counters And Drink Type.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Drink), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Drink>> GetDrink(Guid id)
    {
        var drink = await _bll.Drinks.FirstOrDefaultWithDrinkTypeAndCocktailsCountAsync(id);

        // Check If Exist In Database.
        if (drink == null) return NotFound();
        
        return _mapper.Map(drink)!;
    }

    /// <summary>
    /// Method Updates Record of Drink In Database Layer.
    /// </summary>
    /// <param name="id">Drink ID Value of Drink To Be Updated.</param>
    /// <param name="drink">Defines Drink Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutDrink(Guid id, Drink drink)
    {
        if (!id.Equals(drink.Id)) return BadRequest();
        
        // Update State In Database.
        _bll.Drinks.Update(_mapper.Map(drink)!);
        await _bll.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Method Creates Drink Record In Database Layer.
    /// </summary>
    /// <param name="drink">Object Value To Be Created In Database.</param>
    /// <returns>Created Drink Object.</returns>
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Drink), StatusCodes.Status200OK)]
    public async Task<ActionResult<Drink>> PostDrink(Drink drink)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Drink To The Database Layer.
        var bllDrink = _bll.Drinks.Add(_mapper.Map(drink)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetDrink", new
        {
            id = bllDrink.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllDrink);
    }

    /// <summary>
    /// Method Deletes Drink In The Database Layer.
    /// </summary>
    /// <param name="id">Drink ID Value of Drink To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDrink(Guid id)
    {
        // Try To Get Record From Database.
        var drink = await _bll.Drinks.FirstOrDefaultAsync(id);
        if (drink == null) return NotFound();
   
        // Remove Existed Record.
        _bll.Drinks.Remove(drink);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}