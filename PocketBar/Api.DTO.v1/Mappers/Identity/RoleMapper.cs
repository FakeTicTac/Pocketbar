using AutoMapper;
using Base.BLL.Mappers;
using Api.DTO.v1.Identity;


using BllAppDTO = App.BLL.DTO.Identity;


namespace Api.DTO.v1.Mappers.Identity;


/// <summary>
/// Role Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class RoleMapper : BaseMapper<AppRole, BllAppDTO.AppRole>
{
    
    /// <summary>
    /// Basic Role Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RoleMapper(IMapper mapper) : base(mapper) { }
    
}