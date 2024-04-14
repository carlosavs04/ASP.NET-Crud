using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Countries
    {
        [Key]
        [JsonPropertyName("country_id")]
        [Column("country_id")]
        public int CountryId { get; set; }

        [JsonPropertyName("country_name")]
        [Column("country_name")]
        [Required]
        [MaxLength(40)]
        public string? CountryName { get; set; }

        [ForeignKey("Regions")]
        [JsonPropertyName("region_id")]
        [Column("region_id")]
        public int RegionId { get; set; }

        public Regions? Regions { get; set; }
    }
}
