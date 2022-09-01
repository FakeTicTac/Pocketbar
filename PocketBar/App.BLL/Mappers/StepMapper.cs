using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Step Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class StepMapper : BaseMapper<BllAppDTO.Step, DalAppDTO.Step>
{
    
    /// <summary>
    /// Basic Step Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public StepMapper(IMapper mapper) : base(mapper) { }
    
}