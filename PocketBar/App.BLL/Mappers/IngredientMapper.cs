using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Ingredient Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class IngredientMapper : BaseMapper<BllAppDTO.Ingredient, DalAppDTO.Ingredient>
{
    
    /// <summary>
    /// Basic Ingredient Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public IngredientMapper(IMapper mapper) : base(mapper) { }
  
}