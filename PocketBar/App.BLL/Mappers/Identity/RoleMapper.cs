using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO.Identity;
using BllAppDTO = App.BLL.DTO.Identity;


namespace App.BLL.Mappers.Identity;


/// <summary>
/// Role Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class RoleMapper : BaseMapper<BllAppDTO.AppRole, DalAppDTO.AppRole>
{
    
    /// <summary>
    /// Basic Role Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RoleMapper(IMapper mapper) : base(mapper) { }
    
}