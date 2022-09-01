using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Drink In Cocktail Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class DrinkInCocktailMapper : BaseMapper<BllAppDTO.DrinkInCocktail, DalAppDTO.DrinkInCocktail>
{
    
    /// <summary>
    /// Basic Drink In Cocktail Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public DrinkInCocktailMapper(IMapper mapper) : base(mapper) { }
    
}