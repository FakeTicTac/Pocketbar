using AutoMapper;
using Api.DTO.v1;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Step Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
public class StepController : ControllerBase
{
    
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Step Mapper Connection Definition.
    /// </summary>
    private readonly StepMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public StepController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new StepMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Steps Of All Cocktails.
    /// </summary>
    /// <returns>IEnumerable of Steps Of All Cocktails.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Step), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Step>>> GetSteps() =>
        Ok((await _bll.Steps.GetAllAsync()).Select(x => _mapper.Map(x)));

    /// <summary>
    /// Method Gets Concrete Step With Cocktail Name
    /// </summary>
    /// <param name="id">Step ID Value To Search For Step.</param>
    /// <returns>Step With Cocktail Name.</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Step), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Step>> GetStep(Guid id)
    {
        var step = await _bll.Steps.FirstOrDefaultWithCocktailNameAsync(id);

        // Check If Exist In Database.
        if (step == null) return NotFound();
        
        return _mapper.Map(step)!;
    }

    /// <summary>
    /// Method Updates Record of Step In Database Layer.
    /// </summary>
    /// <param name="id">Step ID Value of Step To Be Updated.</param>
    /// <param name="step">Defines Step Value To Be Updated.</param>
    /// <returns>
    /// Status Codes:<br/>
    /// 204 No Content: Update Action Was Successful.<br/>
    /// 400 Bad Request: ID In URL And ID in DTO Doesn't Match.<br/>
    /// </returns>
    [HttpPut("{id:guid}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutStep(Guid id, Step step)
    {
        if (!id.Equals(step.Id)) return BadRequest();
        
        // Update State In Database.
        _bll.Steps.Update(_mapper.Map(step)!);
        await _bll.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Method Creates Step Record In Database Layer.
    /// </summary>
    /// <param name="step">Object Value To Be Created In Database.</param>
    /// <returns>Created Step Object.</returns>
    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Step), StatusCodes.Status200OK)]
    public async Task<ActionResult<Step>> PostStep(Step step)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Step To The Database Layer.
        var bllStep = _bll.Steps.Add(_mapper.Map(step)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetStep", new
        {
            id = bllStep.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllStep);
    }

    /// <summary>
    /// Method Deletes Step In The Database Layer.
    /// </summary>
    /// <param name="id">Step ID Value of Step To Be Deleted.</param>
    /// <returns>
    /// Status codes:<br/>
    /// 204 No Content: Delete Action Was Successful<br/>
    /// 404 Not Found: Server Fails To Find Drink Type<br/>
    /// </returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteStep(Guid id)
    {
        // Try To Get Record From Database.
        var step = await _bll.Steps.FirstOrDefaultAsync(id);
        if (step == null) return NotFound();
     
        // Remove Existed Record.
        _bll.Steps.Remove(step);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}