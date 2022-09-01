using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Drink Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkTypeMapper : BaseMapper<DrinkType, BllAppDTO.DrinkType>
{
    
    /// <summary>
    /// Basic Drink Type Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkTypeMapper(IMapper mapper) : base(mapper) { }
  
}