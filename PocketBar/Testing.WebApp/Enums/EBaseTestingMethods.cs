
namespace Testing.WebApp.Enums;


/// <summary>
/// Enumeration Of All Methods Represented In Base Entity Repository.
/// </summary>
public enum EBaseTestingMethods
{
    
    // Sync Methods
    Add,
    Exist,
    Update,
    Remove,
    GetAll,
    FirstOrDefault,
    
    // Async Methods
    ExistAsync,
    RemoveAsync,
    GetAllAsync,
    FirstOrDefaultAsync,
    
}