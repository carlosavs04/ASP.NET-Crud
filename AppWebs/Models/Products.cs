using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Products
    {
        [Key]
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("product_name")]
        public string? ProductName { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("standard_cost")]
        public decimal StandardCost { get; set; }

        [JsonPropertyName("list_price")]
        public decimal ListPrice { get; set; }

        [ForeignKey("Product_Categories")]
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
    }
}
