using AutoMapper;
using Base.DAL.EF.Mappers;

using DomainApp = App.Domain;
using DalAppDTO = App.DAL.DTO;


namespace App.DAL.EF.Mappers;


/// <summary>
/// Step Mapping Profile Definition: Basic Implementation + Custom Implementation.
/// </summary>
public class StepMapper : BaseMapper<DalAppDTO.Step, DomainApp.Step>
{
    
    /// <summary>
    /// Basic Step Mapper Constructor. Defines Connection To The Mapper.
    /// </summary>
    /// <param name="mapper">Mapper Connection Definition.</param>
    public StepMapper(IMapper mapper) : base(mapper) { }
    
    
    /// <summary>
    /// Method Maps Database Layer Step Object Into Data Access Layer Object With Cocktail Name.
    /// </summary>
    /// <param name="step">Defines Database Layer User Cocktail Object.</param>
    /// <returns>Data Access Layer Step Object.</returns>
    public DalAppDTO.Step? MapperDetailed(DomainApp.Step step)
    {
        var baseMapped = base.Map(step);
        
        // Check Output For Null Reference. Not Proceed Any Mappings!
        if (baseMapped == null) return null;

        baseMapped.CocktailName = step.Cocktail!.Name;

        return baseMapped;
    }
}