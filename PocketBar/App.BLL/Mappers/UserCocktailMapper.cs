using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// User Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class UserCocktailMapper : BaseMapper<BllAppDTO.UserCocktail, DalAppDTO.UserCocktail>
{
    
    /// <summary>
    /// Basic User Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public UserCocktailMapper(IMapper mapper) : base(mapper) { }
    
}