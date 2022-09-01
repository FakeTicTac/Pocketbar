using AutoMapper;
using Base.BLL.Mappers;


using BllAppDTO = App.BLL.DTO;


namespace Api.DTO.v1.Mappers;


/// <summary>
/// Rating Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class RatingMapper : BaseMapper<Rating, BllAppDTO.Rating>
{
    
    /// <summary>
    /// Basic Rating Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RatingMapper(IMapper mapper) : base(mapper) { }
    
}