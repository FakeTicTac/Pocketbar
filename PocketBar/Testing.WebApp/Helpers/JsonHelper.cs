using System.Text.Json;


namespace Testing.WebApp.Helpers;


/// <summary>
/// Class Handles Json Objects.
/// </summary>
public static class JsonHelper
{
    
    /// <summary>
    /// Defines Connection To Json Serializer.
    /// </summary>
    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);
        
    /// <summary>
    /// Method Deserializes Json Object Into Given Type Of Object.
    /// </summary>
    /// <param name="json">Defines Json Type Object</param>
    /// <typeparam name="TValue">Defines Value Of Object Type To Deserialize JSON.</typeparam>
    /// <returns>Deserialized Object Into TValue</returns>
    public static TValue? DeserializeWithWebDefaults<TValue>(string json) =>
        JsonSerializer.Deserialize<TValue>(json, JsonSerializerOptions);

}