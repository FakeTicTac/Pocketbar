using Api.DTO.v1;
using AutoMapper;
using Base.Extensions;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For User Cocktail Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserCocktailController : ControllerBase
{
    
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;
    
    /// <summary>
    /// User Cocktail Mapper Connection Definition.
    /// </summary>
    private readonly UserCocktailMapper _mapper;


    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserCocktailController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new UserCocktailMapper(mapper);
    }


    /// <summary>
    /// Method Gets All User Cocktails With Detailed Info. (Rating Value And Cocktail Name)
    /// </summary>
    /// <returns>IEnumerable of User Cocktails With Detailed Info. (Rating Value And Cocktail Name)</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<UserCocktail>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserCocktail>>> GetUserCocktails() =>
        Ok((await _bll.UserCocktails.GetAllDetailedAsync(User.GetUserId())).Select(x => _mapper.Map(x)));
    
    /// <summary>
    /// Method Gets User Cocktail With Detailed Info. (Rating Value And Cocktail Name)
    /// </summary>
    /// <param name="id">User Cocktail ID Value To Search For User Cocktail.</param>
    /// <returns>User Cocktail With Detailed Info. (Rating Value And Cocktail Name)</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserCocktail), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserCocktail>> GetUserCocktail(Guid id)
    {
        // Check If Access Can Be Performed.
        var userCocktail = await _bll.UserCocktails.FirstOrDefaultDetailedAsync(id, User.GetUserId());
        
        // Check If Exist In Database.
        if (userCocktail == null) return NotFound();
        
        return _mapper.Map(userCocktail)!;
    }

    /// <summary>
    /// Method Updates Record of User Cocktail In Database Layer.
    /// </summary>
    /// <param name="id">User Cocktail ID Value of User Cocktail To Be Updated.</param>
    /// <param name="userCocktail">Defines User Cocktail Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutUserCocktail(Guid id, UserCocktail userCocktail)
    {
        if (!id.Equals(userCocktail.Id)) return BadRequest();
        
        if (!await _bll.UserCocktails.ExistAsync(id, User.GetUserId())) return BadRequest();

        // Update State In Database.
        _bll.UserCocktails.Update(_mapper.Map(userCocktail)!);
        await _bll.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Method Creates User Cocktail Record In Database Layer.
    /// </summary>
    /// <param name="userCocktail">Object Value To Be Created In Database.</param>
    /// <returns>Created User Cocktail Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(UserCocktail), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserCocktail>> PostUserCocktail(UserCocktail userCocktail)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Check If User Puts Data For Himself.
        userCocktail.AppUserId = User.GetUserId();
        
        // Add User Cocktail To The Database Layer.
        var bllUserCocktail = _bll.UserCocktails.Add(_mapper.Map(userCocktail)!, User.GetUserId());
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetUserCocktail", new
        {
            id = bllUserCocktail.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllUserCocktail);
    }

    /// <summary>
    /// Method Deletes User Cocktail In The Database Layer.
    /// </summary>
    /// <param name="id">User Cocktail ID Value of User Cocktail To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUserCocktail(Guid id)
    {
        if (!await _bll.UserCocktails.ExistAsync(id, User.GetUserId())) return NotFound();
        
        // Remove Existed Record.
        _bll.UserCocktails.Remove(id, User.GetUserId());
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }
}