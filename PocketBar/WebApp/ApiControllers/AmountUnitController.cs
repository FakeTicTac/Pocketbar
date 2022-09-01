using AutoMapper;
using Api.DTO.v1;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Amount Unit Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
public class AmountUnitController : ControllerBase
{
    
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Amount Unit Mapper Connection Definition.
    /// </summary>
    private readonly AmountUnitMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AmountUnitController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new AmountUnitMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Amount Units With Counters. (Counter of Usages In Drinks And Ingredient In Cocktails)
    /// </summary>
    /// <returns>IEnumerable of Amount Units With Counters. (Counter of Usages In Drinks And Ingredient In Cocktails)</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<AmountUnit>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<AmountUnit>>> GetDrinkTypes() =>
        Ok((await _bll.AmountUnits.GetAllWithUsageCountsAsync()).Select(x => _mapper.Map(x)));
    
    /// <summary>
    /// Method Gets Amount Unit With Counter. (Counter of Usages In Drinks And Ingredient In Cocktails)
    /// </summary>
    /// <param name="id">Amount Unit ID Value To Search For Amount Unit.</param>
    /// <returns>Amount Unit With Counter. (Counter of Usages In Drinks And Ingredient In Cocktails)</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(AmountUnit), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AmountUnit>> GetAmountUnit(Guid id)
    {
        var amountUnit = await _bll.AmountUnits.FirstOrDefaultWithUsageCountsAsync(id);

        // Check If Exist In Database.
        if (amountUnit == null) return NotFound();
        
        return _mapper.Map(amountUnit)!;
    }

    /// <summary>
    /// Method Updates Record of Amount Unit In Database Layer.
    /// </summary>
    /// <param name="id">Amount Unit ID Value of Amount Unit To Be Updated.</param>
    /// <param name="amountUnit">Defines Amount Unit Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> PutAmountUnit(Guid id, AmountUnit amountUnit)
    {
        if (!id.Equals(amountUnit.Id))  return BadRequest();
        
        // Update State In Database.
        _bll.AmountUnits.Update(_mapper.Map(amountUnit)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Amount Unit Record In Database Layer.
    /// </summary>
    /// <param name="amountUnit">Object Value To Be Created In Database.</param>
    /// <returns>CreatedAmount Unit Object.</returns>
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(AmountUnit), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<AmountUnit>> PostAmountUnit(AmountUnit amountUnit)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Amount Unit To The Database Layer.
        var bllAmountUnit = _bll.AmountUnits.Add(_mapper.Map(amountUnit)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetAmountUnit", new
        {
            id = bllAmountUnit.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllAmountUnit);
    }

    /// <summary>
    /// Method Deletes Amount Unit In The Database Layer.
    /// </summary>
    /// <param name="id">Amount Unit ID Value of Amount Unit To Be Deleted.</param>
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
    public async Task<IActionResult> DeleteAmountUnit(Guid id)
    {
        // Try To Get Record From Database.
        var amountUnit = await _bll.AmountUnits.FirstOrDefaultAsync(id);

        if (amountUnit == null) return NotFound();
        
        // Remove Existed Record.
        _bll.AmountUnits.Remove(amountUnit);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}