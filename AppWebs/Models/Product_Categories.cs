using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Product_Categories
    {
        [Key]
        [JsonPropertyName("category_id")]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("category_name")]
        [Column("category_name")]
        [Required]
        public string? CategoryName { get; set; }

        public int ProductCount { get; set; }
    }
}
