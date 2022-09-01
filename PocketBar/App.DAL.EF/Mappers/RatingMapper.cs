using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Rating Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class RatingMapper : BaseMapper<DalAppDTO.Rating, DomainApp.Rating>
{
    
    /// <summary>
    /// Basic Rating Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public RatingMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer Rating Object Into Data Access Layer Object With Collection Counters.
    /// </summary>
    /// <param name="rating">Defines Database Layer Rating Object.</param>
    /// <returns>Data Access Layer Rating Object.</returns>
    public DalAppDTO.Rating? MapperWithCounter(DomainApp.Rating rating)
    {
        var baseMapped = base.Map(rating);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.UsageCount = rating.UserCocktails!.Count;

        return baseMapped;
    }
}