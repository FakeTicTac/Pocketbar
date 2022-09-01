using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Drink Type Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkTypeMapper : BaseMapper<BllAppDTO.DrinkType, DalAppDTO.DrinkType>
{
    
    /// <summary>
    /// Basic Drink Type Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkTypeMapper(IMapper mapper) : base(mapper) { }
  
}