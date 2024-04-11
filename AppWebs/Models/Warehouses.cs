using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Warehouses
    {
        [Key]
        [JsonPropertyName("warehouse_id")]
        [Column("warehouse_id")]
        public int WarehouseId { get; set; }

        [JsonPropertyName("warehouse_name")]
        [Column("warehouse_name")]
        [Required]
        public string? WarehouseName { get; set; }

        [ForeignKey("Locations")]
        [JsonPropertyName("location_id")]
        [Column("location_id")]
        public int LocationId { get; set; }

        public string? LocationName { get; set; }
    }
}
