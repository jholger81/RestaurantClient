using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    /// <summary>
    /// Modell für Rechnungen
    /// <para>Attribute:</para>
    /// <para>int ID_Bestellung</para>
    /// <para>int Trinkgeld (in Cent)</para>
    /// </summary>
    public class Rechnung
    {
        [JsonPropertyName("iD_Bestellung")]
        public int ID_Bestellung { get; set; }
        [JsonPropertyName("trinkgeld")]
        int Trinkgeld { get; set; }
    }
}
