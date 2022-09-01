using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Ingredient Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class IngredientMapper : BaseMapper<Ingredient, BllAppDTO.Ingredient>
{
    
    /// <summary>
    /// Basic Ingredient Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientMapper(IMapper mapper) : base(mapper) { }
  
}