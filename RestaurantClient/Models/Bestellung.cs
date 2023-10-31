using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Restaurant.Models
{
    /// <summary>
    /// Modell für Bestellungen
    /// <para>Attribute:</para>
    /// <para>int ID_Bestellung</para>
    /// <para>DateTime Datum</para>
    /// <para>int ID_Tisch</para>
    /// <para>List(Bestellposiiton) Positionen</para>
    /// </summary>
    public class Bestellung
    {
        [JsonPropertyName("iD_Bestellung")]
        public int ID_Bestellung { get; set; }
        [JsonPropertyName("datum")]
        public DateTime Datum { get; set; }
        [JsonPropertyName("iD_Tisch")]
        public int ID_Tisch { get; set; }
        [JsonPropertyName("positionen")]
        public List<Bestellposition> Positionen { get; set; }
    }
}
