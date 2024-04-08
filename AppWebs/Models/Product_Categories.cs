using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Product_Categories
    {
        [Key]
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("category_name")]
        public string? CategoryName { get; set; }

        [JsonPropertyName("product_count")]
        public int ProductCount { get; set; }
    }
}
