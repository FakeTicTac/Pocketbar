using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Amount Unit Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class AmountUnitMapper : BaseMapper<BllAppDTO.AmountUnit, DalAppDTO.AmountUnit>
{
    
    /// <summary>
    /// Basic Amount Unit Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AmountUnitMapper(IMapper mapper) : base(mapper) { }
    
}