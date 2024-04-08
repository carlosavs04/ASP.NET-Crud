using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppWebs.Models
{
    public class Customers
    {
        [Key]
        [JsonPropertyName("customer_id")]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string? Name { get; set; }

        [JsonPropertyName("address")]
        [Required]
        public string? Address { get; set; }

        [JsonPropertyName("website")]
        [Required]
        public string? Website { get; set; }

        [JsonPropertyName("credit_limit")]
        [Column("credit_limit")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required]
        public decimal CreditLimit { get; set; }

    }
}
