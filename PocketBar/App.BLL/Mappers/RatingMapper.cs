using AutoMapper;
using Base.BLL.Mappers;

using DalAppDTO = App.DAL.DTO;
using BllAppDTO = App.BLL.DTO;


namespace App.BLL.Mappers;


/// <summary>
/// Rating Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class RatingMapper : BaseMapper<BllAppDTO.Rating, DalAppDTO.Rating>
{
    
    /// <summary>
    /// Basic Rating Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RatingMapper(IMapper mapper) : base(mapper) { }
    
}