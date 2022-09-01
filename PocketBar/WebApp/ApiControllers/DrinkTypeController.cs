using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Drink Type Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
public class DrinkTypeController : ControllerBase
{
    
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Drink Type Mapper Connection Definition.
    /// </summary>
    private readonly DrinkTypeMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkTypeController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new DrinkTypeMapper(mapper);
    }

    /// <summary>
    /// Method Gets All Drink Types With Counters. (Counter of Usages In Drinks)
    /// </summary>
    /// <returns>IEnumerable of Drink Types With Counters. (Counter of Usages In Drinks)</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DrinkType>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DrinkType>>> GetDrinkTypes() =>
        Ok((await _bll.DrinkTypes.GetAllWithDrinksCountAsync()).Select(x => _mapper.Map(x)));

    /// <summary>
    /// Method Gets Drink Types With Counter. (Counter of Usages In Drinks)
    /// </summary>
    /// <param name="id">Drink Type ID Value To Search For Drink Type.</param>
    /// <returns>Drink Types With Counter. (Counter of Usages In Drinks)</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DrinkType), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DrinkType>> GetDrinkType(Guid id)
    {
        var drinkType = await _bll.DrinkTypes.FirstOrDefaultWithDrinksCountAsync(id);
        
        // Check If Exist In Database.
        if (drinkType == null)  return NotFound();
        
        return _mapper.Map(drinkType)!;
    }

    /// <summary>
    /// Method Updates Record of Drink Type In Database Layer.
    /// </summary>
    /// <param name="id">Drink Type ID Value of Drink Type To Be Updated.</param>
    /// <param name="drinkType">Defines Drink Type Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Consumes("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutDrinkType(Guid id, DrinkType drinkType)
    {
        if (!id.Equals(drinkType.Id)) return BadRequest();
        
        // Update State In Database.
        _bll.DrinkTypes.Update(_mapper.Map(drinkType)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Drink Type Record In Database Layer.
    /// </summary>
    /// <param name="drinkType">Object Value To Be Created In Database.</param>
    /// <returns>Created Drink Type Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [ProducesResponseType(typeof(DrinkType), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<DrinkType>> PostDrinkType(DrinkType drinkType)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Drink Type To The Database Layer.
        var bllDrinkType = _bll.DrinkTypes.Add(_mapper.Map(drinkType)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetDrinkType", new
        {
            id = bllDrinkType.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllDrinkType);
    }

    /// <summary>
    /// Method Deletes Drink Type In The Database Layer.
    /// </summary>
    /// <param name="id">Drink Type ID Value of Drink Type To Be Deleted.</param>
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
    public async Task<IActionResult> DeleteDrinkType(Guid id)
    {
        // Try To Get Record From Database.
        var drinkType = await _bll.DrinkTypes.FirstOrDefaultAsync(id);

        if (drinkType == null) return NotFound();
        
        
        // Remove Existed Record.
        _bll.DrinkTypes.Remove(drinkType);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}