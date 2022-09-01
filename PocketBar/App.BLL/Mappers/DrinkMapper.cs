using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Drink Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkMapper : BaseMapper<BllAppDTO.Drink, DalAppDTO.Drink>
{
    
    /// <summary>
    /// Basic Drink Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkMapper(IMapper mapper) : base(mapper) { }
   
}