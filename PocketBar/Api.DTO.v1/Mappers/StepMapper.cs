using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Step Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class StepMapper : BaseMapper<Step, BllAppDTO.Step>
{
    
    /// <summary>
    /// Basic Step Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public StepMapper(IMapper mapper) : base(mapper) { }
    
}