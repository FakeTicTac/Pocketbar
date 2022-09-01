using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Drink Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkMapper : BaseMapper<Drink, BllAppDTO.Drink>
{
    
    /// <summary>
    /// Basic Drink Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkMapper(IMapper mapper) : base(mapper) { }
   
}