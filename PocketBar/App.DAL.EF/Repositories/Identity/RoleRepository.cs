using AutoMapper;
using Base.DAL.EF.Repositories;
using App.DAL.EF.Mappers.Identity;
using App.Contracts.DAL.Repositories.Identity;

using DomainApp = App.Domain.Identity;
using DalAppDTO = App.DAL.DTO.Identity;


namespace App.DAL.EF.Repositories.Identity;


/// <summary>
/// Role Data Access Layer Repository Design Implementation.  
/// </summary>
public class RoleRepository : BaseEntityRepository<DalAppDTO.AppRole, DomainApp.AppRole, DomainApp.AppUser, AppDbContext>, 
    IRoleRepository
{
    
    /// <summary>
    /// Data Access Layer Role Repository Basic Constructor Defines Connection To The Database Layer.
    /// </summary>
    /// <param name="dbContext">Database Layer Connection Definition.</param>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RoleRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new RoleMapper(mapper)) { }
    
}