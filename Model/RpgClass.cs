using System.Text.Json.Serialization;
namespace RPG.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,

        Mage = 2,
        
        Cleric = 3
    }
}