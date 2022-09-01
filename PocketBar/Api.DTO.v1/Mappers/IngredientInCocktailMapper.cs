using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Ingredient In Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class IngredientInCocktailMapper : BaseMapper<IngredientInCocktail, BllAppDTO.IngredientInCocktail>
{
    
    /// <summary>
    /// Basic Ingredient In Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientInCocktailMapper(IMapper mapper) : base(mapper) { }
    
}