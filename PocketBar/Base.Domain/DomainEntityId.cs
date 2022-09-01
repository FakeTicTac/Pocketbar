using Base.Contracts.Domain;
using System.ComponentModel.DataAnnotations;


namespace Base.Domain;


/// <summary>
/// Basic Database Entity Implementation. Uses Guid Value as Primary Key Type.
/// </summary>
public abstract class DomainEntityId : DomainEntityId<Guid>, IDomainEntityId { }


/// <summary>
/// Basic Database Entity Implementation. Defines Common Rows in Basic Entity Database Table.
/// </summary>
/// <typeparam name="TKey">Entity Primary Key Definition.</typeparam>
public abstract class DomainEntityId<TKey> : IDomainEntityId<TKey>
    where TKey : IEquatable<TKey>
{
    
    /// <summary>
    /// Entity Primary Key Definition.
    /// </summary>
    [Display(ResourceType = typeof(Base.Resources.Domain.Domain), Name = nameof(Id))]
    public TKey Id { get; set; } = default!;
}