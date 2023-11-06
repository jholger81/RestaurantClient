using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    /// <summary>
    /// Modell für Beziehung zwischen Bestellungen und Rechnungen
    /// <para>Attribute:</para>
    /// <para>int ID_Bestellung</para>
    /// <para>int ID_Rechnung</para>
    /// </summary>
    public class Bestellung_Rechnung
    {
        [JsonPropertyName("iD_Bestellung")]
        public int ID_Bestellung { get; set; }
        [JsonPropertyName("iD_Rechnung")]
        public int ID_Rechnung { get; set; }
    }
}
