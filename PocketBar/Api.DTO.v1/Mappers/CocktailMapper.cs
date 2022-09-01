using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class CocktailMapper : BaseMapper<Cocktail, BllAppDTO.Cocktail>
{
    
    /// <summary>
    /// Basic Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CocktailMapper(IMapper mapper) : base(mapper) { }

}