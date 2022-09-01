using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain.Identity;
using DalAppDTO = App.DAL.DTO.Identity;


namespace App.DAL.EF.Mappers.Identity;


/// <summary>
/// Role Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class RoleMapper : BaseMapper<DalAppDTO.AppRole, DomainApp.AppRole>
{
    
    /// <summary>
    /// Basic Role Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RoleMapper(IMapper mapper) : base(mapper) { }
    
}