using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local


namespace App.BLL.Mappers;


/// <summary>
/// Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class CocktailMapper : BaseMapper<BllAppDTO.Cocktail, DalAppDTO.Cocktail>
{
    
    /// <summary>
    /// Basic Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public CocktailMapper(IMapper mapper) : base(mapper) { }

}