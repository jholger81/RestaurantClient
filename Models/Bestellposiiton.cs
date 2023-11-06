using System.Text.Json.Serialization;

namespace Restaurant.Models
{
    /// <summary>
    /// Modell für Bestellpositionen
    /// <para>Attribute:</para>
    /// <para>int ID_Bestellposition</para>
    /// <para>int ID_Artikel</para>
    /// <para>int ID_Bestellung</para>
    /// <para>atring Extras</para>
    /// <para>int Geliefert</para>
    /// <para>Artikel Artikel</para>
    /// </summary>
    public class Bestellposition
    {
        [JsonPropertyName("iD_Bestellposition")]
        public int ID_Bestellposition { get; set; }
        [JsonPropertyName("iD_Artikel")]
        public int ID_Artikel { get; set; }
        [JsonPropertyName("iD_Bestellung")]
        public int ID_Bestellung { get; set; }
        [JsonPropertyName("extras")]
        public string Extras { get; set; }
        [JsonPropertyName("geliefert")]
        public int Geliefert { get; set; }
        [JsonPropertyName("artikel")]
        public Artikel Artikel { get; set; }
    }
}
