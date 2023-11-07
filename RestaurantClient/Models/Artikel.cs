using System.Text.Json.Serialization;

namespace Restaurant.Models
{
    /// <summary>
    /// Modell für Artikel
    /// <para>Attribute:</para>
    /// <para>int ID_Artikel</para>
    /// <para>string Name</para>
    /// <para>int Preis (in Cent)</para>
    /// </summary>
    public class Artikel
    {
        [JsonPropertyName("iD_Artikel")]
        public int ID_Artikel { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("preis")]
        public int Preis { get; set; }
    }
}
