using Base.Contracts.Domain;
using System.ComponentModel.DataAnnotations;


namespace Base.Domain;


/// <summary>
/// Basic Database Meta-data Entity Implementation: Uses Guid Value as Primary Key Type.
/// </summary>
public abstract class DomainEntityMetaId : DomainEntityMetaId<Guid>, IDomainEntityId { }


/// <summary>
/// Basic Database Meta-data Entity Implementation: Defines Common Rows in Database Table.
/// </summary>
/// <typeparam name="TKey"></typeparam>
public abstract class DomainEntityMetaId<TKey> : DomainEntityId<TKey>, IDomainEntityMeta
    where TKey : IEquatable<TKey>
{
    
    /// <summary>
    /// Defines Data Insertion Time. 
    /// </summary>
    [MaxLength(64)]
    [Display(ResourceType = typeof(Base.Resources.Domain.Domain), Name = nameof(CreatedBy))]
    public string? CreatedBy { get; set; }
    
    /// <summary>
    /// Defines User/System Who Inserted The Data.
    /// </summary>
    [Display(ResourceType = typeof(Base.Resources.Domain.Domain), Name = nameof(CreatedAt))]
    public DateTime? CreatedAt { get; set; }
    
    /// <summary>
    /// Defines Data Update Time. 
    /// </summary>
    [MaxLength(64)]
    [Display(ResourceType = typeof(Base.Resources.Domain.Domain), Name = nameof(ModifiedBy))]
    public string? ModifiedBy { get; set; }
    
    /// <summary>
    /// Defines User/System Who Updated The Data.
    /// </summary>
    [Display(ResourceType = typeof(Base.Resources.Domain.Domain), Name = nameof(ModifiedAt))]
    public DateTime? ModifiedAt { get; set; }
    
}