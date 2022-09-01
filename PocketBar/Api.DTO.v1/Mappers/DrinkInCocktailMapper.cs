using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Drink In Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkInCocktailMapper : BaseMapper<DrinkInCocktail, BllAppDTO.DrinkInCocktail>
{
    
    /// <summary>
    /// Basic Drink In Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkInCocktailMapper(IMapper mapper) : base(mapper) { }
    
}