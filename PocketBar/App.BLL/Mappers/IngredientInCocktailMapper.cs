using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Ingredient In Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class IngredientInCocktailMapper : BaseMapper<BllAppDTO.IngredientInCocktail, DalAppDTO.IngredientInCocktail>
{
    
    /// <summary>
    /// Basic Ingredient In Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientInCocktailMapper(IMapper mapper) : base(mapper) { }
    
}