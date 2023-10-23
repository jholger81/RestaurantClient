using System.Text.Json.Serialization;

namespace Restaurant.Models
{
    /// <summary>
    /// Modell für Tische
    /// <para>Attribute:</para>
    /// <para>int ID_Tisch</para>
    /// <para>int ID_Kellner</para>
    /// </summary>
    public class Tisch
    {
        [JsonPropertyName("iD_Tisch")]
        public int ID_Tisch { get; set; }
        [JsonPropertyName("iD_Kellner")]
        public int ID_Kellner { get; set; }
    }
}
