using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Rating Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RatingController : ControllerBase
{
    
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Rating Mapper Connection Definition.
    /// </summary>
    private readonly RatingMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RatingController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new RatingMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Ratings With Counters. (Counter of Usages User Cocktails)
    /// </summary>
    /// <returns>IEnumerable of Ratings With Counters. (Counter of Usages User Cocktails)</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Rating>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Rating>>> GetRatings() =>
        Ok((await _bll.Ratings.GetAllWithUsageCountAsync()).Select(x => _mapper.Map(x)));


    /// <summary>
    /// Method Gets Rating With Counter. (Counter of Usages User Cocktails)
    /// </summary>
    /// <param name="id">Rating ID Value To Search For Rating.</param>
    /// <returns>Rating With Counter. (Counter of Usages User Cocktails)</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Rating), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Rating>> GetRating(Guid id)
    {
        var rating = await _bll.Ratings.FirstOrDefaultWithUsageCountAsync(id);

        // Check If Exist In Database.
        if (rating == null) return NotFound();

        return _mapper.Map(rating)!;
    }

    /// <summary>
    /// Method Updates Record of Rating In Database Layer.
    /// </summary>
    /// <param name="id">Rating ID Value of Rating To Be Updated.</param>
    /// <param name="rating">Defines Rating Value To Be Updated.</param>
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
    public async Task<IActionResult> PutRating(Guid id, Rating rating)
    {
        if (!id.Equals(rating.Id)) return BadRequest();
        
        // Update State In Database.
        _bll.Ratings.Update(_mapper.Map(rating)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Rating Record In Database Layer.
    /// </summary>
    /// <param name="rating">Object Value To Be Created In Database.</param>
    /// <returns>Created Rating Object.</returns>
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(Drink), StatusCodes.Status200OK)]
    public async Task<ActionResult<Rating>> PostRating(Rating rating)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Rating To The Database Layer.
        var bllRating = _bll.Ratings.Add(_mapper.Map(rating)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetRating", new
        {
            id = bllRating.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllRating);
    }

    /// <summary>
    /// Method Deletes Rating In The Database Layer.
    /// </summary>
    /// <param name="id">Rating ID Value of Rating To Be Deleted.</param>
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
    public async Task<IActionResult> DeleteRating(Guid id)
    {
        // Try To Get Record From Database.
        var rating = await _bll.Ratings.FirstOrDefaultAsync(id);
        if (rating == null) return NotFound();
    
        // Remove Existed Record.
        _bll.Ratings.Remove(rating);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}