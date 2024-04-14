using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Products
    {
        [Key]
        [JsonPropertyName("product_id")]
        [Column("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("product_name")]
        [Column("product_name")]
        [Required]
        public string? ProductName { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("standard_cost")]
        [Column("standard_cost")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal StandardCost { get; set; }

        [JsonPropertyName("list_price")]
        [Column("list_price")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ListPrice { get; set; }

        [ForeignKey("Product_Categories")]
        [JsonPropertyName("category_id")]
        [Column("category_id")]
        [Required]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
        public Product_Categories? Product_Categories { get; set; }
    }
}
