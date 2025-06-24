using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamenApi.Core.Models
{
    public class Animal
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("scientific_name")]
        public string ScientificName { get; set; }

        [JsonPropertyName("conservation_status")]
        public string ConservationStatus { get; set; }

        [JsonPropertyName("group")]
        public string GroupName { get; set; }

        [JsonPropertyName("iso_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("common_name")]
        public string CommonName { get; set; }

    }
}
