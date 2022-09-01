using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Amount Unit Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class AmountUnitMapper : BaseMapper<AmountUnit, BllAppDTO.AmountUnit>
{
    
    /// <summary>
    /// Basic Amount Unit Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public AmountUnitMapper(IMapper mapper) : base(mapper) { }
    
}