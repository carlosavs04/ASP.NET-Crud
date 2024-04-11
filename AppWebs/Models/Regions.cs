using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Regions
    {
        [Key]
        [JsonPropertyName("region_id")]
        [Column("region_id")]
        public int RegionId { get; set; }

        [JsonPropertyName("region_name")]
        [Column("region_name")]
        [Required]
        [MaxLength(40)]
        public string? RegionName { get; set; }
    }
}
