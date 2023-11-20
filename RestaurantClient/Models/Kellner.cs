using System.Text.Json.Serialization;

namespace Restaurant.Models
{
    /// <summary>
    /// Modell für Kellner
    /// <para>Attribute:</para>
    /// <para>int ID_Kellner</para>
    /// <para>string Vorname</para>
    /// <para>string Nachname</para>
    /// </summary>
    public class Kellner
    {
        [JsonPropertyName("iD_Kellner")]
        public int ID_Kellner { get; set; }
        [JsonPropertyName("vorname")]
        public string Vorname { get; set; }
        [JsonPropertyName("nachname")]
        public string Nachname { get; set; }
        [JsonPropertyName("loginName")]
        public string LoginName { get; set; }
        [JsonPropertyName("passwort")]
        public string Passwort { get; set; }
    }
}
