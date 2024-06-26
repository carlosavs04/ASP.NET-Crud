﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Locations
    {
        [Key]
        [JsonPropertyName("location_id")]
        [Column("location_id")]
        public int LocationId { get; set; }

        [JsonPropertyName("address")]
        [Required]
        public string? Address { get; set; }

        [JsonPropertyName("postal_code")]
        [Column("postal_code")]
        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [JsonPropertyName("city")]
        [MaxLength(50)]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        [MaxLength(50)]
        public string? State { get; set; }

        [ForeignKey("Countries")]
        [JsonPropertyName("country_id")]
        [Column("country_id")]
        public string? CountryId { get; set; }

        public Countries? Countries { get; set; }
    }
}
