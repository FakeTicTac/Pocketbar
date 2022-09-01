using Api.DTO.v1;
using AutoMapper;
using App.Contracts.BLL;
using Api.DTO.v1.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace WebApp.ApiControllers;


/// <summary>
/// API Controller For Ingredient Data Transfer.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Bartender")]
public class IngredientController : ControllerBase
{
   
    /// <summary>
    /// Business Logic Layer Connection Definition.
    /// </summary>
    private readonly IAppBusinessLogic _bll;

    /// <summary>
    /// Rating Mapper Connection Definition.
    /// </summary>
    private readonly IngredientMapper _mapper;
        
    
    /// <summary>
    /// Basic API Constructor Defines Business Logic Layer Connection.
    /// </summary>
    /// <param name="bll">Defines Business Logic Layer</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientController(IAppBusinessLogic bll, IMapper mapper)
    {
        _bll = bll;
        _mapper = new IngredientMapper(mapper);
    }


    /// <summary>
    /// Method Gets All Ingredients With Counters. (Counter of Usages In Collections.)
    /// </summary>
    /// <returns>IEnumerable of Ingredients With Counters. (Counter of Usages In Collections.)</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Ingredient>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients() =>
        Ok((await _bll.Ingredients.GetAllWithCocktailsCountAsync()).Select(x => _mapper.Map(x)));

    /// <summary>
    /// Method Gets Ingredient With Counters. (Counter of Usages In Collections.)
    /// </summary>
    /// <param name="id">Ingredient ID Value To Search For Ingredient.</param>
    /// <returns>Ingredient With Counters. (Counter of Usages In Collections.)</returns>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Ingredient), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Ingredient>> GetIngredient(Guid id)
    {
        var ingredient = await _bll.Ingredients.FirstOrDefaultWithCocktailsCountAsync(id);

        // Check If Exist In Database.
        if (ingredient == null) return NotFound();
        
        return _mapper.Map(ingredient)!;
    }

    /// <summary>
    /// Method Updates Record of Ingredient In Database Layer.
    /// </summary>
    /// <param name="id">Ingredient ID Value of Ingredient To Be Updated.</param>
    /// <param name="ingredient">Defines Ingredient Value To Be Updated.</param>
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
    public async Task<IActionResult> PutIngredient(Guid id, Ingredient ingredient)
    {
        if (!id.Equals(ingredient.Id)) return BadRequest();

        // Update State In Database.
        _bll.Ingredients.Update(_mapper.Map(ingredient)!);
        await _bll.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>
    /// Method Creates Ingredient Record In Database Layer.
    /// </summary>
    /// <param name="ingredient">Object Value To Be Created In Database.</param>
    /// <returns>Created Ingredient Object.</returns>
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Ingredient), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
    {
        if (HttpContext.GetRequestedApiVersion() == null) return BadRequest("API version is not defined.");
        
        // Add Rating To The Database Layer.
        var bllIngredient = _bll.Ingredients.Add(_mapper.Map(ingredient)!);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetIngredient", new
        {
            id = bllIngredient.Id,
            version = HttpContext.GetRequestedApiVersion()!.ToString()
        }, bllIngredient);
    }

    /// <summary>
    /// Method Deletes Ingredient In The Database Layer.
    /// </summary>
    /// <param name="id">Ingredient ID Value of Ingredient To Be Deleted.</param>
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
    public async Task<IActionResult> DeleteIngredient(Guid id)
    {
        // Try To Get Record From Database.
        var ingredient = await _bll.Ingredients.FirstOrDefaultAsync(id);
        if (ingredient == null) return NotFound();

        // Remove Existed Record.
        _bll.Ingredients.Remove(ingredient);
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}