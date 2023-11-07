using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    /// <summary>
    /// Modell für Rechnungspositionen
    /// <para>Attribute:</para>
    /// <para>int ID_Rechnungsposition</para>
    /// <para>int ID_Artikel</para>
    /// <para>int ID_Rechnung</para>
    /// <para>Artikel Artikel</para>
    /// </summary>
    public class Rechnungposition
    {
        [JsonPropertyName("iD_Rechnungsposition")]
        public int ID_Rechnungposition { get; set; }
        [JsonPropertyName("iD_Artikel")]
        public int ID_Artikel { get; set; }
        [JsonPropertyName("iD_Rechnung")]
        public int ID_Rechnung { get; set; }
        [JsonPropertyName("artikel")]
        public Artikel Artikel { get; set; }
    }
}
