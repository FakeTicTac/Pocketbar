using AutoMapper;
using Api.DTO.v1;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Cocktail Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CocktailController : ControllerBase
{
    
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Rating Mapper Connection Definition.
    /// </summary>
    private readonly CocktailMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CocktailController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new CocktailMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Cocktails With Counters.
    /// </summary>
    /// <returns>IEnumerable of Ratings With Counters</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Cocktail>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Cocktail>>> GetCocktails() =>
        Ok((await _bll.Cocktails.GetAllWithCountersAsync()).Select(x => _mapper.Map(x)));
    
    /// <summary>
    /// Method Gets Cocktail With Detailed Data.
    /// </summary>
    /// <param name="id">Cocktail ID Value To Search For Cocktail.</param>
    /// <returns>Cocktail With Detailed Data.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Cocktail), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Cocktail>> GetCocktail(Guid id)
    {
        var cocktail = await _bll.Cocktails.FirstOrDefaultDetailedAsync(id);

        // Check If Exist In Database.
        if (cocktail == null) return NotFound();
        
        return _mapper.Map(cocktail)!;
    }

    /// <summary>
    /// Method Updates Record of Cocktail In Database Layer.
    /// </summary>
    /// <param name="id">Cocktail ID Value of Cocktail To Be Updated.</param>
    /// <param name="cocktail">Defines Cocktail Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutCocktail(Guid id, Cocktail cocktail)
    {
        if (id != cocktail.Id) return BadRequest();

        // Update State In Database.
        _bll.Cocktails.Update(_mapper.Map(cocktail)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Cocktail Record In Database Layer.
    /// </summary>
    /// <param name="cocktail">Object Value To Be Created In Database.</param>
    /// <returns>Created Cocktail Object.</returns>
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Cocktail), StatusCodes.Status200OK)]

    public async Task<ActionResult<Cocktail>> PostCocktail(Cocktail cocktail)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Cocktail To The Database Layer.
        var bllCocktail = _bll.Cocktails.Add(_mapper.Map(cocktail)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetCocktail", new
        {
            id = bllCocktail.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllCocktail);
    }

    /// <summary>
    /// Method Deletes Cocktail In The Database Layer.
    /// </summary>
    /// <param name="id">Cocktail ID Value of Rating To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCocktail(Guid id)
    {
        // Try To Get Record From Database.
        var cocktail = await _bll.Cocktails.FirstOrDefaultAsync(id);
        if (cocktail == null) return NotFound();
   
        // Remove Existed Record.
        _bll.Cocktails.Remove(cocktail);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}